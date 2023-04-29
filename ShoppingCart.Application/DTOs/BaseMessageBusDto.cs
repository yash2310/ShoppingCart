using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.DTOs
{
    public class BaseMessageBusDto
    {
        public string Event { get; set; } = string.Empty;
    }
}
