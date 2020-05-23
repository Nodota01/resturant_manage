using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    class Dishes
    {
        public string dishes_id { get; set; }

        public string dishes_name { get; set; }

        public decimal price { get; set; }

        public bool is_deleted { get; set; }

        public Dishes()
        {
            this.dishes_id = Utils.GetGuid();
        }
    }
}
