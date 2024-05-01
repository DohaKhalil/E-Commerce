namespace E_Commerce.APIError
{
    public class ApiValidation : ApiResponse
    {
        public ApiValidation() : base(400)
        {
            Errors = new List<string>();
        }

        public IEnumerable<string> Errors { get; set; }

    }
}
