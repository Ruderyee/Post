using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resturant_Post.Models;

namespace Resturant_Post.ViewModels
{
    class DishMenuItemViewModel : NotificationObject
    {
        public Dish Dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChange("IsSelected");
            }
        }
    }
}
