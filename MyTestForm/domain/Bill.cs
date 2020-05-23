using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    class Bill
    {
        public string bill_id { get; set; }

        public decimal cost { get; set; }

        public string type { get; set; }

        public string type_name { get; set; }

        public string type_id { get; set; }

        public DateTime create_date { get; set; }

        public Bill()
        {
            this.bill_id = Utils.GetGuid();
            this.create_date = DateTime.Now;
        }
    }
}
