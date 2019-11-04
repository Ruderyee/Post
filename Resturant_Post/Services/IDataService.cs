using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resturant_Post.Models;

namespace Resturant_Post.Services
{
    public interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
