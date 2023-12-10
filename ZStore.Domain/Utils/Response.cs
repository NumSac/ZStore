using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZStore.Domain.Utils
{
    public class Response<T>
    {
        public Response()
        {
            Succeeded = false;
            Message = string.Empty;
        }

        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }

        public Response(T data, string message = "")
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(bool succeeded, string? message, List<string>? errors, T? data)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = errors;
            Data = data;
        }

        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }
    }
}
