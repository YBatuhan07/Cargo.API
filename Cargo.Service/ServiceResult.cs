using System.Net;

namespace Cargo.Service;

public class ServiceResult<T> where T : class
{
    public T? Data { get; set; }
    public List<string>? ErrorMessage { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
    public bool IsFail => !IsSuccess;

    public static ServiceResult<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new ServiceResult<T>
        {
            Data = data,
            StatusCode = statusCode
        };
    }

    public static ServiceResult<T> Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult<T>
        {
            ErrorMessage = new List<string> { errorMessage },
            StatusCode = statusCode
        };
    }

    public static ServiceResult<T> Fail(List<string> errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new ServiceResult<T>
        {
            ErrorMessage = errorMessage,
            StatusCode = statusCode
        };
    }
}