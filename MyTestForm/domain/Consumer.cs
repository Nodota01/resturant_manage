using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    

    class Consumer
    {
        public Consumer()
        {
            this.consumer_id = Utils.GetGuid();
        }

        public string consumer_id { get; set; }

        public string consumer_name { get; set; }

        public string phone_number { get; set; }

        public int gender { get; set; }

        public bool is_deleted { get; set; }
    }
}
