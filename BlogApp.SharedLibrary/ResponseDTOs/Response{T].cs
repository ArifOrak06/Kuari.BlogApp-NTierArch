using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogApp.SharedLibrary.ResponseDTOs
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessfull { get; private set; }

        public ErrorDto Error { get; private set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessfull = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, IsSuccessfull = true };
        }

        public static Response<T> Fail(int statusCode, ErrorDto errors)
        {
            return new Response<T> { StatusCode = statusCode, Error = errors, IsSuccessfull = false };
        }

        public static Response<T> Fail(int statusCode, string errorMessage)
        {
            var errorDto = new ErrorDto(errorMessage);
            return new Response<T> { StatusCode = statusCode, Error = errorDto, IsSuccessfull = false };
        }
    }
}
