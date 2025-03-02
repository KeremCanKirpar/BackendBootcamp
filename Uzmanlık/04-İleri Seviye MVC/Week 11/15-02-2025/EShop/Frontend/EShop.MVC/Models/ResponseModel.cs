using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models;

public class ResponseModel<T>
{
    [JsonPropertyName("data")]
    public T? data { get; set; }

    [JsonPropertyName("error")]
    public string? error { get; set; }

    [JsonPropertyName("isSuccessful")]
    public bool isSuccessful { get; set; }
}
