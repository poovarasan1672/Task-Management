namespace TaskManagementSystem.Common.Responses
{
    public class GenericResponses<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static GenericResponses<T> SuccessResponse(T data, string message = "Success")
        {
            return new GenericResponses<T> { Success = true, Data = data, Message = message };
        }

        public static GenericResponses<T> ErrorResponse(string message)
        {
            return new GenericResponses<T> { Success = false, Message = message };
        }
    }
}
