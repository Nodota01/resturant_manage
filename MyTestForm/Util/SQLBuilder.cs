using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.Util
{
    class SQLBuilder
    {

        public static string BuildSelectAllSQL(string tableName)
        {
            return "SELECT * FROM " + tableName;
        }

        /// <summary>
        /// 拼接查询SQL语句
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="tableName">表名</param>
        /// <returns>SQL语句</returns>
        public static string BuildSelectSQL(dynamic condition, string tableName)
        {
            //获取匿名类属性名
            PropertyInfo[] properties = condition.GetType().GetProperties();
            var propStr = new List<string>();
            foreach(PropertyInfo property in properties)
            {
                propStr.Add(property.Name);
            }
            //拼接
            StringBuilder strBuilder = new StringBuilder(255);
            strBuilder.Append("SELECT * FROM ").Append(tableName).Append(" WHERE ");
            if (propStr.Count == 1)
            {
                strBuilder.Append(propStr[0]).Append("=").Append("@").Append(propStr[0]);
            }
            else
            {
                foreach(string propName in propStr)
                {
                    strBuilder.Append(propName).Append("=").Append("@").Append(propName);
                    strBuilder.Append(" AND ");
                }
                strBuilder.Append(" 0=0 ");
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// 拼接模糊查询语句
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string BuildSelectLikeSQL(dynamic condition, string tableName)
        {
            PropertyInfo[] conProperties = condition.GetType().GetProperties();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("SELECT * FROM ").Append(tableName).Append(" WHERE ");
            if (conProperties.Length == 1)
            {
                strBuilder.Append(conProperties[0].Name).Append(" LIKE ").Append("\"%\"@").Append(conProperties[0].Name).Append("\"%\"");
            }
            else
            {
                foreach (PropertyInfo property in conProperties)
                {
                    strBuilder.Append(conProperties[0].Name).Append(" LIKE ").Append("\"%\"@").Append(conProperties[0].Name).Append("\"%\"@");
                    strBuilder.Append(" AND ");
                }
                strBuilder.Append(" 0=0 ");
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// 拼接更新SQL语句
        /// </summary>
        /// <param name="obj">更新实体</param>
        /// <param name="condition">更新条件</param>
        /// <param name="tableName">表名</param>
        /// <returns>SQL语句</returns>
        public static string BuildUpdateSQL(dynamic obj, dynamic condition, string tableName)
        {
            //获取更新内容和条件名
            PropertyInfo[] objProperties = obj.GetType().GetProperties();
            PropertyInfo[] conProperties = condition.GetType().GetProperties();
            //拼接更新内容
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(" UPDATE ").Append(tableName).Append(" SET ");
            foreach(PropertyInfo property in objProperties)
            {
                strBuilder.Append(property.Name).Append("=@").Append(property.Name).Append(",");
            }
            //去掉最后的','
            strBuilder.Remove(strBuilder.Length - 1, 1);
            strBuilder.Append(" WHERE ");
            //拼接条件
            if (conProperties.Length == 1)
            {
                strBuilder.Append(conProperties[0].Name).Append("=").Append("@").Append(conProperties[0].Name);
            }
            else
            {
                foreach(PropertyInfo property in conProperties)
                {
                    strBuilder.Append(property.Name).Append("=").Append("@").Append(property.Name);
                    strBuilder.Append(" AND ");
                }
                strBuilder.Append(" 0=0 ");
            }
            return strBuilder.ToString();
        }

        /// <summary>
        /// 拼接插入SQL语句
        /// </summary>
        /// <param name="obj">插入实体</param>
        /// <param name="tableName">表名</param>
        /// <returns>SQL语句</returns>
        public static string BuildInsertSQL(dynamic obj, string tableName)
        {
            PropertyInfo[] objProperties = obj.GetType().GetProperties();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(" INSERT ").Append(tableName).Append(" ( ");
            foreach(PropertyInfo property in objProperties)
            {
                strBuilder.Append(property.Name).Append(",");
            }
            //去掉最后的','
            strBuilder.Remove(strBuilder.Length - 1, 1);
            strBuilder.Append(" ) ").Append(" VALUES ").Append(" ( ");
            foreach (PropertyInfo property in objProperties)
            {
                strBuilder.Append("@").Append(property.Name).Append(",");
            }
            strBuilder.Remove(strBuilder.Length - 1, 1);
            strBuilder.Append(" ) ");
            return strBuilder.ToString();
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="condition">删除条件</param>
        /// <param name="tableName">表名</param>
        /// <returns>SQL语句</returns>
        public static string BuildDeleteSQL(dynamic condition, string tableName)
        {
            PropertyInfo[] conProperties = condition.GetType().GetProperties();
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(" DELETE FROM ").Append(tableName).Append(" WHERE ");
            if (conProperties.Length == 1)
            {
                strBuilder.Append(conProperties[0].Name).Append("=").Append("@").Append(conProperties[0].Name);
            }
            else
            {
                foreach (PropertyInfo property in conProperties)
                {
                    strBuilder.Append(property.Name).Append("=").Append("@").Append(property.Name);
                    strBuilder.Append(" AND ");
                }
                strBuilder.Append(" 0=0 ");
            }
            return strBuilder.ToString();
        }
    }
}
