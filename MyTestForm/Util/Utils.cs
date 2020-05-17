using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.Util
{
    class Utils
    {
        /// <summary>
        /// 获取guid
        /// </summary>
        /// <param name="length"></param>
        /// <returns>guid</returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "");
        }
    }
}
