using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Common
{
    public static class ServiceResponse
    {
        public static ServiceResponseDto CreateResponse(bool status, string message, object? data)
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
