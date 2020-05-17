using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    class Meterial
    {

        public string meterial_id { get; set; }

        public string meterial_name { get; set; }

        public int price { get; set; }

        public int storage { get; set; }

        public bool is_deleted { get; set; }

        public Meterial()
        {
            this.meterial_id = Utils.GetGuid();
        }
    }
}
