using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Enums
{
    public enum UserRole
    {
        User,
        Admin
    }

    public enum UserUpdateType
    {
        Password,
        Status,
        Detail,
        Token
    }
}
