namespace Autos.Api.Dtos
{
    public class BaseResponse <T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public T? Response { get; set; }

        public static BaseResponse<T> CreateSuccessResponse(T response, string message = "Operation successful", int statusCode = 200)
        {
            return new BaseResponse<T>
            {
                Success = true,
                Message = message,
                StatusCode = statusCode,
                Response = response
            };
        }
        public static BaseResponse<T> CreateErrorResponse(string message, int statusCode = 500)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = message,
                StatusCode = statusCode,
                Response = default
            };
        }
    }
}
