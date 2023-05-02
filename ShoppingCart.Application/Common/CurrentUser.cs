using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Common
{
    public class CurrentUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
