using ShoppingCart.Application.DTOs;

namespace ShoppingCart.Application.Common
{
    public static class ServiceResponse
    {
        public static ServiceResponseDto CreateResponse(bool status, string? message, object? data)
        {
            return new ServiceResponseDto
            {
                Status = status,
                Message = message,
                Data = data
            };
        }
    }
}
