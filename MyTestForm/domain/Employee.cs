using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    class Employee
    {
        public string employee_id { get; set; }

        public string employee_name { get; set; }

        public int gender { get; set; }

        public string titel_name { get; set; }

        public DateTime join_date { get; set; }

        public decimal wage { get; set; }

        public string  password { get; set; }

        public Employee()
        {
            this.employee_id = Utils.GetGuid();
        }
    }
}
