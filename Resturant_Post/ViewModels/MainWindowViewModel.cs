using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Resturant_Post.Models;
using System.ComponentModel;
using Resturant_Post.Command;
using Resturant_Post.Services;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Resturant_Post.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChange("Count");
            }
        }

        private Resturant resturant;

        public Resturant Resturant
        {
            get { return resturant; }
            set
            {
                resturant = value;
                this.RaisePropertyChange("Resturant");
            }
        }


        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.RaisePropertyChange("DishMenu");
            }
        }

        public MainWindowViewModel()
        {
            this.LoadResturant();
            this.LoadDishMenu();
            //this.PlaceOrderCommand = new DelegateCommand(new Action(this.PlaceOrderCommandExecute));
            this.PlaceOrderCommand = new DelegateCommand();
            this.PlaceOrderCommand.ExecuteAction = new Action<object>(this.PlaceOrderCommandExecute);
            //this.SelectMenuItemCommand = new DelegateCommand(new Action(this.SelectMenuItemExecute));
            this.SelectMenuItemCommand = new DelegateCommand ();
            this.SelectMenuItemCommand.ExecuteAction = new Action<object>(this.SelectMenuItemExecute);
        }

        private void LoadResturant()
        {
            this.resturant = new Resturant();
            this.resturant.Name = "LuShanBo";
            this.resturant.Address = "花蓮市國聯五路一號";
            this.resturant.Number = "0963040636";
        }

        private void LoadDishMenu()
        {
            HardCodeDataService ds = new HardCodeDataService();
            var dishes =ds.GetAllDishes();

            this.DishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }

            //XmlDataService ds = new XmlDataService();
            //var dishes = ds.GetAllDishes();
            //this.DishMenu = new List<DishMenuItemViewModel>();
            //foreach (var dish in dishes)
            //{
            //    DishMenuItemViewModel item = new DishMenuItemViewModel();
            //    item.Dish = dish;
            //    this.DishMenu.Add(item);
            //}
        }

        private void PlaceOrderCommandExecute(object parameter)
        {
            var selectedDishes = this.DishMenu.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("訂餐成功!");
        }

        private void SelectMenuItemExecute(object parameter)
        {
            this.Count = this.DishMenu.Count(i => i.IsSelected == true);
        }
    }
}
