using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HMS_in_C_Sharp
{
    class Program
    {
        static void header()
        {
            Console.Clear();
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////// ");
            Console.WriteLine("**                              Hospital Management System                                    ** ");
            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
            Console.WriteLine();
            Console.WriteLine();

        }//...End of Header
        static char User_Selection_Menu()
        {
            Console.Clear();
            header();
            Console.WriteLine(" --------------------------------------------------------------------------------------------------");
            Console.WriteLine("|     option  |                   				 Discription	        	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    1        |  Admin                             						 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    2        |  Patient                             					         |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    3        |  Doctor                                   		        		 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    4        |  Exit                            						 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------| ");
            char option = ' ';
            option = Console.ReadKey().KeyChar;
            return option;
        }//...End of User Selection Menu

        //........................................................................

        static bool Admin_login(string Admin_ID, string Admin_Password)
        {
            header();
            string ID, Password;





            Console.WriteLine("Enter Admin ID and Password");
            Console.WriteLine("Admin ID: ");
            Console.ReadKey();
            Console.WriteLine("Actual input");
            ID = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Password : ");
            Password = Console.ReadLine();
            if (ID == Admin_ID && Password == Admin_Password)
            {
                return true;
            }
            else
            {
                header();
                Console.WriteLine("Wrong ID or Password");
                Console.WriteLine("Press any key to continue…");
                Console.ReadLine();
                return false;
            }

        }// end of admin login

        //........................................................................  Admin Main Menu.................................................

        static string Admin_Main_Menu()
        {

            string option;

            header();
            Console.WriteLine("Admin > ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("|    option   |                   				 Discription            	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    1        | Add Patient                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    2        | Add Doctor                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    3        | Add Services                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    4        | See Details of all Doctors      						 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    5        | See Details of all Patients                                                   	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    6        | See Doctors list according to increasing order of salary              		 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    7        | Details of Particular Doctor                                   	         	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    8        | Details of Particular Patients                  				 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    9        | See Doctor Status                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    10       | See All Services	                                                         |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    11       | Change Password                                    			         |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    12       | Delete Patient Record	                                                         |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    13       | Delete Doctor Record                                    			         |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    14       | Exit                              						 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine(" Your Option...");

            option = Console.ReadLine();
            return option;
        } // end of admin main menu

        // ........................................................................ Details of Doctor.................................................
        static void Display_Doctor_info(string[] Doctor_Name, string[] Doctor_Speciality, int[] Doctor_Salary, string[] Doctor_ID, int index)
        {
            Console.WriteLine(Doctor_Name[index] + "\t" + Doctor_Speciality[index] + "\t" + Doctor_Salary[index] + "\t" + Doctor_ID[index]);

        }//...End of Display_Doctor_info
         //.................................................................Validation on number type input...............................................

        static bool ValidationOnNumberInput(string source)
        {
            int i = 0;
            while (source[i] != '\0')
            {
                if (!(source[i] >= 48 && source[i] <= 57))
                    return false;
                i++;
            }
            return true;
        }

        //...................................................................... Validation_of_Password.................................................

        static bool Validation_of_Password(string pass)
        {
            int i = 0;

            while (pass[i] != '\0')
            {
                // It will CHeck that password must contain a number
                if (pass[i] >= 48 && pass[i] <= 57)
                {
                    return true;
                }
                i++;
            }
            return false;
        } // Validation_of_Password

        // .......................................................................  Change Password.................................................

        static void Change_Password(string[] Doctor_Password, string[] Patient_Password, string Admin_Password, int user, int index = 0)
        {

            header();
            string pass;

            if (user == 1) // for admin
            {
                Console.WriteLine("Admin > Change Password");

                Console.WriteLine("Passwrod Must Contain a Number...");
                Console.WriteLine("Enter New Password... ");

                pass = Console.ReadLine();

                if (Validation_of_Password(pass))
                {
                    Admin_Password = pass;
                    Console.WriteLine("The Password Has been Succesfully Changed...");
                }
                else
                    Console.WriteLine("Password is not Valid...");
            }
            if (user == 2) // for Patient
            {
                Console.WriteLine("Patient > Change Password");

                Console.WriteLine("Passwrod Must Contain a Number...");
                Console.WriteLine("Enter New Password... ");
                pass = Console.ReadLine();

                if (Validation_of_Password(pass))
                {
                    Patient_Password[index] = pass;
                    Console.WriteLine(
                           "The Password Has been Succesfully Changed..."
                           );
                }
                else
                    Console.WriteLine("Password is not Valid...");
            }
            if (user == 3) // for Doctor
            {
                Console.WriteLine("Doctor > Change Password");
                Console.WriteLine("Passwrod Must Contain a Number...");
                Console.WriteLine("Enter New Password... ");
                pass = Console.ReadLine();

                if (Validation_of_Password(pass))
                {
                    Doctor_Password[index] = pass;
                    Console.WriteLine(
                           "The Password Has been Succesfully Changed..."
                           );
                }
                else
                    Console.WriteLine("Password is not Valid...");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        } // end of Change_Password

        // ........................................................................ Details of Patient.................................................

        static void Display_Patient_info(string[] Patient_Name, string[] Patient_Disease, string[] Patient_Doc_ID, string[] Patient_ID, int index)
        {
            Console.WriteLine(Patient_Name[index] + "\t" + Patient_Disease[index] + "\t" + Patient_Doc_ID[index] + "\t" + Patient_ID[index]);

        } // End of PAtient info

        // ........................................................................ See Doctor Status.................................................


        static void Doc_Status(string[] Doctor_Name, string[] Doctor_Status, string[] Doctor_ID, int index)
        {
            Console.WriteLine(Doctor_Name + "\t" + Doctor_Status + "\t" + Doctor_ID);
        } // End of doc status

        // ........................................................................ Display Services.................................................

        static void Display_Services(string[] Service_Name, int[] Service_Fee, int index)
        {
            Console.WriteLine(Service_Name[index] + "\t" + Service_Fee[index]);

        } // end of dislay services


        static void Recommend_Doctor(string[] Doctor_Speciality, int Doctor_Counter, string[] Doctor_ID, string[] Doctor_Name, string Disease)
        {
            bool flag = true; // if it is true then no doctor is availbe for recomendation
            for (int i = 0; i < Doctor_Counter; i++)
            {
                if (Doctor_Speciality[i] == Disease)
                {
                    Console.WriteLine("Doctor " + "\t" + Doctor_Name[i] + "\t" + " with ID : " + "\t" + Doctor_ID[i] + "\t" + " is recommended for this patient");
                    flag = false;
                    break;
                }
            }
            if (flag)

                Console.WriteLine("No recommendations availabe...");

        } // End of Recommend Doctor

        // ........................................................................   Add Patient.................................................


        static void Add_Patient(string[] Patient_Name, string[] Patient_Disease, string[] Patient_Doc_ID, string[] Patient_ID, string[] Patient_Password, string[] Doctor_Speciality, int Doctor_Counter, string[] Doctor_ID, string[] Doctor_Name, ref int Patient_Counter)
        {
            header();
            Console.WriteLine("Admin > Add Patient");

            Console.Write("Enter Patient Name : ");

            Patient_Name[Patient_Counter] = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter Patient Disease : ");
            Patient_Disease[Patient_Counter] = Console.ReadLine();
            Console.WriteLine();
            Recommend_Doctor(Doctor_Speciality, Doctor_Counter, Doctor_ID, Doctor_Name, Patient_Disease[Patient_Counter]);

            Console.WriteLine("Enter Patient's Doctor ID : ");

            Patient_Doc_ID[Patient_Counter] = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Assign ID to Patient : ");
            Patient_ID[Patient_Counter] = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Assign Password : ");
            string pass;
            pass = Console.ReadLine();


            //.............validaiton on password............

            if (Validation_of_Password(pass))
            {
                Patient_Password[Patient_Counter] = pass;

                //.........CHECKING FOR UNIQUENESS IN ID............

                if (Patient_Counter > 0)
                {
                    bool flag = true;
                    for (int i = Patient_Counter - 1; i >= 0; i--)
                    {

                        if (Patient_Counter == 0)
                            continue;
                        if (Patient_ID[Patient_Counter] == Patient_ID[i])
                        {

                            Patient_Counter--;
                            Console.Clear();// remain
                            header();
                            Console.WriteLine("Admin > Add Patients");
                            Console.WriteLine("You Cannot Add Patients  with same ID. ");
                            Console.WriteLine(
                                 "Press any key to continue… ");
                            flag = false;
                            Console.ReadKey();
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("The patient has been Added");
                        Console.WriteLine(

                            "Press any key to continue… ");
                        Console.ReadKey();
                    }
                }

                Patient_Counter++;
            }

            else
            {

                Console.WriteLine(
                    "Password is not Valid...");
                Console.WriteLine("PAssword must contain a number...");
                Console.WriteLine(
                    "Press any key to continue… ");
                Console.ReadKey();
            }

        } //...End of Add patient

        //........................................................................... Add Services.................................................


        static void Add_Services(string[] Service_Name, int[] Service_Fee, ref int Service_Counter)
        {
            header();
            Console.WriteLine("Admin > Add services");

            Console.WriteLine("Enter Service Name : ");

            Service_Name[Service_Counter] = Console.ReadLine();

            Console.WriteLine("Enter Service Fee : ");
            string fee;
            fee = Console.ReadLine();
            if (ValidationOnNumberInput(fee))
            {
                Service_Fee[Service_Counter] = int.Parse(fee);
                Console.WriteLine("The Service Has been Added");
                Service_Counter++;
            }
            else
            {
                Console.WriteLine(

                     "Fee Must contain only a Number....");
            }
            Console.WriteLine(

                 "Press any key to continue… ");
            Console.ReadKey();

        } // End of Add Services

        // .........................................................................Sorting of Doctors.................................................


        static void Sorting_Doctors(int[] Doctor_Salary, string[] Doctor_Name, string[] Doctor_Speciality, string[] Doctor_ID, int Doctor_Counter)
        {
            /* temporary arrays for storing values of DOctor_salary and their respective indices */

            // I use this logic it prevent my original array from rearranging
            int[] temp = new int[Doctor_Counter];
            int[] index = new int[Doctor_Counter];

            //....................................................................................

            // filling of index
            for (int i = 0; i < Doctor_Counter; i++)
            {
                index[i] = i;
            }

            // filling of temp
            for (int i = 0; i < Doctor_Counter; i++)
            {
                temp[i] = Doctor_Salary[i];
            }

            // sorting indices in index array
            for (int i = 0; i < Doctor_Counter; i++)
            {
                for (int j = 0; j < Doctor_Counter - 1; j++)
                {
                    int tempValue = temp[j];
                    int tempIndex = index[j];
                    if (temp[j] < temp[j + 1])
                    {
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tempValue;
                        index[j] = index[j + 1];
                        index[j + 1] = tempIndex;
                    }
                }
            }
            // Printing Sorted List of doctors

            Console.Write("Name\t");

            Console.Write("Speciality\t");

            Console.Write("Salary\t");

            Console.WriteLine("ID");

            for (int i = 0; i < Doctor_Counter; i++)
            {
                Display_Doctor_info(Doctor_Name, Doctor_Speciality, Doctor_Salary, Doctor_ID, index[i]);
            }
        } // End of Sorting Doctors

        // ...........................................................................Add Doctor.................................................

        static void Add_Doctor(string[] Doctor_Name, string[] Doctor_Speciality, string[] Doctor_ID, string[] Doctor_Password, string[] Doctor_Status, int[] Doctor_Salary, ref int Doctor_Counter)
        {

            header();
            Console.WriteLine("Admin > Add Doctor");

            Console.WriteLine("Enter Doctor Name : ");

            Doctor_Name[Doctor_Counter] = Console.ReadLine();

            Console.WriteLine(
                 "Enter Doctor's Speciality : ");
            Doctor_Speciality[Doctor_Counter] = Console.ReadLine();

            Console.WriteLine(
                  "Enter Doctor's Salary  : ");
            string salary;
            salary = Console.ReadLine();

            //..............validaiton on salary...............

            if (ValidationOnNumberInput(salary))
            {
                Doctor_Salary[Doctor_Counter] = int.Parse(salary);

                Console.WriteLine(
                      "Enter Doctor's Status  : ");

                Doctor_Status[Doctor_Counter] = Console.ReadLine();
                Console.WriteLine(
                      "Assign ID to Doctor : ");
                Doctor_ID[Doctor_Counter] = Console.ReadLine();
                string pass;
                Console.WriteLine(
                      "Assign Password : ");
                pass = Console.ReadLine();

                //.............validaiton on password............

                if (Validation_of_Password(pass))
                {
                    Doctor_Password[Doctor_Counter] = pass;

                    //.........CHECKING FOR UNIQUENESS IN ID............

                    if (Doctor_Counter > 0)
                    {
                        bool flag = true;
                        for (int i = Doctor_Counter - 1; i >= 0; i--)
                        {

                            if (Doctor_Counter == 0)
                                continue;
                            if (Doctor_ID[Doctor_Counter] == Doctor_ID[i])
                            {

                                Doctor_Counter--;
                                Console.Clear();
                                header();
                                Console.WriteLine("Admin > Add Doctors");
                                Console.WriteLine(
                                     "You Cannot Add Doctors  with same ID. ");
                                Console.WriteLine("Press any key to continue… ");
                                flag = false;
                                Console.ReadKey();
                            }
                        }
                        if (flag)
                        {
                            Console.WriteLine("The Doctor has been Added");
                            Console.WriteLine(
                                 "Press any key to continue… ");
                            Console.ReadKey();
                        }
                    }

                    Doctor_Counter++;
                }
                else
                {
                    Console.WriteLine(
                          "Password is not Valid...");
                    Console.WriteLine("PAssword must contain a number...");
                    Console.WriteLine(
                         "Press any key to continue… ");
                    Console.ReadKey();
                }//remain
            }
            else
            {
                Console.WriteLine(
                      "Salary Must be  numbers only...");
                Console.WriteLine(
                      "Press any key to continue… ");
                Console.ReadKey();
            }

        } //...End of Add_Doctor

        //........................................................................... Doctor_Login.................................................

        static int Doctor_Login(int Doctor_Counter, string[] Doctor_ID, string[] Doctor_Password)
        {
            header();
            string ID, Password;
            Console.WriteLine("Enter Doctor ID and Password");

            Console.WriteLine("Doctor ID : ");

            ID = Console.ReadLine();

            Console.WriteLine("Password : ");
            Password = Console.ReadLine();

            //...........Checking whether doctor exist or not...........

            for (int i = 0; i < Doctor_Counter; i++)
            {
                if (ID == Doctor_ID[i] && Password == Doctor_Password[i])
                    return i;
            }
            return -1;

        } // End of Doctor login

        // ...........................................................................Doctor Main_menu.................................................


        static char Doctor_Main_Menu()
        {
            header();

            Console.WriteLine("Doctor > ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("|    option   |                   				 Discription            	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    1        | My Details                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    2        | Patient Details                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    3        | All Services                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    4        | Change Status     						                 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    5        | Change Password                                                               	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    6        | Exit                                                                      	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine(" Your Option...");

            char option;
            option = char.Parse(Console.ReadLine());

            return option;
        } // ENd of Doctor MAin menu

        // ...........................................................................Patient Login.................................................

        static int Patient_Login(int Patient_Counter, string[] Patient_ID, string[] Patient_Password)
        {
            header();
            string ID, Password;
            Console.WriteLine("Enter Patient ID and Password");

            Console.WriteLine("Patient ID : ");
            ID = Console.ReadLine();

            Console.WriteLine("Password : ");
            Password = Console.ReadLine();

            //...........Checking whether doctor exist or not...........

            for (int i = 0; i < Patient_Counter; i++)
            {
                if (ID == Patient_ID[i] && Password == Patient_Password[i])
                    return i;
            }
            return -1;

        } // End of PAtient login

        //........................................................................... Paient Main Menu.................................................

        static char Patient_Main_Menu()
        {
            header();

            Console.WriteLine("Patient > ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("|    option   |                   				 Discription            	 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    1        | My Details                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    2        | Doctor Status                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    3        | All Services                              					 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    4        | Change Password   				                                 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    5        | Exit     						                         |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine(" Your Option...");

            char option;
            option = Console.ReadLine()[0];

            return option;
        } // ENd of Patient main menu




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


        } // End of Extraction of SPecific Field

        //...................................................................Populatiing Patient's Data Structures from File.................................................

        static void Populating_Patient_Structures(string[] Patient_Name, string[] Patient_Disease, string[] Patient_Doc_ID, string[] Patient_ID, string[] Patient_Password, ref int Patient_Counter)
        {

            string path = "Patients.txt";
            StreamReader patientFile = new StreamReader(path);
            string temp = " ";

            while ((temp = patientFile.ReadLine()) != null) //.........................control goes inside If file is not empty
            {

                //.........................................................................................................
                Console.WriteLine(temp);
                Patient_Name[Patient_Counter] = Extraction_of_Specific_Field(temp, 1);
                Patient_Disease[Patient_Counter] = Extraction_of_Specific_Field(temp, 2);
                Patient_Doc_ID[Patient_Counter] = Extraction_of_Specific_Field(temp, 3);
                Patient_ID[Patient_Counter] = Extraction_of_Specific_Field(temp, 4);
                Patient_Password[Patient_Counter] = Extraction_of_Specific_Field(temp, 5);
                Patient_Counter++;

            }
            patientFile.Close();
        } // End of Populating PAtient Structures


        static void Populating_Doctor_Structures(string[] Doctor_Name, string[] Doctor_Speciality, int[] Doctor_Salary, string[] Doctor_Status, string[] Doctor_ID, string[] Doctor_Password, ref int Doctor_Counter)
        {

            string path = "Doctors.txt";
            string temp = " ";
            StreamReader DoctorFile = new StreamReader(path);
            //............................cheking whether file is empty or not...........

            while ((temp = DoctorFile.ReadLine()) != null)
            {


                Doctor_Name[Doctor_Counter] = Extraction_of_Specific_Field(temp, 1);
                Doctor_Speciality[Doctor_Counter] = Extraction_of_Specific_Field(temp, 2);
                Doctor_Salary[Doctor_Counter] = int.Parse((Extraction_of_Specific_Field(temp, 3)));
                Doctor_Status[Doctor_Counter] = Extraction_of_Specific_Field(temp, 4);
                Doctor_ID[Doctor_Counter] = Extraction_of_Specific_Field(temp, 5);
                Doctor_Password[Doctor_Counter] = Extraction_of_Specific_Field(temp, 6);
                Doctor_Counter++;

            }
            DoctorFile.Close();
        } // ENd of populating Doctor Structures

        // ........................................................................populating File with Doctors info.................................................



        static void Populating_Doctor_File(string[] Doctor_Name, string[] Doctor_Speciality, int[] Doctor_Salary, string[] Doctor_Status, string[] Doctor_ID, string[] Doctor_Password, ref int Doctor_Counter)
        {

            string path = "Doctors.txt";
            StreamWriter DoctorFile = new StreamWriter(path);
            for (int i = 0; i < Doctor_Counter; i++)
            {
                DoctorFile.WriteLine(Doctor_Name[i] + "," + Doctor_Speciality[i] + "," + Doctor_Salary[i] + "," + Doctor_Status[i] + "," + Doctor_ID[i] + "," + Doctor_Password[i]);

            }

            DoctorFile.Close();
        } // ENd of populating doctor file

        // .......................................................................populating File with PAtients info.................................................

        static void Populating_Patient_File(string[] Patient_Name, string[] Patient_Disease, string[] Patient_Doc_ID, string[] Patient_ID, string[] Patient_Password, ref int Patient_Counter)
        {

            string path = "Patients.txt";
            StreamWriter patientFile = new StreamWriter(path);
            for (int i = 0; i < Patient_Counter; i++)
            {
                patientFile.WriteLine(Patient_Name[i] + "," + Patient_Disease[i] + "," + Patient_Doc_ID[i] + "," + Patient_ID[i] + "," + Patient_Password[i]);

            }

            patientFile.Close();
        } // end of populating patient file

        // .......................................................................Extraction of Admin password from file.................................................

        static void Extraction_of_Admin_password(ref string Admin_Password)
        {
            string path = "Admin.txt";
            StreamReader adminFile = new StreamReader(path);
            string temp = "";
            if ((temp = adminFile.ReadLine()) != null) //.........................control goes inside If file is not empty
            {

                Admin_Password = temp;
            }
            adminFile.Close();
        } // end of extraction of admin password

        //........................................................................Storing admin password in file.................................................

        static void Store_Admin_password(string Admin_Password)
        {
            string path = "Admin.txt";
            StreamWriter adminFile = new StreamWriter(path);
            adminFile.WriteLine(Admin_Password);
            adminFile.Close();
        } // ENd of store Admin PAssword

        //......................................................................    Populating File with Services.................................................

        static void Populating_Service_File(int Service_Counter, string[] Service_Name, int[] Service_Fee)
        {
            string path = "Services.txt";
            StreamWriter serviceFile = new StreamWriter(path);
            for (int i = 0; i < Service_Counter; i++)
            {
                serviceFile.WriteLine(Service_Name[i] + "," + Service_Fee[i]);

            }

            serviceFile.Close();
        } // end of populating Service File

        //......................................................................Populating Service Structures from file.................................................


        static void Populating_Service_Structures(string[] Service_Name, int[] Service_Fee, ref int Service_Counter)
        {
            StreamReader serviceFile = new StreamReader("Services.txt");
            string temp = " ";


            while ((temp = serviceFile.ReadLine()) != null)
            {



                //.........................................................................................................

                Service_Name[Service_Counter] = Extraction_of_Specific_Field(temp, 1);
                Service_Fee[Service_Counter] = int.Parse((Extraction_of_Specific_Field(temp, 2)));
                Service_Counter++;

            }
            serviceFile.Close();
        } // end Populating_Service_Structures()

        //........................................................................... Start of main.................................................

        static void DeletePatientRecord(string[] Patient_Name, string[] Patient_Disease, string[] Patient_Doc_ID, string[] Patient_ID, string[] Patient_Password, ref int Patient_Counter, int Patient_Number)
        {
            for (int i = Patient_Number; i < Patient_Counter; i++)
            {
                string temp = " ";
                Patient_Name[i] = Patient_Name[i + 1];
                Patient_Disease[i] = Patient_Disease[i + 1];
                Patient_Doc_ID[i] = Patient_Doc_ID[i + 1];
                Patient_ID[i] = Patient_ID[i + 1];
                Patient_Password[i] = Patient_Password[i + 1];
            }
            Patient_Counter--;
        }

        static void DeleteDoctorRecord(string[] Doctor_Name, string[] Doctor_Speciality, int[] Doctor_Salary, string[] Doctor_ID, string[] Doctor_Password, string[] Doctor_Status, ref int Doctor_Counter, int Doctor_Number)
        {
            for (int i = Doctor_Number; i < Doctor_Counter; i++)
            {
                string temp = " ";
                Doctor_Name[i] = Doctor_Name[i + 1];
                Doctor_Speciality[i] = Doctor_Speciality[i + 1];
                Doctor_Salary[i] = Doctor_Salary[i + 1];
                Doctor_ID[i] = Doctor_ID[i + 1];
                Doctor_Password[i] = Doctor_Password[i + 1];
                Doctor_Salary[i] = Doctor_Salary[i + 1];
            }
            Doctor_Counter--;
        }
        static void Main(string[] args)
        {
            const int SIZE = 100;
            //.............................................................Variables for admin.............................
            string Admin_ID = "PF";
            string Admin_Password = "2021";
            //............................................................Data Structures For Patient..........................

            string[] Patient_Name = new string[SIZE];
            string[] Patient_Disease = new string[SIZE];
            string[] Patient_Doc_ID = new string[SIZE];
            string[] Patient_ID = new string[SIZE];
            string[] Patient_Password = new string[SIZE];
            int Patient_Counter = 0;

            //............................................................. Data Structures For Doctor.........................

            string[] Doctor_Name = new string[SIZE];
            string[] Doctor_Speciality = new string[SIZE];
            int[] Doctor_Salary = new int[SIZE];
            string[] Doctor_ID = new string[SIZE];
            string[] Doctor_Password = new string[SIZE];
            string[] Doctor_Status = new string[SIZE];
            int Doctor_Counter = 0;

            //............................................................. Data Structures For Services..........................

            string[] Service_Name = new string[SIZE];
            int[] Service_Fee = new int[SIZE];
            int Service_Counter = 0;




            //...................Filling oF all Data Structures From FIle....................

            Populating_Service_Structures(Service_Name, Service_Fee, ref Service_Counter);
            Extraction_of_Admin_password(ref Admin_Password);
            Populating_Doctor_Structures(Doctor_Name, Doctor_Speciality, Doctor_Salary, Doctor_Status, Doctor_ID, Doctor_Password, ref Doctor_Counter);
            Populating_Patient_Structures(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, Patient_Password, ref Patient_Counter);

            //................................................................................

            char option = ' '; // It will store USer type

            while (option != '4')
            {
                header();
                option = User_Selection_Menu();

                //.....................If user enter wrong input in selecting user............

                //.............................................................................

                // Selection According Value of option Variable

                if (option == '1') // For Admin
                {
                    string admin_option = "1"; // For storing admin selected option
                    header();

                    if (Admin_login(Admin_ID, Admin_Password))
                    {
                        while (admin_option != "14")
                        {
                            header();
                            admin_option = Admin_Main_Menu();

                            if (admin_option == "1")
                            {
                                Add_Patient(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, Patient_Password, Doctor_Speciality, Doctor_Counter, Doctor_ID, Doctor_Name, ref Patient_Counter);
                            } //.....ENd of Option 1

                            else if (admin_option == "2")
                            {
                                Add_Doctor(Doctor_Name, Doctor_Speciality, Doctor_ID, Doctor_Password, Doctor_Status, Doctor_Salary, ref Doctor_Counter);
                            } //.....ENd of Option 2

                            else if (admin_option == "3")
                            {
                                Add_Services(Service_Name, Service_Fee, ref Service_Counter);
                            } //.....ENd of Option 3

                            else if (admin_option == "4")
                            {

                                header();

                                if (Doctor_Counter == 0) // If no Doctor is Added
                                {
                                    Console.WriteLine("Admin > See Details of All Doctors\n " + "No Record Found...");

                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Doctors");
                                    Console.WriteLine("Name\tSpeciality\tSalary\tID");

                                    for (int i = 0; i < Doctor_Counter; i++)
                                    {
                                        Display_Doctor_info(Doctor_Name, Doctor_Speciality, Doctor_Salary, Doctor_ID, i);
                                    }
                                }
                                Console.WriteLine("Press Any Key to Continue...");
                                Console.ReadKey();
                            } //.....ENd of Option 4

                            else if (admin_option == "5")
                            {
                                header();

                                if (Patient_Counter == 0) // If no patient is added
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("Name\tDisease\tDoc ID\tID");

                                    for (int i = 0; i < Patient_Counter; i++)
                                        Display_Patient_info(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, i);
                                }
                                Console.WriteLine("Press Any Key to Continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 5

                            else if (admin_option == "6")
                            {
                                header();

                                if (Doctor_Counter == 0) // if no Doctor is added
                                {
                                    Console.WriteLine("Admin > Details of Doctors according to increasing order of salary..");
                                    Console.WriteLine("Record Not Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > Details of Doctors according to increasing order of salary..");
                                    Sorting_Doctors(Doctor_Salary, Doctor_Name, Doctor_Speciality, Doctor_ID, Doctor_Counter);
                                }
                                Console.WriteLine(
                                     "Press Any Key To Continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 6

                            else if (admin_option == "7")
                            {
                                header();
                                bool flag = false; // If it is false then ID will be wrong

                                Console.WriteLine("Admin > Details of Particular Doctor");
                                string ID;
                                Console.Write("Enter Doctor's ID : ");

                                ID = Console.ReadLine();

                                Console.WriteLine("Name\tSpeciality\tSalary\tID");


                                for (int i = 0; i < Doctor_Counter; i++)
                                {
                                    if (ID == Doctor_ID[i]) // If user enter right ID
                                    {
                                        Display_Doctor_info(Doctor_Name, Doctor_Speciality, Doctor_Salary, Doctor_ID, i);
                                        flag = true;
                                    }
                                }

                                if (flag == false)
                                {
                                    header();
                                    Console.WriteLine("Admin > Details of Particular Doctor");
                                    Console.WriteLine("Record Not Found...");
                                }
                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 7

                            else if (admin_option == "8")
                            {

                                header();
                                bool flag = false; // If it is false then ID will be wrong

                                Console.WriteLine("Admin > Details of Particular Patient");
                                string ID;

                                Console.Write("Enter Patient's ID : ");

                                ID = Console.ReadLine();

                                Console.WriteLine("Name\tDisease\tDoc ID\tID");



                                for (int i = 0; i < Patient_Counter; i++)
                                {
                                    if (ID == Patient_ID[i]) // If user enter right ID
                                    {
                                        Display_Patient_info(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, i);
                                        flag = true;
                                    }
                                }

                                if (flag == false)
                                {
                                    header();
                                    Console.WriteLine("Admin > Details of Particular Patient");
                                    Console.WriteLine("Record Not Found...");
                                }
                                Console.Write("Press Any Key To continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 8

                            else if (admin_option == "9")
                            {
                                header();
                                bool flag = false; // If it is false then ID will be wrong
                                Console.WriteLine("Admin > Doctor Status");
                                string ID;

                                Console.Write("Enter Doctor's ID : ");

                                ID = Console.ReadLine();

                                Console.WriteLine("Name\tStatus\tID");


                                for (int i = 0; i < Doctor_Counter; i++)
                                {
                                    if (ID == Doctor_ID[i]) // If user enter right ID
                                    {
                                        Doc_Status(Doctor_Name, Doctor_Status, Doctor_ID, i);
                                        flag = true;
                                    }
                                }
                                if (flag == false)
                                {
                                    header();
                                    Console.WriteLine("Admin > Doctor Status\nNo Record Found...");

                                }
                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 9

                            else if (admin_option == "10")
                            {
                                header();
                                Console.WriteLine("Admin > See All Services :");

                                if (Service_Counter == 0) // If no Service is added yets
                                {
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {


                                    Console.WriteLine("Name\tFee");

                                    for (int i = 0; i < Service_Counter; i++)
                                        Display_Services(Service_Name, Service_Fee, i);
                                }
                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 10

                            else if (admin_option == "11")
                            {
                                Change_Password(Doctor_Password, Patient_Password, Admin_Password, 1);
                            } //.....ENd of Option 11
                            else if (admin_option == "12")
                            {
                                header();

                                if (Patient_Counter == 0) // If no patient is added
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("Name\tDisease\tDoc ID\tID");

                                    for (int i = 0; i < Patient_Counter; i++)
                                        Display_Patient_info(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, i);
                                }
                                Console.WriteLine("Which Paient You want to Delete");
                                int Patient_Number = int.Parse(Console.ReadLine());
                                DeletePatientRecord(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, Patient_Password, ref Patient_Counter, Patient_Number - 1);
                            }
                            else if (admin_option == "13")
                            {
                                header();

                                if (Patient_Counter == 0) // If no patient is added
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("Name\tDisease\tDoc ID\tID");

                                    for (int i = 0; i < Patient_Counter; i++)
                                        Display_Patient_info(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, i);
                                    Console.WriteLine("Which Doctor You want to Delete");
                                    int Doctor_Number = int.Parse(Console.ReadLine());
                                    DeleteDoctorRecord(Doctor_Name, Doctor_Speciality, Doctor_Salary, Doctor_ID, Doctor_Password, Doctor_Status, ref Doctor_Counter, Doctor_Number - 1);
                                }
                            }
                        } //..End of Admin While Loop


                    } //..End of IF ( admin_login () )
                    else
                        continue;

                } //......end of Admin If

                else if (option == '2') // FOr PAtient
                {
                    char Patient_Option = '1'; // For storing PAtient selected option
                    header();

                    int Patient_number = Patient_Login(Patient_Counter, Patient_ID, Patient_Password); // it return -1 if password is incorrect

                    if (Patient_number != -1)
                    {
                        while (Patient_Option != '5')
                        {
                            header();
                            Patient_Option = Patient_Main_Menu();

                            if (Patient_Option == '1')
                            {
                                header();
                                Console.WriteLine("Patient > My Details");

                                Console.WriteLine("Name\tDisease\tDoc ID\tID");


                                Display_Patient_info(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, Patient_number);

                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();
                            } //...End of option 1

                            else if (Patient_Option == '2')
                            {
                                header();
                                Console.WriteLine("Patient > Doctor Status");
                                string ID;

                                Console.Write("Enter Doctor's ID : ");

                                ID = Console.ReadLine();

                                Console.WriteLine("Name\tStatus\tID");


                                bool flag = false; // if its value is false then entered ID will be wrong

                                for (int i = 0; i < Doctor_Counter; i++)
                                {
                                    if (ID == Doctor_ID[i])
                                    {
                                        Doc_Status(Doctor_Name, Doctor_Status, Doctor_ID, i);
                                        flag = true;
                                    }
                                }

                                if (flag == false)
                                {
                                    header();
                                    Console.WriteLine("Patient > Doctor Status");
                                    Console.WriteLine("No Record Found...");
                                }

                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();

                            } //...End of option 2

                            else if (Patient_Option == '3')
                            {
                                header();
                                Console.WriteLine("Patient > See All Services :");

                                if (Service_Counter == 0) // If no Service is added yet
                                {
                                    Console.WriteLine("No Record Found...");
                                }

                                else
                                {

                                    Console.WriteLine("Name\tFEE");

                                    for (int i = 0; i < Service_Counter; i++)
                                        Display_Services(Service_Name, Service_Fee, i);
                                }

                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //...End of option 3

                            else if (Patient_Option == '4')
                            {
                                Change_Password(Doctor_Password, Patient_Password, Admin_Password, 2, Patient_number);
                            } //...End of option 4

                            else if (option == '5')
                            {
                                break;
                            } //...End of option 5

                        } //...End of PAtient While

                    } // End of Patient_number != -1

                    else // If ID or PAssword is incorrect
                    {
                        header();
                        Console.WriteLine("Wrong ID or Password");
                        Console.WriteLine("Press any key to continue…");
                        Console.ReadKey();
                    }

                } //.......... End of PAtient IF

                else if (option == '3') // FOr Doctor
                {
                    char Doctor_option = '1'; // SFor storing PAtient selected option
                    header();

                    int Doctor_Number = Doctor_Login(Doctor_Counter, Doctor_ID, Doctor_Password);

                    if (Doctor_Number != -1) // it return -1 if password is incorrect
                    {
                        while (Doctor_option != '6')
                        {
                            header();
                            Doctor_option = Doctor_Main_Menu();

                            if (Doctor_option == '1')
                            {
                                header();
                                Console.WriteLine("Doctor > My Details");

                                Console.WriteLine("Name\tSpeciality\tSalary\tID");


                                Display_Doctor_info(Doctor_Name, Doctor_Speciality, Doctor_Salary, Doctor_ID, Doctor_Number);

                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();
                            } //...ENd of option 1

                            else if (Doctor_option == '2')
                            {
                                header();
                                Console.WriteLine("Doctor > Patient Details");
                                string ID;

                                Console.Write("Enter Patient's ID : ");
                                ID = Console.ReadLine();

                                Console.WriteLine("Name\tDisease\tDoc ID\tID");


                                bool flag = false; // if its value is false then entered ID will be wrong

                                for (int i = 0; i < Patient_Counter; i++)
                                {
                                    if (ID == Patient_ID[i])
                                    {
                                        Display_Patient_info(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, i);
                                        flag = true;
                                    }
                                }

                                if (flag == false)
                                {
                                    header();
                                    Console.WriteLine("Doctor > Patient Details");
                                    Console.WriteLine("No Record Found..");
                                }
                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();
                            } //...ENd of option 2

                            else if (Doctor_option == '3')
                            {
                                header();
                                Console.WriteLine("Doctor > See All Services :");

                                if (Service_Counter == 0) // If no Service is added yet
                                {
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {

                                    Console.WriteLine("Name\tFEE");

                                    for (int i = 0; i < Service_Counter; i++)
                                        Display_Services(Service_Name, Service_Fee, i);
                                }

                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //...ENd of option 3

                            else if (Doctor_option == '4')
                            {
                                header();
                                Console.WriteLine("Doctor > Change Status");
                                Console.WriteLine("Your Current Status :\t " + Doctor_Status[Doctor_Number]);
                                Console.Write("Your New Status : ");

                                Doctor_Status[Doctor_Number] = Console.ReadLine();
                                Console.WriteLine("The Status has been Changed");
                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();
                            } //...ENd of option 4

                            else if (Doctor_option == '5')
                            {
                                Change_Password(Doctor_Password, Patient_Password, Admin_Password, 3, Doctor_Number);
                            } //...ENd of option 5

                        } //..End of Doctor While Loop

                    } //.. End of Doctor_Number != -1

                    else // If ID or PAssword is incorrect
                    {

                        header();
                        Console.WriteLine("Wrong ID or Password");
                        Console.WriteLine("Press any key to continue…");
                        Console.ReadKey();
                    }

                } //..End of DOctor IF

                else if (option == 4) // FOr exit
                {
                    break;
                } //..End of Exit

            } //............................End of LEading While

            //............Populating FIles With Data Structures.....................

            Populating_Patient_File(Patient_Name, Patient_Disease, Patient_Doc_ID, Patient_ID, Patient_Password, ref Patient_Counter);
            Populating_Doctor_File(Doctor_Name, Doctor_Speciality, Doctor_Salary, Doctor_Status, Doctor_ID, Doctor_Password, ref Doctor_Counter);
            Populating_Service_File(Service_Counter, Service_Name, Service_Fee);
            Store_Admin_password(Admin_Password);

            //......................................................................

            //.........Exit MEssage............

            header();
            Console.WriteLine("\t\t\t\t\t Thanks For Using Our Application");
            Console.WriteLine("Press Any Key To Continue...");

            //.................................

            Console.ReadKey();



        }
    }
}
