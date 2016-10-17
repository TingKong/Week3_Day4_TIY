using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace adv_employee
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EmployInfo> employlist = new List<EmployInfo>();

            string fileName = "C:\\Users\\Ting\\Source\\Repos\\Week3_Day4_TIY\\employees.xml";

            if (File.Exists(fileName))
            {
                ReadInFile(fileName);
            }
            else
            {
                FileNotFound(fileName);
            }

         
            bool useprogram = true;
            while (useprogram)
            {
                ShowMenu();

                char userInput = Convert.ToChar(Console.ReadLine());

                switch (userInput)
                {

                    case '1':
                        {
                            NewEmploy(employlist);
                            break;
                        }
                    case '2':
                        {
                            Terminate1(employlist);
                            break;
                        }
                    case '3':
                        {
                            GiveRaise(employlist);
                            break;
                        }
                    case '4':
                        { 
                            Pay(employlist);

                            break;
                        }
                    case '5':
                        {
                            Console.WriteLine("selected 5");
                            DisplayAll(employlist);

                            break;
                        }
                    case '6':
                        {
                            Exit(fileName, employlist);
                            Console.WriteLine("Your file has been saved, and will now exit");
                            useprogram = false;
                                break;
                        }

                    default:
                        {
                            Console.WriteLine("Need a number 1-6");

                            break;
                        }


                }

            }
            Console.ReadLine();

        }

        static void Exit(string file, List<EmployInfo> cycle)
        {

            using (XmlWriter writer = XmlWriter.Create(file))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Profiles");
                foreach (EmployInfo a in cycle)
                {

                    writer.WriteStartElement("Employee");
                    writer.WriteElementString("ID", a.Id);
                    writer.WriteElementString("Name", a.Name);
                    writer.WriteElementString("Salary", a.Payrate.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        static void Pay(List<EmployInfo> cycle)
        {
            
            foreach (EmployInfo a in cycle)
            {
                if (a.Id == "terminated")
                {
                    Console.WriteLine(string.Format("ID: {0}. NAME: {1} : TERMINATED - NOT PAID", a.Name, a.Id));

                }
                else
                {
                    Console.WriteLine(string.Format("ID: {0}. NAME: {1} : ACTIVE - PAID", a.Name, a.Id));
                }

            }


        }

        static void Terminate1(List<EmployInfo> cycle)
        {
            Console.WriteLine("Please enter employee id ");
            string idEnd = Console.ReadLine();

            foreach (EmployInfo a in cycle)
            {
                if (a.Id == idEnd)
                {
                    a.Terminate("terminated");
                    

                }

            }
        }


        static void GiveRaise(List<EmployInfo> cycle)
        {
            Console.WriteLine("Please enter employee id ");
            string idRaise = Console.ReadLine();

            foreach (EmployInfo a in cycle)
            {

                if ( a.Id == idRaise)
                {
                    double newRaise = Convert.ToDouble(idRaise);
                     newRaise = a.Payrate + 1000;
                    Console.WriteLine(newRaise);
                    a.Raise(newRaise);
                    
                }

            }
           

        }
        static void NewEmploy(List<EmployInfo> newlist)
        {
           
            Console.WriteLine("Please enter an employee name ");
            string employName = Console.ReadLine();
            Console.WriteLine("Please enter employee id ");
            string id = Console.ReadLine();
            Console.WriteLine("Please give the emmployee a salary");
            double salary = Convert.ToDouble(Console.ReadLine());
            EmployInfo employN = new EmployInfo( id, employName, salary);
            newlist.Add(employN);
            Console.WriteLine(employN.Name + ", " + employN.Id + ", " + employN.Payrate.ToString());
            

        }

        static void DisplayAll(List<EmployInfo> cycle)
        {

            foreach (EmployInfo a in cycle)
            {
                Console.WriteLine(string.Format("Employee info: {0}, {1}, {2}", a.Name, a.Id, a.Payrate));
         
            }
        }

        static void ReadInFile(string file, List<EmployInfo> cycle)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode empCat = doc.DocumentElement.SelectSingleNode("/Profiles");

            foreach (EmployInfo a in cycle) {
                foreach (XmlNode child in empCat.ChildNodes)
                {
                    foreach (XmlNode grandChild in child.ChildNodes)
                    {
                        switch (grandChild.Name)
                        {
                            case "Name":
                                {
                                    
                                    a.Name = grandChild.InnerText;
                                    Console.WriteLine("Employee Name: " + a.Name);
                                    break;
                                }
                            case "ID":
                                {
                                    string emplyName = grandChild.InnerText;
                                    Console.WriteLine(emplyName);
                                    break;

                                }

                            case "Salary":
                                {
                                    string salary = grandChild.InnerText;
                                    Console.WriteLine(salary);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }


                        }


                    }

                }
            }
        }


        static void FileNotFound(string file)
        {
            Console.WriteLine("The file you requested does not exist, a new file has been created for you");
            Console.WriteLine("");

            using (XmlWriter writer = XmlWriter.Create(file))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Profiles");

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("[1] Create Employee ");
            Console.WriteLine("[2] Terminate an Employee ");
            Console.WriteLine("[3] Give a Raise ");
            Console.WriteLine("[4] Pay Employee ");
            Console.WriteLine("[5] Display All Employees ");
            Console.WriteLine("[6] Exit Program ");
            Console.WriteLine("");

            Console.WriteLine("Please select an option with the number 1-6");



        }

    }
}