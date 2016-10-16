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
                            Console.WriteLine("selected 2");

                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("selected 3");

                            break;
                        }
                    case '4':
                        {
                            Console.WriteLine("selected 4");

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
                            Console.WriteLine("selected 6");
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
                Console.WriteLine(string.Format("{0}, {1}, {2}", a.Name, a.Id, a.Payrate));
         
            }
        }

        static void ReadInFile(string file)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Ting\\Source\\Repos\\Week3_Day4_TIY\\employees.xml");
            XmlNode empCat = doc.DocumentElement.SelectSingleNode("/Profiles");

            foreach (XmlNode child in empCat.ChildNodes)
            {
                foreach (XmlNode grandChild in child.ChildNodes)
                {
                    switch (grandChild.Name)
                    {
                        case "name":
                            {
                                string emplyName = grandChild.InnerText;
                                Console.WriteLine("/***********************/");
                                Console.WriteLine("");
                                //Console.WriteLine("Employee Name: " + emplyName );
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

        static void ExitProgram(string file)
        {

        }


    }
}
