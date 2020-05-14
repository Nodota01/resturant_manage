using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    class Desk
    {
        public string desk_id { get; set; }

        public string desk_name { get; set; }

        public string current_record { get; set; }

        public bool is_deleted { get; set; }

        public Desk()
        {
            this.desk_id = Utils.GetGuid();
        }
    }
}
