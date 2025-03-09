using System;

namespace EShop.Shared.Configurations.Email;

public class EmailConfig
{
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string SmtpUser { get; set; } = string.Empty;
    public string SmptPassword { get; set; } = string.Empty;
}
