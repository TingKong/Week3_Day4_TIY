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
                Console.WriteLine("Found it");
            }
            else
            {
                Console.WriteLine("File not found");
                Console.WriteLine("Let me create the employee file for you");
                using (XmlWriter writer = XmlWriter.Create(fileName))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Profiles");

                    foreach (EmployInfo b in employlist)
                    {
                        writer.WriteStartElement("Employee");

                        writer.WriteElementString("Id", b.id);
                        writer.WriteElementString("Name", b.name);
                        writer.WriteElementString("Payrate", Convert.ToString(b.payrate));


                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                }

            }
            Console.ReadLine();

        }
    }
}
