namespace ShoppingCart.Application.DTOs
{
    public class ServiceResponseDto
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; } = new object();
    }
}
