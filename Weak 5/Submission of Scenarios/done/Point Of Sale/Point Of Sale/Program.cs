using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Point_Of_Sale.BL;
using Point_Of_Sale.DL;
using Point_Of_Sale.UI;
namespace Point_Of_Sale
{
    class Program
    {
        static void Cust_Option_1()
        {
            MenuUI.Header();
            CustomerUI.DisplayAllProducts();
        }
        static void Cust_Option_2(int CustNo)
        {

            MenuUI.Header();
            if (ProductCRUD.getProductCount() == 0)
            {
                CustomerUI.NoProduct();
                MenuUI.TakeMsg();
            }
            else
            {
                CustomerUI.DisplayAllProducts();
                Product ChossenProduct = CustomerUI.BuyProduct();
                ChossenProduct.DecrementInStock();
                CustomerCRUD.ListOfCustomers[CustNo].AddbuyProductInList(ChossenProduct);
                ProductCRUD.WriteToFile();
                CustomerCRUD.WriteToFile();
            }
        }
        static void Cust_Option_3(int CustNo)
        {
            MenuUI.Header();
            CustomerUI.PrintInvoice(CustomerCRUD.ListOfCustomers[CustNo].GenerateInvoice());
        }
        static void Admin_Option_1(Admin ActorAdmin)
        {
            MenuUI.Header();
            ActorAdmin.AddProduct(ProductUI.TakeInputOfProduct());
            ProductCRUD.WriteToFile();
        }
        static void Admin_Option_2()
        {
            MenuUI.Header();
            AdminUI.DisplayAllProducts();
        }
        static void Admin_Option_3(Admin ActorAdmin)
        {
            MenuUI.Header();
            Product temp = ActorAdmin.getHigestPriceProduct();
            AdminUI.HeaderOfDisplayProduct();
            AdminUI.DisplayProduct(temp.getName(), temp.getCategory(), temp.getPrice());
        }
        static void Admin_Option_4()
        {
            MenuUI.Header();
            AdminUI.ViewAllProductsSalesTax();
        }
        static void Admin_Option_5()
        {
            MenuUI.Header();
            AdminUI.NeededProducts();
        }
        static void Main(string[] args)
        {
            ProductCRUD.ReadFromFile();
            CustomerCRUD.ReadFromFile();
            MUserCRUD.ReadFromFile();
            char UserSelectionOption;
            do
            {
                MenuUI.Header();
                UserSelectionOption = MenuUI.SigningMenu();
                if (UserSelectionOption == '1')
                {
                    MenuUI.Header();
                    int Userindex = MenuUI.getUserIndex();
                    if (Userindex != -1)
                    {
                        string WHO;
                        WHO = MUserCRUD.getRole(Userindex);
                        if (WHO == "Cust")
                        {
                            int CustNo = CustomerCRUD.getCustomerIndex(MUserCRUD.getUserID(Userindex), MUserCRUD.getUserPassword(Userindex));
                            if (CustNo != -1)
                            {
                                char CustOption;
                                do
                                {
                                    MenuUI.Header();
                                    CustOption = CustomerUI.CustomerMenu();
                                    if (CustOption == '1')
                                    {
                                        Cust_Option_1();
                                    }
                                    else if (CustOption == '2')
                                    {
                                        Cust_Option_2(CustNo);
                                    }
                                    else if (CustOption == '3')
                                    {
                                        Cust_Option_3(CustNo);
                                    }
                                    Console.ReadKey();
                                } while (CustOption != '4');
                            }
                            else
                            {
                                CustomerUI.ErrorMsg();
                            }
                        }
                        else if (WHO == "Admin")
                        {
                            Admin ActorAdmin = new Admin();
                            char AdminOption;
                            do
                            {
                                MenuUI.Header();
                                AdminOption = AdminUI.AdminMenu();
                                if (AdminOption == '1')
                                {
                                    Admin_Option_1(ActorAdmin);
                                }
                                else if (AdminOption == '2')
                                {
                                    Admin_Option_2();
                                }
                                else if (AdminOption == '3')
                                {
                                    Admin_Option_3(ActorAdmin);
                                }
                                else if (AdminOption == '4')
                                {
                                    Admin_Option_4();
                                }
                                else if (AdminOption == '5')
                                {
                                    Admin_Option_5();
                                }
                                Console.ReadKey();
                            } while (AdminOption != '6');

                        }
                    }
                    else
                        MenuUI.DisplayMsg("....Wrong Credentials...");
                }
                else if (UserSelectionOption == '2')
                {
                    MUser Input = MenuUI.TakeInputOfUser();
                    if (Input.getRole() == "Cust")
                    {
                        CustomerCRUD.AddCustomerInList(new Customer(Input.getID(), Input.getPassword()));
                        CustomerCRUD.WriteToFile();
                    }
                    MUserCRUD.AddUserInList(Input);
                    MUserCRUD.WritingToFile();

                }
                Console.ReadKey();
            } while (UserSelectionOption != '3');
            MUserCRUD.WritingToFile();
        }
    }
}
