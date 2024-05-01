
namespace E_Commerce.APIError
{
    public class ApiResponse
    {
        public int Statuse { get; set; }    
        public string ErrorMessge { get; set; }

        public ApiResponse(int StatuseCode , string? errorMessge = null)
        {
            Statuse = StatuseCode;

            ErrorMessge = errorMessge ?? GetMessageForStatuseCode(StatuseCode);
        }

        private string? GetMessageForStatuseCode(int statuseCode)
            => statuseCode switch
            {
                500 => "Internal server Error",
                404 => "Not Found",
                401 => "UnAuothrize",
                400=>"Bad Request",
                _ =>""
            };
      
    }
}
