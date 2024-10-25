using System;

namespace BlogApp.Models;

public class AboutModel
{
    public string? AdSoyad { get; set; }
    public string? Aciklama { get; set; }
    public string? Link { get; set; }
    public string? StajYer { get; set; }
    public string? Resim { get; set; }

    public List<Staj>? Staj { get; set; }
    public List<LinkModel>? Links {get; set;}
}
