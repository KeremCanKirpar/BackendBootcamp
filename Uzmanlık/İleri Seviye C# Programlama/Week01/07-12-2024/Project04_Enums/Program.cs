/*
OrderStatus:
1-> Sipariş Alındı
2-> Kargo Hazırlanıyor
3-> Kargoya Verildi
4-> Teslim Edildi
*/

// Yeni Sipariş
// int orderStatus = 1;

// Kargo Hazırlanıyor
// orderStatus=2;

// Kargoya Verildi
// orderStatus=3;

// Teslim Edildi
// orderStatus=4;

//Sipariş Alındı
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

OrderStatus status  = OrderStatus.Received;

// //Hazırlanıyor
// status = OrderStatus.Proccesing;
// status = OrderStatus.Shipped;

// System.Console.WriteLine(status);


// Gender gender1 = Gender.Female;
// int gender2 =1;

// enum Gender
// {
//     Female,
//     Male
// }

status = OrderStatus.Shipped;
System.Console.WriteLine(status);

string statusDescription = status.GetType()?
.GetField(status.ToString())?
.GetCustomAttribute<DescriptionAttribute>()?
.Description;


status = OrderStatus.Delivered;
string statusDescription2 = status.GetType()?
.GetField(status.ToString())?
.GetCustomAttribute<DisplayAttribute>()?
.Name;


enum OrderStatus
{
    [Description("Sipariş Alındı")]
    [DisplayName(Name = "Sipariş Alındı")]
    Received=1,

    [Description("Hazırlanıyor")]
    [DisplayName(Name = "Hazırlanıyor")]
    Proccesing =2,

    [Description("Kargoya verildi")]
    [DisplayName(Name = "Kargoya Verildi")]
    Shipped =3,

    [Description("Teslim Edildi")]
    [DisplayName(Name = "Teslim Edildi")]
    Delivered =4
}















// enum OrderStatus
// {
//     Received,//0
//     Proccesing,//1
//     Shipped,//2
//     Delivered//3
// }