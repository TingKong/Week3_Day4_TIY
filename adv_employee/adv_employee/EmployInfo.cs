using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adv_employee
{
   public class EmployInfo
    {
        private string id;
        private string name;
        private double payrate;


        public EmployInfo(string a, string b, double c)
        {
            id = a;
            name = b;
            payrate = c;
            
          
        }

        public string Id
        {
            get
            {
                return id;
            }

           
        }

        public string Name
        {
            get
            {
                return name;
            }


        }

        public double Payrate
        {
            get
            {
                return payrate;
            }


        }
    }
}
