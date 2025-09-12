using mogaERP.Domain.Enums;

namespace mogaERP.Domain.Wrappers;
public class ApiResponse<T>
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public AppStatusCode? StatusCode { get; private set; }
    public T? Result { get; private set; }

    private ApiResponse() { } // Response Immutable

    public static ApiResponse<T> Success(ErrorModel successError, T? value = default)
    {
        ArgumentNullException.ThrowIfNull(successError);

        return new ApiResponse<T>
        {
            IsSuccess = true,
            Message = successError.Message,
            StatusCode = successError.Status,
            Result = value
        };
    }

    public static ApiResponse<T> Failure(ErrorModel error, T? value = default)
    {
        ArgumentNullException.ThrowIfNull(error);

        return new ApiResponse<T>
        {
            IsSuccess = false,
            Message = error.Message,
            StatusCode = error.Status,
            Result = value
        };
    }
}
