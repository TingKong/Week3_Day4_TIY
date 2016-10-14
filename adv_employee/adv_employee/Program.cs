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

            ShowMenu();


            Console.ReadLine();

        }

        static void ReadInFile(string file)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Ting\\Source\\Repos\\Week3_Day4_TIY\\employees.xml");
            XmlNode empCat = doc.DocumentElement.SelectSingleNode("/Profiles");

            foreach (XmlNode child in empCat.ChildNodes)
            {
                EmployInfo emplyDetail = new EmployInfo();
                foreach (XmlNode grandChild in child.ChildNodes)
                {
                    switch (grandChild.Name)
                    {
                        case "name":
                            {
                                string emplyName = emplyDetail.name;
                                emplyName = grandChild.InnerText;
                                Console.WriteLine("/***********************/");
                                Console.WriteLine("");
                                Console.WriteLine("Employee Name " + emplyName );
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

            Console.WriteLine("[1] Create Employee ");
            Console.WriteLine("[2] Terminate an Employee ");
            Console.WriteLine("[3] Give a Raise ");
            Console.WriteLine("[4] Pay Employee ");
            Console.WriteLine("[5] Display All Employees ");
            Console.WriteLine("[6] Exit Program ");
            Console.WriteLine("");

            Console.WriteLine("Please select an option 1-6");

            //string userInput = Console.ReadLine();

            //switch (userInput)
            //{
            //    case '1';
            //}
            //Console.WriteLine
            //{
            //    case '2';
            //}
            //{
            //    case '3';
            //}
            //{
            //    case '4';
            //}
            //{
            //    case '5';
            //}
            //default{
            //    break;
            //}
        }

    }
}
