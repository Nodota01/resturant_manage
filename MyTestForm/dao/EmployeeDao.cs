using ConsoleApp1.dba;
using Insight.Database;
using MySql.Data.MySqlClient;
using MyTestForm.domain;
using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.dao
{
    class EmployeeDao
    {
        private static MySqlConnection Connection;
        private string TableName = "employee";

        public EmployeeDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Employee> SelectAll()
        {
            string SQL = SQLBuilder.BuildSelectAllSQL(TableName);
            var employees = Connection.QuerySql<Employee>(SQL);
            return employees;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Employee> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var employees = Connection.QuerySql<Employee>(SQL, (object)condition);
            return employees;
        }

        /// <summary>
        /// 查看账户密码是否存在
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool IsRight(Employee employee)
        {
            string SQL = SQLBuilder.BuildSelectSQL(new
            {
                employee_name = employee.employee_name,
                password = employee.password
            }, TableName);
            var result = Connection.QuerySql<Employee>(SQL, employee);
            if(result.Count == 0)
            {
                return false;
            }
            else
            {
                employee.titel_name = result[0].titel_name;
                return true;
            }
        }

        /// <summary>
        /// 条件模糊查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Employee> SelectLike(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectLikeSQL(condition, TableName);
            var employees = Connection.QuerySql<Employee>(SQL, (object)condition);
            return employees;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition">删除条件</param>
        /// <returns>删除是否成功</returns>
        public bool Delete(dynamic condition)
        {
            string SQL = SQLBuilder.BuildDeleteSQL(condition, TableName);
            int result = Connection.ExecuteSql(SQL, (object)condition);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(Employee employee)
        {
            var em = new
            {
                employee_id = employee.employee_id,
                employee_name = employee.employee_name,
                gender = employee.gender,
                wage = employee.wage,
                password = employee.password
            };
            string SQL = SQLBuilder.BuildInsertSQL(em, TableName);
            int result = Connection.ExecuteSql(SQL, em);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>更新是否成功</returns>
        public bool Update(Employee employee)
        {
            string SQL = SQLBuilder.BuildUpdateSQL(employee, new { employee_id = employee.employee_id }, TableName);
            int result = Connection.ExecuteSql(SQL, employee);
            return result == 1 ? true : false;
        }
    }
}
