using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    class Order
    {
        public string order_id { get; set; }

        public string visit_record_id { get; set; }

        public string dishes_id { get; set; }

        public DateTime order_date { get; set; }

        public Order()
        {
            this.order_id = Utils.GetGuid();
            this.order_date = DateTime.Now;
        }

    }
}
