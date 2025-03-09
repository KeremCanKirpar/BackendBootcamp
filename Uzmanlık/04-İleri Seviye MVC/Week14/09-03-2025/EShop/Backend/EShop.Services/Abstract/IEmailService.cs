using System;
using EShop.Shared.Dtos.ResponseDtos;

namespace EShop.Services.Abstract;

public interface IEmailService
{
    Task<ResponseDto<NoContent>> SendEmailAsync(string emailTo, string subject, string htmlBody);
}
