using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models;

public class ResponseModel<T>
{
    [JsonPropertyName("data")]
    public T? Data { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("isSuccessful")]
    public bool IsSuccessful { get; set; }
}
