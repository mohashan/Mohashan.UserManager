using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Responses;

public class BaseResponse<T>
{
    public BaseResponse()
    {
        Success = true;
    }
    public BaseResponse(string message)
    {
        Success = true;
        Message = message;
    }

    public BaseResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public BaseResponse(T data)
    {
        Success = true;
        Data = data;
    }

    public BaseResponse(T data, string message)
    {
        Success = true;
        Data = data;
        Message = message;
    }
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> ValidationErrors { get; set; } = new List<string>();
    public T? Data { get; set; }
}
