using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resturant_Post.Models;

namespace Resturant_Post.Services
{
    class HardCodeDataService : IDataService
    {
        public List<Models.Dish> GetAllDishes()
        {
            List<Dish> Dishes = new List<Dish>()
            {
                new Dish() { Name="血腥瑪麗",Category="酒類" , Comment="",Score=3.5},
                new Dish() { Name="長島冰茶",Category="酒類" , Comment="本店招牌",Score=5},
                new Dish() { Name="螺絲起子",Category="酒類" , Comment="",Score=4},
                new Dish() { Name="薯條",Category="餐點" , Comment="",Score=4.1},
                new Dish() { Name="洋蔥圈",Category="餐點" , Comment="本店招牌",Score=5}
             };

            return Dishes;

        }
    }
}
