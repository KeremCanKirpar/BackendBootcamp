using System;
using EShop.MVC.Models;
using EShop.MVC.Services.Abstract;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;

namespace EShop.MVC.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        public async Task<ResponseModel<bool>> CheckoutAsync(OrderCreateModel orderCreateModel)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-rtKoL0NsUmzMhYQIhb0YpSTrPkT0JlWk";
            options.SecretKey = "sandbox-sVqA8gmmReaG69WwtDRn9KPADq8hDspX";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = orderCreateModel.TotalAmount.ToString().Replace(",","."); //17,98
            request.PaidPrice = orderCreateModel.TotalAmount.ToString().Replace(",", ".");
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = orderCreateModel.CardHolderName;
            paymentCard.CardNumber = orderCreateModel.CardNumber;
            paymentCard.ExpireMonth = orderCreateModel.ExpireMonth;
            paymentCard.ExpireYear = orderCreateModel.ExpireYear;
            paymentCard.Cvc = orderCreateModel.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = orderCreateModel.FirstName;
            buyer.Surname = orderCreateModel.LastName;
            buyer.GsmNumber = orderCreateModel.PhoneNumber;
            buyer.Email = orderCreateModel.Email;
            buyer.IdentityNumber = orderCreateModel.IdentityNumber;
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = orderCreateModel.Address;
            buyer.Ip = "85.34.78.112";
            buyer.City = orderCreateModel.City;
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = $"{orderCreateModel.FirstName} {orderCreateModel.LastName}";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;
            request.BillingAddress = shippingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            basketItems = orderCreateModel.OrderItems.Select(x => new BasketItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = x.ProductName,
                Category1 = "Kategori1",
                Category2 = "Kategori2",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = x.TotalPrice.ToString().Replace(",", ".")
            }).ToList();

            request.BasketItems = basketItems;

            Payment payment = await Payment.Create(request, options);
            var responseModel = new ResponseModel<bool>
            {
                Data = payment.Status == "success",
                Error = payment.ErrorMessage,
                IsSuccessful = payment.Status == "success",
                StatusCode = payment.StatusCode
            };
            return responseModel;
        }
    }
}
