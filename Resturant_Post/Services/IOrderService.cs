using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resturant_Post.Services
{
    interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}
