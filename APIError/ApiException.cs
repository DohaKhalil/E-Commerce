namespace E_Commerce.APIError
{
    public class ApiException : ApiResponse
    {
        public string? Details { get; set; }
        public ApiException(int StatuseCode, string? errorMessge = null , string? details = null) : base(StatuseCode, errorMessge)
        {
            Details = details;
        }
    }
}
