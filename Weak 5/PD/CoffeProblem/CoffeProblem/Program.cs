using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeProblem.BL;
using CoffeProblem.DL;
using CoffeProblem.UI;
namespace CoffeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfShop;
            nameOfShop = ui.TakeInputOfCoffeShop();
            CoffeShopCRUD.AddShop(nameOfShop);
            ui.Header();
            char option;
            do
            {
                ui.Header();
                option = ui.MainMenu();
                switch (option)
                {
                    case '1':
                        ui.Header();
                        MenuItem Input;
                        Input = ui.TakeInputOfMenuItem();
                        CoffeShopCRUD.Shop.AddMenuItem(Input);
                        break;
                    case '2':
                        ui.Header();
                        ui.DisplayMessage("The CHeapest Item is " + CoffeShopCRUD.Shop.CheapestItem());
                        break;
                    case '3':
                        ui.Header();
                        ui.HeaderOfDisplayItem();
                        List<MenuItem> ListOfDrinks = CoffeShopCRUD.Shop.DrinkOnly();
                        for (int i = 0; i < ListOfDrinks.Count; i++)
                        {
                            ui.DisplayItem(ListOfDrinks[i]);
                        }
                        break;
                    case '4':
                        ui.Header();
                        ui.HeaderOfDisplayItem();
                        List<MenuItem> ListOfFood = CoffeShopCRUD.Shop.FoodOnly();
                        for (int i = 0; i < ListOfFood.Count; i++)
                        {
                            ui.DisplayItem(ListOfFood[i]);
                        }
                        break;
                    case '5':
                        ui.Header();
                        ui.HeaderOfDisplayItem();
                        for (int i = 0; i < CoffeShopCRUD.Shop.ListOfMenuItems.Count; i++)
                        {
                            ui.DisplayItem(CoffeShopCRUD.Shop.ListOfMenuItems[i]);
                        }
                        string Msg = CoffeShopCRUD.Shop.AddOrder(ui.PlaceOrder());
                        ui.DisplayMessage(Msg);
                        break;
                    case '6':
                        ui.Header();
                        for (int i = 0; i < CoffeShopCRUD.Shop.Orders.Count; i++)
                        {
                            string msg;
                            msg = CoffeShopCRUD.Shop.FulfillOrder(i);
                            ui.DisplayMessage(msg);
                        }
                        ui.DisplayMessage(CoffeShopCRUD.Shop.FulfillOrder(1));
                        break;
                    case '7':
                        ui.Header();
                        List<string> Orders = CoffeShopCRUD.Shop.ListOrders();
                        ui.DisplayMessage("Name");
                        for (int i = 0; i < Orders.Count; i++)
                        {
                            ui.DisplayMessage((i + 1).ToString() + "  " + Orders[i]);
                        }
                        break;
                    case '8':
                        ui.Header();
                        ui.DisplayMessage("The Total Payable Amount is = " + CoffeShopCRUD.Shop.DueAmount().ToString());
                        break;
                    case '9':
                        ui.DisplayMessage("Thanks For Using Application");
                        break;
                    default:
                        ui.DisplayMessage("Wrong Option");
                        break;
                }
                Console.ReadKey();
            } while (option != '9');
        }
    }
}
