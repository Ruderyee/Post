﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Resturant_Post.Services
{
    class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            System.IO.File.WriteAllLines(@"C:\order.txt", dishes.ToArray());
        }
    }
}
