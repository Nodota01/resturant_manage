using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.domain
{
    class VisitRecord
    {
        public string visit_record_id { get; set; }

        /// <summary>
        /// 桌号
        /// </summary>
        public string desk_id { get; set; }

        public DateTime visit_date { get; set; }

        public int consumer_num { get; set; }

        public VisitRecord()
        {
            this.visit_record_id = Utils.GetGuid();
        }
    }
}
