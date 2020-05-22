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
    class BillDao
    {
        private static MySqlConnection Connection;
        private string TableName = "bill";

        public BillDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Bill> SelectAll()
        {
            string SQL = "SELECT * FROM bill ORDER BY create_date ASC";
            var bills = Connection.QuerySql<Bill>(SQL);
            return bills;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Bill> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var bills = Connection.QuerySql<Bill>(SQL, (object)condition);
            return bills;
        }

        /// <summary>
        /// 条件模糊查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Bill> SelectLike(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectLikeSQL(condition, TableName);
            var bills = Connection.QuerySql<Bill>(SQL, (object)condition);
            return bills;
        }

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="condition">删除条件</param>
        ///// <returns>删除是否成功</returns>
        //public bool Delete(dynamic condition)
        //{
        //    //string SQL = SQLBuilder.BuildDeleteSQL(condition, TableName);
        //    //将是否删除设置为1
        //    string SQL = SQLBuilder.BuildUpdateSQL(new { is_deleted = true }, condition, TableName);
        //    int result = Connection.ExecuteSql(SQL, new { is_deleted = true, bill_id = condition.bill_id });
        //    return result == 1 ? true : false;
        //}

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="bill"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(Bill bill)
        {
            string SQL = SQLBuilder.BuildInsertSQL(bill, TableName);
            int result = Connection.ExecuteSql(SQL, bill);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="bill"></param>
        /// <returns>更新是否成功</returns>
        public bool Update(Bill bill)
        {
            var bi = new
            {
                bill_id = bill.bill_id,
                cost = bill.cost,
                type = bill.type,
                type_name = bill.type_name,
                type_id = bill.type_id
            };
            string SQL = SQLBuilder.BuildUpdateSQL(bi, new { bill_id = bill.bill_id }, TableName);
            int result = Connection.ExecuteSql(SQL, (Object)bi);
            return result == 1 ? true : false;
        }
    }
}
