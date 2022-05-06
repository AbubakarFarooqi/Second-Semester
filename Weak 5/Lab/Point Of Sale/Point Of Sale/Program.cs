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
        static void ReadFromFile()
        {

            string path = "Users.txt";
            StreamReader File = new StreamReader(path);
            string temp = " ";

            while ((temp = File.ReadLine()) != null)
            {
                string ID;
                string Password;
                string Role;
                ID = Extraction_of_Specific_Field(temp, 1);
                Password = Extraction_of_Specific_Field(temp, 2);
                Role = Extraction_of_Specific_Field(temp, 3);
                MUserCRUD.AddUserInList(new MUser(ID, Password, Role));
            }
            File.Close();
        }
        static void WritingToFile(List<MUser> Source)
        {
            string path = "Users.txt";
            StreamWriter File = new StreamWriter(path);
            for (int i = 0; i < Source.Count; i++)
            {
                File.WriteLine(Source[i].getID() + "," + Source[i].getPassword() + "," + Source[i].getRole());
                File.Flush();
            }
            File.Close();
        } // end of populating patient file

        static string Extraction_of_Specific_Field(string Source, int field)
        {
            string output = "";
            int comma = 1;
            for (int i = 0; i < Source.Length; i++)
            {

                if (comma == field)
                {
                    if (Source[i] != ',')
                        output = output + Source[i];
                }
                if (Source[i] == ',')
                    comma++;
            }

            return output;


        }
        static void NeededProducts()
        {
            bool flag = true;

            for (int i = 0; i < ProductCRUD.ListOfProducts.Count; i++)
            {
                if (ProductCRUD.ListOfProducts[i].isNeeded())
                {
                    Ui.DisplayMsg(ProductCRUD.ListOfProducts[i].getName() + " is Needed to be Ordered...");
                    flag = false;
                }
            }
            if (flag)
                Ui.DisplayMsg("Nothing to Order....");
        }
        static int getUserIndex()
        {
            string ID = "";
            string Password = "";
            Ui.DisplayMsg("Enter Your ID....");
            ID = Ui.TakeMsg();
            Ui.DisplayMsg("Enter Your Password....");
            Password = Ui.TakeMsg();
            int Userindex = MUserCRUD.getUserIndex(ID, Password);
            return Userindex;
        }
        static void DisplayAllProducts()
        {

            Ui.DisplayMsg(".....All Products.......");
            Ui.HeaderOfDisplayProduct();
            for (int i = 0; i < ProductCRUD.ListOfProducts.Count; i++)
            {

                string name = ProductCRUD.ListOfProducts[i].getName();
                string category = ProductCRUD.ListOfProducts[i].getCategory();
                float price = ProductCRUD.ListOfProducts[i].getPrice();
                Ui.DisplayProduct(name, category, price);
            }
        }
        static Product BuyProduct()
        {
            Ui.DisplayMsg(" ");
            Ui.DisplayMsg("Which Product You want to buy");
            string option = Ui.TakeMsg();
            int index = int.Parse(option);
            Product temp = ProductCRUD.getProduct(index - 1);
            return temp;
        }
        static void ViewAllProductsSalesTax()
        {
            Ui.DisplayMsg(".......Sales tax of all Products.......");
            for (int i = 0; i < ProductCRUD.ListOfProducts.Count; i++)
            {
                Ui.DisplayMsg((i + 1).ToString() + ".  " + ProductCRUD.ListOfProducts[i].getName() + " With Sales tax " + ProductCRUD.ListOfProducts[i].getSalesTax().ToString());
            }
        }
        static void Main(string[] args)
        {
            ReadFromFile();
            char UserSelectionOption;
            do
            {
                Ui.Header();
                UserSelectionOption = Ui.SigningMenu();
                if (UserSelectionOption == '1')
                {
                    Ui.Header();
                    int Userindex = getUserIndex();
                    if (Userindex != -1)
                    {
                        string WHO;
                        WHO = MUserCRUD.getRole(Userindex);
                        if (WHO == "Cust")
                        {
                            Customer CurrentCustomer = new Customer(MUserCRUD.listOfUsers[Userindex].getID(), MUserCRUD.listOfUsers[Userindex].getPassword());
                            char CustOption;
                            do
                            {
                                Ui.Header();
                                CustOption = Ui.CustomerMenu();
                                if (CustOption == '1')
                                {
                                    Ui.Header();
                                    DisplayAllProducts();
                                }
                                else if (CustOption == '2')
                                {
                                    Ui.Header();
                                    DisplayAllProducts();
                                    Product ChossenProduct = BuyProduct();
                                    ChossenProduct.DecrementInStock();
                                    CurrentCustomer.AddbuyProductInList(ChossenProduct);
                                }
                                else if (CustOption == '3')
                                {
                                    Ui.Header();
                                    Ui.DisplayMsg("You Have To Pay = " + CurrentCustomer.GenerateInvoice().ToString());
                                }
                                Console.ReadKey();
                            } while (CustOption != '4');
                        }
                        else if (WHO == "Admin")
                        {
                            Admin ActorAdmin = new Admin();
                            char AdminOption;
                            do
                            {
                                Ui.Header();
                                AdminOption = Ui.AdminMenu();
                                if (AdminOption == '1')
                                {
                                    Ui.Header();
                                    ActorAdmin.AddProduct(Ui.TakeInputOfProduct());
                                }
                                else if (AdminOption == '2')
                                {
                                    Ui.Header();
                                    DisplayAllProducts();
                                }
                                else if (AdminOption == '3')
                                {
                                    Ui.Header();
                                    Product temp = ActorAdmin.getHigestPriceProduct();
                                    Ui.HeaderOfDisplayProduct();
                                    Ui.DisplayProduct(temp.getName(), temp.getCategory(), temp.getPrice());
                                }
                                else if (AdminOption == '4')
                                {
                                    Ui.Header();
                                    ViewAllProductsSalesTax();
                                }
                                else if (AdminOption == '5')
                                {
                                    Ui.Header();
                                    NeededProducts();
                                }
                                Console.ReadKey();
                            } while (AdminOption != '6');

                        }
                    }
                    else
                        Ui.DisplayMsg("....Wrong Credentials...");
                }
                else if (UserSelectionOption == '2')
                {
                    MUser Input = Ui.TakeInputOfUser();
                    MUserCRUD.AddUserInList(Input);
                    WritingToFile(MUserCRUD.listOfUsers);
                }
                Console.ReadKey();
            } while (UserSelectionOption != '3');
            WritingToFile(MUserCRUD.listOfUsers);
        }
    }
}
