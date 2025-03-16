using System.Text.Json.Serialization;

namespace EShop.Shared.Dtos.ResponseDtos
{
    public class ResponseDto<T>
    {
        public T? Data { get; set; }
        public string? Error { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }


        public static ResponseDto<T> Success(T? data, int statusCode)
        {
            return new ResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T>
            {
                Data = default,
                StatusCode = statusCode,
                IsSuccessful = true
            };
        }

        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T>
            {
                Error = error,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }
    }
}
