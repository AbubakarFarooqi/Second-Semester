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
        static void SigningOfUser(ref int ShopIndex)
        {
            char SignOption;
            SignOption = SigningUI.MainMenu();

            if (SignOption == '2')
            {
                CoffeShopCRUD.AddShop(CoffeShopUI.TakeInputOfCoffeShop());
                ShopIndex = (CoffeShopCRUD.getListCount() - 1);
                CoffeShopCRUD.WriteToFile();
            }
            else if (SignOption == '1')
            {
                ShopIndex = CoffeShopCRUD.getThisCoffeShopIndex(SigningUI.TakeSigningInfo());
                if (ShopIndex == -1)
                {
                    SigningUI.WrongMSg();

                }
            }
        }
        static void Option_1(int ShopIndex)
        {
            CoffeShopUI.Header();
            MenuItem Input;
            Input = MenuItemUI.TakeInputOfMenuItem();
            CoffeShopCRUD.ListOfShops[ShopIndex].AddMenuItem(Input);
            MenuItemCRUD.WriteToFile();
            CoffeShopCRUD.WriteToFile();
        }
        static void Option_2(int ShopIndex)
        {
            CoffeShopUI.Header();
            CoffeShopUI.DisplayMessage("The CHeapest Item is " + CoffeShopCRUD.ListOfShops[ShopIndex].CheapestItem());
        }
        static void Option_3(int ShopIndex)
        {
            CoffeShopUI.Header();
            MenuItemUI.HeaderOfDisplayItem();
            List<MenuItem> ListOfDrinks = CoffeShopCRUD.ListOfShops[ShopIndex].DrinkOnly();
            for (int i = 0; i < ListOfDrinks.Count; i++)
            {
                MenuItemUI.DisplayItem(ListOfDrinks[i]);
            }
        }
        static void Option_4(int ShopIndex)
        {
            CoffeShopUI.Header();
            MenuItemUI.HeaderOfDisplayItem();
            List<MenuItem> ListOfFood = CoffeShopCRUD.ListOfShops[ShopIndex].FoodOnly();
            for (int i = 0; i < ListOfFood.Count; i++)
            {
                MenuItemUI.DisplayItem(ListOfFood[i]);
            }
        }
        static void Option_5(int ShopIndex)
        {
            CoffeShopUI.Header();
            MenuItemUI.HeaderOfDisplayItem();
            for (int i = 0; i < CoffeShopCRUD.ListOfShops[ShopIndex].getCountOFListOFMenuItems(); i++)
            {
                MenuItemUI.DisplayItem(CoffeShopCRUD.ListOfShops[ShopIndex].getMenuItem(i));
            }
            string Msg = CoffeShopCRUD.ListOfShops[ShopIndex].AddOrder(CoffeShopUI.PlaceOrder());
            CoffeShopUI.DisplayMessage(Msg);
            MenuItemCRUD.WriteToFile();
            CoffeShopCRUD.WriteToFile();
        }
        static void Option_6(int ShopIndex)
        {
            CoffeShopUI.Header();
            int y;
            for (int i = 0; i < CoffeShopCRUD.ListOfShops[ShopIndex].getOrdersCount(); i++)
            {
                string msg;
                msg = CoffeShopCRUD.ListOfShops[ShopIndex].FulfillOrder(i);
                CoffeShopUI.DisplayMessage(msg);
            }
            CoffeShopCRUD.ListOfShops[ShopIndex].EmptyOrderList();
            CoffeShopCRUD.WriteToFile();
        }
        static void Option_7(int ShopIndex)
        {
            CoffeShopUI.Header();
            List<string> Orders = CoffeShopCRUD.ListOfShops[ShopIndex].ListOrders();
            CoffeShopUI.DisplayMessage("Name");
            for (int i = 0; i < Orders.Count; i++)
            {
                CoffeShopUI.DisplayMessage((i + 1).ToString() + "  " + Orders[i]);
            }
        }
        static void Option_8(int ShopIndex)
        {

            CoffeShopUI.Header();
            CoffeShopUI.DisplayMessage("The Total Payable Amount is = " + CoffeShopCRUD.ListOfShops[ShopIndex].DueAmount().ToString());
        }

        static void Main(string[] args)
        {
            MenuItemCRUD.ReadFromFile();
            CoffeShopCRUD.ReadFromFile();
        again:;
            int ShopIndex = 0;
            SigningUI.Header();
            SigningOfUser(ref ShopIndex);
            if (ShopIndex == -1)
                goto again;
            CoffeShopUI.Header();
            char option;
            do
            {
                CoffeShopUI.Header();
                option = CoffeShopUI.MainMenu();
                switch (option)
                {
                    case '1':
                        Option_1(ShopIndex);
                        break;
                    case '2':
                        Option_2(ShopIndex);
                        break;
                    case '3':
                        Option_3(ShopIndex);
                        break;
                    case '4':
                        Option_4(ShopIndex);
                        break;
                    case '5':
                        Option_5(ShopIndex);
                        break;
                    case '6':
                        Option_6(ShopIndex);
                        break;
                    case '7':
                        Option_7(ShopIndex);
                        break;
                    case '8':
                        Option_8(ShopIndex);
                        break;
                    case '9':
                        CoffeShopUI.DisplayMessage("Thanks For Using Application");
                        break;
                    default:
                        CoffeShopUI.DisplayMessage("Wrong Option");
                        break;
                }
                Console.ReadKey();
            } while (option != '9');
        }
    }
}
