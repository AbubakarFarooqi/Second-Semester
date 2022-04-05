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
            Char.TryParse(Console.ReadLine(), out option);
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

        static void SeeParticularPatient(List<Patient> PatientList, string ID, ref bool flag)
        {

            for (int i = 0; i < PatientList.Count; i++)
            {
                if (PatientList[i].isAvailble(ID)) // If user enter right ID
                {
                    PatientList[i].View();
                    flag = true;
                }
            }
        }
        // ........................................................................ Details of Doctor.................................................

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

            while (i < pass.Length)
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

        static string Change_Password()
        {

            header();
            string pass;
            Console.WriteLine(" > Change Password");

            Console.WriteLine("Passwrod Must Contain a Number...");
            Console.WriteLine("Enter New Password... ");

            pass = Console.ReadLine();

            if (Validation_of_Password(pass))
            {

                Console.WriteLine("The Password Has been Succesfully Changed...");
                Console.WriteLine("Press any key to continue...");
                return pass;
            }
            else
                Console.WriteLine("Password is not Valid...");

            Console.ReadKey();
            return null;

        } // end of Change_Password

        //....................................................................... Display Services.................................................


        static bool isUniquePatient(List<Patient> PatientList, Patient Source)
        {

            //.........CHECKING FOR UNIQUENESS IN ID............
            Random randomNum = new Random();
            int encrptionLevel = randomNum.Next();
            if (PatientList.Count > 0)
            {
                for (int i = PatientList.Count - 1; i >= 0; i--)
                {

                    if (PatientList.Count == 0)
                        continue;
                    if (PatientList[i].ReturnID(encrptionLevel) == Source.ReturnID(encrptionLevel))
                        return false;

                }
            }
            return true;
        }


        // ........................................................................   Add Patient.................................................


        static Patient TakeInputOfPatient()
        {

            string Name;
            string Disease;
            string ID;
            string Password;

            Console.Write("Enter Patient Name : ");
            Name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter Patient Disease : ");
            Disease = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Assign ID to Patient : ");
            ID = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Assign Password : ");
            Password = Console.ReadLine();

            Patient Source = new Patient(Name, Disease, ID, Password);

            return Source;

        } //...End of Add patient

        //........................................................................... Add Services.................................................


        static Service Add_Services()
        {
            string name;
            string tempfee;
            int fee;

            Console.WriteLine("Enter Service Name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Service Fee : ");
            tempfee = Console.ReadLine();
            if (ValidationOnNumberInput(tempfee))
            {
                fee = int.Parse(tempfee);
                Service Source = new Service(name, fee);
                return Source;

            }
            return null;
        }




        // .........................................................................Sorting of Doctors.................................................


        static void Sorting_Doctors(List<Doctor> DoctorList)
        {
            /* temporary arrays for storing values of DOctor_salary and their respective indices*/

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
                temp[i] = DoctorList[i].getSalary();
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
                /*  Display_Doctor_info(DoctorList[index[i]]);*/
                DoctorList[i].View();
            }
        } // End of Sorting Doctors

        // ...........................................................................Add Doctor.................................................

        static bool isUniqueDoctor(List<Doctor> DoctorList, Doctor Source)
        {
            //.........CHECKING FOR UNIQUENESS IN ID............
            Random randomNum = new Random();
            int encrptionLevel = randomNum.Next();

            if (DoctorList.Count > 0)
            {

                for (int i = DoctorList.Count - 1; i >= 0; i--)
                {

                    if (DoctorList.Count == 0)
                        continue;
                    if (DoctorList[i].ReturnID(encrptionLevel) == Source.ReturnID(encrptionLevel))
                        return false;
                }

            }
            return true;
        }
        static Doctor TakeInputOfDoctor()
        {

            string name;
            string speciality;
            string status;
            string ID;
            string Password;

            Console.WriteLine("Enter Doctor Name : ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Doctor's Speciality : ");
            speciality = Console.ReadLine();
            Console.WriteLine("Enter Doctor's Status  : ");
            status = Console.ReadLine();
            Console.WriteLine("Assign ID to Doctor : ");
            ID = Console.ReadLine();
            Console.WriteLine("Assign Password : ");
            Password = Console.ReadLine();

            Doctor Source = new Doctor(name, speciality, ID, Password, status);

            return Source;
        } //...End of Add_Doctor


        static void ViewAllPatients(List<Patient> PatientList)
        {
            Console.WriteLine("Name\tDisease\tDoc ID\tID");

            for (int i = 0; i < PatientList.Count; i++)
                PatientList[i].View();
        }
        static void ViewAllDoctors(List<Doctor> DoctorList)
        {
            Console.WriteLine("Name\tSpeciality\tSalary\tID");

            for (int i = 0; i < DoctorList.Count; i++)
            {
                DoctorList[i].View();
            }
        }
        static void SeeDetailsOfParticularDoctor(List<Doctor> DoctorList, string ID, ref bool flag)
        {
            for (int i = 0; i < DoctorList.Count; i++)
            {
                if (DoctorList[i].isAvailable(ID))// If user enter right ID
                {
                    DoctorList[i].View();
                    flag = true;
                    break;
                }
            }
        }


        static void DoctorStatusChk(List<Doctor> DoctorList, string ID, ref bool flag)
        {
            for (int i = 0; i < DoctorList.Count; i++)
            {
                if (DoctorList[i].isAvailable(ID)) // If user enter right ID
                {
                    DoctorList[i].ViewStatus();
                    flag = true;
                }
            }
        }
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
                if (Source[i].isValid(Password, ID))
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
                if (Source[i].isValid(Password, ID))
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


        static void ViewAllServices(List<Service> ServiceList)
        {
            Console.WriteLine("Name\tFee");

            for (int i = 0; i < ServiceList.Count; i++)
                ServiceList[i].View();
        }

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
                string Name;
                string Disease;
                string Doc_ID;
                string ID;
                string Password;
                Name = Extraction_of_Specific_Field(temp, 1);
                Disease = Extraction_of_Specific_Field(temp, 2);
                Doc_ID = Extraction_of_Specific_Field(temp, 3);
                ID = Extraction_of_Specific_Field(temp, 4);
                Password = Extraction_of_Specific_Field(temp, 5);
                Patient t = new Patient(Name, Disease, ID, Password);
                t.AssignDoctor(Doc_ID);
                PutPatientIntoList(Source, t);


            }
            patientFile.Close();
        } // End of Populating PAtient Structures

        static void PutPatientIntoList(List<Patient> PatientList, Patient Source)
        {
            PatientList.Add(Source);
        }
        static void PutDoctorIntoList(List<Doctor> DoctorList, Doctor Source)
        {
            DoctorList.Add(Source);
        }
        static void Populating_Doctor_Structures(List<Doctor> Source)
        {

            string path = "Doctors.txt";
            string temp = " ";
            StreamReader DoctorFile = new StreamReader(path);
            //............................cheking whether file is empty or not...........

            while ((temp = DoctorFile.ReadLine()) != null)
            {


                string name;
                string speciality;
                int salary;
                string status;
                string ID;
                string pssword;
                name = Extraction_of_Specific_Field(temp, 1);
                speciality = Extraction_of_Specific_Field(temp, 2);
                salary = int.Parse((Extraction_of_Specific_Field(temp, 3)));
                status = Extraction_of_Specific_Field(temp, 4);
                ID = Extraction_of_Specific_Field(temp, 5);

                pssword = Extraction_of_Specific_Field(temp, 6);

                Doctor t = new Doctor(name, speciality, ID, pssword, status);
                t.AssignSalary(salary);
                PutDoctorIntoList(Source, t);

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
                string name;
                int fee;
                name = Extraction_of_Specific_Field(temp, 1);
                fee = int.Parse((Extraction_of_Specific_Field(temp, 2)));
                Service t = new Service(name, fee);
                Source.Add(t);

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
                                header();
                                Console.WriteLine("Admin > Add Patient");
                                Patient temp;
                                temp = TakeInputOfPatient();
                                if (!Validation_of_Password(temp.Password))
                                {
                                    Console.WriteLine("Password is not Valid");

                                }
                                else if (!isUniquePatient(PatientList, temp))
                                {
                                    Console.WriteLine("You Cannot Add Patients with Same ID");
                                }
                                else
                                {
                                    temp.Recommend_Doctor(DoctorList);
                                    temp.AssignDoctor();
                                    PutPatientIntoList(PatientList, temp);
                                    Populating_Patient_File(PatientList);
                                }
                                Console.ReadLine();

                            } //.....ENd of Option 1

                            else if (admin_option == "2")
                            {
                                header();
                                Console.WriteLine("Admin > Add Doctor");
                                Doctor temp;

                                temp = TakeInputOfDoctor();

                                string salary;
                                Console.Write("Enter Salary = ");
                                salary = Console.ReadLine();
                                Console.WriteLine();

                                if (!Validation_of_Password(temp.pssword))
                                {
                                    Console.WriteLine("Password is not Valid");
                                }
                                else if (!isUniqueDoctor(DoctorList, temp))
                                {
                                    Console.WriteLine("You Cannot Add Doctors with Same ID");
                                }
                                else if (!temp.isValidSalary(salary))
                                {
                                    Console.WriteLine("Invalid Salary");
                                }
                                else
                                {
                                    temp.AssignSalary(int.Parse(salary));
                                    PutDoctorIntoList(DoctorList, temp);
                                    Populating_Doctor_File(DoctorList);

                                }

                                Console.ReadLine();

                            } //.....ENd of Option 2

                            else if (admin_option == "3")
                            {
                                header();
                                Console.WriteLine("Admin > Add services");
                                Service temp;
                                temp = Add_Services();
                                if (temp != null)
                                {
                                    ServiceList.Add(temp);
                                    Populating_Service_File(ServiceList);
                                }
                                else
                                {
                                    Console.WriteLine("invalid Fee");
                                }
                                Console.WriteLine("Press Any key to continue ");
                                Console.ReadKey();

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
                                    ViewAllDoctors(DoctorList);
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
                                    ViewAllPatients(PatientList);
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
                                SeeDetailsOfParticularDoctor(DoctorList, ID, ref flag);
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
                                string ID;
                                Console.WriteLine("Admin > Details of Particular Patient");
                                Console.Write("Enter Patient's ID : ");
                                ID = Console.ReadLine();
                                Console.WriteLine("Name\tDisease\tDoc ID\tID");
                                SeeParticularPatient(PatientList, ID, ref flag);
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
                                DoctorStatusChk(DoctorList, ID, ref flag);
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

                                    ViewAllServices(ServiceList);

                                }
                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //.....ENd of Option 10

                            else if (admin_option == "11")
                            {
                                string tempPass = Change_Password();
                                if (tempPass != null)
                                {
                                    Admin_Password = tempPass;
                                }
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
                                    ViewAllPatients(PatientList);

                                    Console.WriteLine("Which Paient You want to Delete");
                                    int Patient_Number = int.Parse(Console.ReadLine());
                                    PatientList.RemoveAt(Patient_Number - 1);
                                    Populating_Patient_File(PatientList);
                                }
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
                                    ViewAllDoctors(DoctorList);
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
                                    ViewAllServices(ServiceList);
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

                                PatientList[Patient_number].View();

                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();
                            } //...End of option 1

                            else if (Patient_Option == '2')
                            {
                                header();
                                Console.WriteLine("Patient > Doctor Status");
                                string ID;
                                bool flag = false; // if its value is false then entered ID will be wrong
                                Console.Write("Enter Doctor's ID : ");
                                ID = Console.ReadLine();
                                Console.WriteLine("Name\tStatus\tID");
                                DoctorStatusChk(DoctorList, ID, ref flag);
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
                                    ViewAllServices(ServiceList);
                                }

                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //...End of option 3

                            else if (Patient_Option == '4')
                            {
                                string tempPass = Change_Password();
                                if (tempPass != null)
                                {
                                    PatientList[Patient_number].AssignPassword(tempPass);
                                }
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
                                DoctorList[Doctor_Number].View();
                                Console.WriteLine("Press Any Key To continue...");
                                Console.ReadKey();
                            } //...ENd of option 1

                            else if (Doctor_option == '2')
                            {
                                header();
                                Console.WriteLine("Doctor > Patient Details");
                                string ID;
                                bool flag = false; // if its value is false then entered ID will be wrong
                                Console.Write("Enter Patient's ID : ");
                                ID = Console.ReadLine();
                                Console.WriteLine("Name\tDisease\tDoc ID\tID");
                                SeeParticularPatient(PatientList, ID, ref flag);
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
                                    ViewAllServices(ServiceList);
                                }

                                Console.WriteLine("Press any Key To Continue...");
                                Console.ReadKey();

                            } //...ENd of option 3

                            else if (Doctor_option == '4')
                            {
                                header();
                                Console.WriteLine("Doctor > Change Status");
                                DoctorList[Doctor_Number].ViewStatus();
                                Console.Write("Your New Status : ");
                                DoctorList[Doctor_Number].ChangeStatus(Console.ReadLine());
                                Console.WriteLine("The Status has been Changed");
                                Console.WriteLine("Press any Key To Continue...");
                                Populating_Doctor_File(DoctorList);
                                Console.ReadKey();
                            } //...ENd of option 4

                            else if (Doctor_option == '5')
                            {
                                string tempPass = Change_Password();
                                if (tempPass != null)
                                {
                                    DoctorList[Doctor_Number].AssignPassword(tempPass);
                                }
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
