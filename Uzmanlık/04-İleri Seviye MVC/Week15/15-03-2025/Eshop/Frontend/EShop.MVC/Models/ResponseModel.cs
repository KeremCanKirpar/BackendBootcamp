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

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    public static ResponseModel<T> Success(T data, int statusCode)
    {
        return new ResponseModel<T>
        {
            Data = data,
            IsSuccessful = true,
            StatusCode = statusCode
        };
    }

    public static ResponseModel<T> Fail(string error, int statusCode)
    {
        return new ResponseModel<T>
        {
            Error = error,
            IsSuccessful = false,
            StatusCode = statusCode
        };
    }
}
