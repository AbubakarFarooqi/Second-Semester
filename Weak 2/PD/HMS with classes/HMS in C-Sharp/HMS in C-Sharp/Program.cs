using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HMS_in_C_Sharp.BL;

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
            option = char.Parse(Console.ReadLine());
            return option;
        }//...End of User Selection Menu

        //........................................................................

        static bool Admin_login(string Admin_ID, string Admin_Password)
        {
            header();
            string ID, Password;





            Console.WriteLine("Enter Admin ID and Password");
            Console.Write("Admin ID: ");
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
            Console.WriteLine("|    14       | Delete Service                              						 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|    15       | Exit                              						 |");
            Console.WriteLine("|------------------------------------------------------------------------------------------------|");
            Console.WriteLine(" Your Option...");

            option = Console.ReadLine();
            return option;
        } // end of admin main menu

        // ........................................................................ Details of Doctor.................................................
        static void Display_Doctor_info(Doctor Source)
        {
            Console.WriteLine(Source.name + "\t" + Source.speciality + "\t" + Source.salary + "\t" + Source.ID);

        }//...End of Display_Doctor_info
         //.................................................................Validation on number type input...............................................

        static bool ValidationOnNumberInput(string source)
        {
            int i = 0;
            while (i < source.Length)
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

        static void Change_Password(List<Doctor> Doc, List<Patient> pat, string Admin_Password, int user, int index = 0)
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
                    pat[index].Password = pass;
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
                    Doc[index].pssword = pass;
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

        static void Display_Patient_info(Patient Source)
        {
            Console.WriteLine(Source.Name + "\t" + Source.Disease + "\t" + Source.Doc_ID + "\t" + Source.ID);

        } // End of PAtient info

        // ........................................................................ See Doctor Status.................................................


        static void Doc_Status(Doctor Source)
        {
            Console.WriteLine(Source.name + "\t" + Source.status + "\t" + Source.ID);
        } // End of doc status

        // ........................................................................ Display Services.................................................

        static void Display_Services(Service Source)
        {
            Console.WriteLine(Source.name + "\t" + Source.fee);

        } // end of dislay services


        static void Recommend_Doctor(List<Doctor> DoctorArray, string Disease)
        {
            bool flag = true; // if it is true then no doctor is availbe for recomendation
            for (int i = 0; i < DoctorArray.Count; i++)
            {
                if (DoctorArray[i].speciality == Disease)
                {
                    Console.WriteLine("Doctor " + "\t" + DoctorArray[i].name + "\t" + " with ID : " + "\t" + DoctorArray[i].ID + "\t" + " is recommended for this patient");
                    flag = false;
                    break;
                }
            }
            if (flag)

                Console.WriteLine("No recommendations availabe...");

        } // End of Recommend Doctor

        // ........................................................................   Add Patient.................................................


        static Patient Add_Patient(List<Patient> PatientList, List<Doctor> DoctorList)
        {
            header();
            Patient P = new Patient();
            Console.WriteLine("Admin > Add Patient");

            Console.Write("Enter Patient Name : ");

            P.Name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter Patient Disease : ");
            P.Disease = Console.ReadLine();
            Console.WriteLine();
            Recommend_Doctor(DoctorList, P.Disease);

            Console.WriteLine("Enter Patient's Doctor ID : ");

            P.Doc_ID = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Assign ID to Patient : ");
            P.ID = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Assign Password : ");
            string pass;
            pass = Console.ReadLine();


            //.............validaiton on password............

            if (Validation_of_Password(pass))
            {
                P.Password = pass;

                //.........CHECKING FOR UNIQUENESS IN ID............

                if (PatientList.Count > 0)
                {
                    bool flag = true;
                    for (int i = PatientList.Count - 1; i >= 0; i--)
                    {

                        if (PatientList.Count == 0)
                            continue;
                        if (P.ID == PatientList[i].ID)
                        {

                            Console.Clear();// remain
                            header();
                            Console.WriteLine("Admin > Add Patients");
                            Console.WriteLine("You Cannot Add Patients  with same ID. ");
                            Console.WriteLine(
                                 "Press any key to continue… ");
                            flag = false;
                            Console.ReadKey();
                            return null;

                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("The patient has been Added");
                        Console.WriteLine(

                            "Press any key to continue… ");
                        Console.ReadKey();
                        return P;
                    }
                }


            }

            else
            {

                Console.WriteLine(
                    "Password is not Valid...");
                Console.WriteLine("PAssword must contain a number...");
                Console.WriteLine(
                    "Press any key to continue… ");
                Console.ReadKey();
                return null;
            }
            return null;

        } //...End of Add patient

        //........................................................................... Add Services.................................................


        static Service Add_Services()
        {
            header();
            Service S = new Service();
            Console.WriteLine("Admin > Add services");

            Console.WriteLine("Enter Service Name : ");

            S.name = Console.ReadLine();

            Console.WriteLine("Enter Service Fee : ");
            string fee;
            fee = Console.ReadLine();
            if (ValidationOnNumberInput(fee))
            {
                S.fee = int.Parse(fee);
                Console.WriteLine("The Service Has been Added");
                Console.WriteLine(

               "Press any key to continue… ");
                Console.ReadKey();
                return S;

            }
            else
            {
                Console.WriteLine("Fee Must contain only a Number....");
                Console.WriteLine(

               "Press any key to continue… ");
                Console.ReadKey();
                return null;
            }


        } // End of Add Services

        // .........................................................................Sorting of Doctors.................................................


        static void Sorting_Doctors(List<Doctor> DoctorList)
        {
            /* temporary arrays for storing values of DOctor_salary and their respective indices */

            // I use this logic it prevent my original array from rearranging
            int[] temp = new int[DoctorList.Count];
            int[] index = new int[DoctorList.Count];

            //....................................................................................

            // filling of index
            for (int i = 0; i < DoctorList.Count; i++)
            {
                index[i] = i;
            }

            // filling of temp
            for (int i = 0; i < DoctorList.Count; i++)
            {
                temp[i] = DoctorList[i].salary;
            }

            // sorting indices in index array
            for (int i = 0; i < DoctorList.Count; i++)
            {
                for (int j = 0; j < DoctorList.Count - 1; j++)
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

            for (int i = 0; i < DoctorList.Count; i++)
            {
                Display_Doctor_info(DoctorList[index[i]]);
            }
        } // End of Sorting Doctors

        // ...........................................................................Add Doctor.................................................

        static Doctor Add_Doctor(List<Doctor> DoctorList)
        {

            header();
            Doctor D = new Doctor();
            Console.WriteLine("Admin > Add Doctor");

            Console.WriteLine("Enter Doctor Name : ");

            D.name = Console.ReadLine();
            Console.WriteLine(
                 "Enter Doctor's Speciality : ");
            D.speciality = Console.ReadLine();

            Console.WriteLine(
                  "Enter Doctor's Salary  : ");
            string salary;
            salary = Console.ReadLine();

            //..............validaiton on salary...............

            if (ValidationOnNumberInput(salary))
            {
                D.salary = int.Parse(salary);

                Console.WriteLine(
                      "Enter Doctor's Status  : ");

                D.status = Console.ReadLine();
                Console.WriteLine(
                      "Assign ID to Doctor : ");
                D.ID = Console.ReadLine();
                string pass;
                Console.WriteLine(
                      "Assign Password : ");
                pass = Console.ReadLine();

                //.............validaiton on password............

                if (Validation_of_Password(pass))
                {
                    D.pssword = pass;

                    //.........CHECKING FOR UNIQUENESS IN ID............

                    if (DoctorList.Count > 0)
                    {
                        bool flag = true;
                        for (int i = DoctorList.Count - 1; i >= 0; i--)
                        {

                            if (DoctorList.Count == 0)
                                continue;
                            if (D.ID == DoctorList[i].ID)
                            {


                                Console.Clear();
                                header();
                                Console.WriteLine("Admin > Add Doctors");
                                Console.WriteLine(
                                     "You Cannot Add Doctors  with same ID. ");
                                Console.WriteLine("Press any key to continue… ");
                                flag = false;
                                Console.ReadKey();
                                return null;
                            }
                        }
                        if (flag)
                        {
                            Console.WriteLine("The Doctor has been Added");
                            Console.WriteLine(
                                 "Press any key to continue… ");
                            Console.ReadKey();
                            return D;
                        }
                    }


                }
                else
                {
                    Console.WriteLine(
                          "Password is not Valid...");
                    Console.WriteLine("PAssword must contain a number...");
                    Console.WriteLine(
                         "Press any key to continue… ");
                    Console.ReadKey();
                    return null;
                }//remain
            }
            else
            {
                Console.WriteLine(
                      "Salary Must be  numbers only...");
                Console.WriteLine(
                      "Press any key to continue… ");
                Console.ReadKey();
                return null;
            }
            return null;

        } //...End of Add_Doctor

        //........................................................................... Doctor_Login.................................................

        static int Doctor_Login(List<Doctor> Source)
        {
            header();
            string ID, Password;
            Console.WriteLine("Enter Doctor ID and Password");

            Console.WriteLine("Doctor ID : ");

            ID = Console.ReadLine();

            Console.WriteLine("Password : ");
            Password = Console.ReadLine();

            //...........Checking whether doctor exist or not...........

            for (int i = 0; i < Source.Count; i++)
            {
                if (ID == Source[i].ID && Password == Source[i].pssword)
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

        static int Patient_Login(List<Patient> Source)
        {
            header();
            string ID, Password;
            Console.WriteLine("Enter Patient ID and Password");

            Console.WriteLine("Patient ID : ");
            ID = Console.ReadLine();

            Console.WriteLine("Password : ");
            Password = Console.ReadLine();

            //...........Checking whether doctor exist or not...........

            for (int i = 0; i < Source.Count; i++)
            {
                if (ID == Source[i].ID && Password == Source[i].Password)
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
            option = char.Parse(Console.ReadLine());

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

        static void Populating_Patient_Structures(List<Patient> Source)
        {

            string path = "Patients.txt";
            StreamReader patientFile = new StreamReader(path);
            string temp = " ";

            while ((temp = patientFile.ReadLine()) != null) //.........................control goes inside If file is not empty
            {

                //.........................................................................................................
                Patient Dummy = new Patient();
                Dummy.Name = Extraction_of_Specific_Field(temp, 1);
                Dummy.Disease = Extraction_of_Specific_Field(temp, 2);
                Dummy.Doc_ID = Extraction_of_Specific_Field(temp, 3);
                Dummy.ID = Extraction_of_Specific_Field(temp, 4);
                Dummy.Password = Extraction_of_Specific_Field(temp, 5);
                Source.Add(Dummy);


            }
            patientFile.Close();
        } // End of Populating PAtient Structures


        static void Populating_Doctor_Structures(List<Doctor> Source)
        {

            string path = "Doctors.txt";
            string temp = " ";
            StreamReader DoctorFile = new StreamReader(path);
            //............................cheking whether file is empty or not...........

            while ((temp = DoctorFile.ReadLine()) != null)
            {

                Doctor Dummy = new Doctor();
                Dummy.name = Extraction_of_Specific_Field(temp, 1);
                Dummy.salary = int.Parse((Extraction_of_Specific_Field(temp, 3)));
                Dummy.status = Extraction_of_Specific_Field(temp, 4);
                Dummy.ID = Extraction_of_Specific_Field(temp, 5);

                Dummy.pssword = Extraction_of_Specific_Field(temp, 6);


                Source.Add(Dummy);

            }
            DoctorFile.Close();
        } // ENd of populating Doctor Structures

        // ........................................................................populating File with Doctors info.................................................



        static void Populating_Doctor_File(List<Doctor> Source)
        {

            string path = "Doctors.txt";
            StreamWriter DoctorFile = new StreamWriter(path);
            for (int i = 0; i < Source.Count; i++)
            {
                DoctorFile.WriteLine(Source[i].name + "," + Source[i].speciality + "," + Source[i].salary + "," + Source[i].status + "," + Source[i].ID + "," + Source[i].pssword);

            }

            DoctorFile.Close();
        } // ENd of populating doctor file

        // .......................................................................populating File with PAtients info.................................................

        static void Populating_Patient_File(List<Patient> Source)
        {

            string path = "Patients.txt";
            StreamWriter patientFile = new StreamWriter(path);
            for (int i = 0; i < Source.Count; i++)
            {
                patientFile.WriteLine(Source[i].Name + "," + Source[i].Disease + "," + Source[i].Doc_ID + "," + Source[i].ID + "," + Source[i].Password);

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

        static void Populating_Service_File(List<Service> Source)
        {
            string path = "Services.txt";
            StreamWriter serviceFile = new StreamWriter(path);
            for (int i = 0; i < Source.Count; i++)
            {
                serviceFile.WriteLine(Source[i].name + "," + Source[i].fee);

            }

            serviceFile.Close();
        } // end of populating Service File

        //......................................................................Populating Service Structures from file.................................................


        static void Populating_Service_Structures(List<Service> Source)
        {
            StreamReader serviceFile = new StreamReader("Services.txt");
            string temp = " ";


            while ((temp = serviceFile.ReadLine()) != null)
            {



                //.........................................................................................................
                Service Dummy = new Service();
                Dummy.name = Extraction_of_Specific_Field(temp, 1);
                Dummy.fee = int.Parse((Extraction_of_Specific_Field(temp, 2)));
                Source.Add(Dummy);

            }
            serviceFile.Close();
        } // end Populating_Service_Structures()

        //........................................................................... Start of main.................................................


        static void Main(string[] args)
        {

            //.............................................................Variables for admin.............................
            string Admin_ID = "PF";
            string Admin_Password = "2021";
            //............................................................Class OBject for Patient..........................

            List<Patient> PatientList = new List<Patient>();


            //............................................................. Classes  For Doctor.........................

            List<Doctor> DoctorList = new List<Doctor>();


            //............................................................. Data Structures For Services..........................

            List<Service> ServiceList = new List<Service>();




            //...................Filling oF all Data Structures From FIle....................

            Populating_Service_Structures(ServiceList);
            Extraction_of_Admin_password(ref Admin_Password);
            Populating_Doctor_Structures(DoctorList);
            Populating_Patient_Structures(PatientList);

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
                        while (admin_option != "15")
                        {
                            header();
                            admin_option = Admin_Main_Menu();

                            if (admin_option == "1")
                            {
                                Patient temp = new Patient();
                                temp = Add_Patient(PatientList, DoctorList);
                                if (temp != null)
                                {
                                    PatientList.Add(temp);
                                    Populating_Patient_File(PatientList);

                                }
                            } //.....ENd of Option 1

                            else if (admin_option == "2")
                            {
                                Doctor temp = new Doctor();
                                temp = Add_Doctor(DoctorList);
                                if (temp != null)
                                {
                                    DoctorList.Add(temp);
                                    Populating_Doctor_File(DoctorList);
                                }
                            } //.....ENd of Option 2

                            else if (admin_option == "3")
                            {
                                Service temp = new Service();
                                temp = Add_Services();
                                if (temp != null)
                                {
                                    ServiceList.Add(temp);
                                    Populating_Service_File(ServiceList);
                                }

                            } //.....ENd of Option 3

                            else if (admin_option == "4")
                            {

                                header();

                                if (DoctorList.Count == 0) // If no Doctor is Added
                                {
                                    Console.WriteLine("Admin > See Details of All Doctors\n " + "No Record Found...");

                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Doctors");
                                    Console.WriteLine("Name\tSpeciality\tSalary\tID");

                                    for (int i = 0; i < DoctorList.Count; i++)
                                    {
                                        Display_Doctor_info(DoctorList[i]);
                                    }
                                }
                                Console.WriteLine("Press Any Key to Continue...");
                                Console.ReadKey();
                            } //.....ENd of Option 4

                            else if (admin_option == "5")
                            {
                                header();

                                if (PatientList.Count == 0) // If no patient is added
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("Name\tDisease\tDoc ID\tID");

                                    for (int i = 0; i < PatientList.Count; i++)
                                        Display_Patient_info(PatientList[i]);
                                }
                                Console.WriteLine("Press Any Key to Continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 5

                            else if (admin_option == "6")
                            {
                                header();

                                if (DoctorList.Count == 0) // if no Doctor is added
                                {
                                    Console.WriteLine("Admin > Details of Doctors according to increasing order of salary..");
                                    Console.WriteLine("Record Not Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > Details of Doctors according to increasing order of salary..");
                                    Sorting_Doctors(DoctorList);
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


                                for (int i = 0; i < DoctorList.Count; i++)
                                {
                                    if (ID == DoctorList[i].ID) // If user enter right ID
                                    {
                                        Display_Doctor_info(DoctorList[i]);
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



                                for (int i = 0; i < PatientList.Count; i++)
                                {
                                    if (ID == PatientList[i].ID) // If user enter right ID
                                    {
                                        Display_Patient_info(PatientList[i]);
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


                                for (int i = 0; i < DoctorList.Count; i++)
                                {
                                    if (ID == DoctorList[i].ID) // If user enter right ID
                                    {
                                        Doc_Status(DoctorList[i]);
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

                                if (ServiceList.Count == 0) // If no Service is added yets
                                {
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {


                                    Console.WriteLine("Name\tFee");

                                    for (int i = 0; i < ServiceList.Count; i++)
                                        Display_Services(ServiceList[i]);
                                }
                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 10

                            else if (admin_option == "11")
                            {
                                Change_Password(DoctorList, PatientList, Admin_Password, 1);
                                Store_Admin_password(Admin_Password);
                            } //.....ENd of Option 11
                            else if (admin_option == "12")
                            {
                                header();

                                if (PatientList.Count == 0) // If no patient is added
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Patients");
                                    Console.WriteLine("Name\tDisease\tDoc ID\tID");

                                    for (int i = 0; i < PatientList.Count; i++)
                                        Display_Patient_info(PatientList[i]);
                                }
                                Console.WriteLine("Which Paient You want to Delete");
                                int Patient_Number = int.Parse(Console.ReadLine());
                                PatientList.RemoveAt(Patient_Number - 1);
                                Populating_Patient_File(PatientList);
                            }
                            else if (admin_option == "13")
                            {
                                header();

                                if (DoctorList.Count == 0) // If no patient is added
                                {
                                    Console.WriteLine("Admin > See Details of All Doctor");
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Details of All Dcotors");
                                    Console.WriteLine("Name\tDisease\tDoc ID\tID");

                                    for (int i = 0; i < DoctorList.Count; i++)
                                        Display_Doctor_info(DoctorList[i]);
                                    Console.WriteLine("Which Doctor You want to Delete");
                                    int Doctor_Number = int.Parse(Console.ReadLine());
                                    DoctorList.RemoveAt(Doctor_Number - 1);
                                    Populating_Doctor_File(DoctorList);
                                }
                            }
                            else if (admin_option == "14")
                            {
                                header();

                                if (ServiceList.Count == 0) // If no patient is added
                                {
                                    Console.WriteLine("Admin > See Services");
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {
                                    Console.WriteLine("Admin > See Services");
                                    Console.WriteLine("Name\tFee");

                                    for (int i = 0; i < ServiceList.Count; i++)
                                        Display_Services(ServiceList[i]);
                                    Console.WriteLine("Which Service You want to Delete");
                                    int Service_Number = int.Parse(Console.ReadLine());
                                    ServiceList.RemoveAt(Service_Number - 1);
                                    Populating_Service_File(ServiceList);
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

                    int Patient_number = Patient_Login(PatientList); // it return -1 if password is incorrect

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


                                Display_Patient_info(PatientList[Patient_number]);

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

                                for (int i = 0; i < DoctorList.Count; i++)
                                {
                                    if (ID == DoctorList[i].ID)
                                    {
                                        Doc_Status(DoctorList[i]);
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

                                if (ServiceList.Count == 0) // If no Service is added yet
                                {
                                    Console.WriteLine("No Record Found...");
                                }

                                else
                                {

                                    Console.WriteLine("Name\tFEE");

                                    for (int i = 0; i < ServiceList.Count; i++)
                                        Display_Services(ServiceList[i]);
                                }

                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //...End of option 3

                            else if (Patient_Option == '4')
                            {
                                Change_Password(DoctorList, PatientList, Admin_Password, 2, Patient_number);
                                Populating_Patient_File(PatientList);
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

                    int Doctor_Number = Doctor_Login(DoctorList);

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


                                Display_Doctor_info(DoctorList[Doctor_Number]);

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

                                for (int i = 0; i < PatientList.Count; i++)
                                {
                                    if (ID == PatientList[i].ID)
                                    {
                                        Display_Patient_info(PatientList[i]);
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

                                if (ServiceList.Count == 0) // If no Service is added yet
                                {
                                    Console.WriteLine("No Record Found...");
                                }
                                else
                                {

                                    Console.WriteLine("Name\tFEE");

                                    for (int i = 0; i < ServiceList.Count; i++)
                                        Display_Services(ServiceList[i]);
                                }

                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //...ENd of option 3

                            else if (Doctor_option == '4')
                            {
                                header();
                                Console.WriteLine("Doctor > Change Status");
                                Console.WriteLine("Your Current Status :\t " + DoctorList[Doctor_Number].status);
                                Console.Write("Your New Status : ");

                                DoctorList[Doctor_Number].status = Console.ReadLine();
                                Console.WriteLine("The Status has been Changed");
                                Console.WriteLine("Press any Key To Continue...");
                                Populating_Doctor_File(DoctorList);
                                Console.ReadKey();
                            } //...ENd of option 4

                            else if (Doctor_option == '5')
                            {
                                Change_Password(DoctorList, PatientList, Admin_Password, 3, Doctor_Number);
                                Populating_Doctor_File(DoctorList);
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

            Populating_Patient_File(PatientList);
            Populating_Doctor_File(DoctorList);
            Populating_Service_File(ServiceList);
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
