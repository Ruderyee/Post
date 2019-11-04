using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resturant_Post.Models;
using System.Xml.Linq;


namespace Resturant_Post.Services
{
    public class XmlDataService : IDataService
    {
        public List<Models.Dish> GetAllDishes()
        {
            List<Dish> dishlist = new List<Dish>();
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            XDocument xDoc = XDocument.Load(xmlFileName);
           
    
            var dishes = xDoc.Descendants("Dish");
            foreach (var d in dishes)
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = double.Parse(d.Element("Score").Value);
                dishlist.Add(dish);
            }
            return dishlist;
        }
    }


}
