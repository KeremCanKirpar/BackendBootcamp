using System;
using Microsoft.AspNetCore.Routing.Patterns;

namespace BlogApp.Models;

public class ContactModel
{
    public string? AdSoyad { get; set; }
    public string? Email { get; set; }   
    public string? Konu { get; set; }
    public string? Mesaj { get; set; }
 
}
