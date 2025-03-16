using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace EShop.MVC.TagHelpers;

public class AvatarTagHelper : TagHelper
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Class { get; set; } = "";
    public int Size { get; set; } = 150;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        var baseClass = "avatar-circle";
        var classes = string.IsNullOrEmpty(Class) ? baseClass : $"{baseClass} {Class}";

        var initials = $"{(FirstName?.FirstOrDefault() ?? ' ')}{(LastName?.FirstOrDefault() ?? ' ')}".Trim().ToUpper();
        var fontSize = Math.Max(Size * 0.3, 16);

        output.Attributes.SetAttribute("class", classes);
        output.Attributes.SetAttribute("style", $"width: {Size}px; height: {Size}px; font-size: {fontSize}px;");

        // Direkt HTML içeriği oluşturuyoruz
        output.Content.SetHtmlContent(HtmlEncoder.Default.Encode(initials));
    }
}