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
    class OrderDao
    {
        private static MySqlConnection Connection;
        private string TableName = "order";

        public OrderDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部未删除的数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Order> SelectAll()
        {
            string SQL = SQLBuilder.BuildSelectAllSQL(TableName);
            var orders = Connection.QuerySql<Order>(SQL);
            return orders;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Order> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var orders = Connection.QuerySql<Order>(SQL, (object)condition);
            return orders;
        }

        /// <summary>
        /// 条件模糊查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Order> SelectLike(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectLikeSQL(condition, TableName);
            var orders = Connection.QuerySql<Order>(SQL, (object)condition);
            return orders;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition">删除条件</param>
        /// <returns>删除是否成功</returns>
        public bool Delete(dynamic condition)
        {
            string SQL = SQLBuilder.BuildDeleteSQL(condition, TableName);
            int result = Connection.ExecuteSql(SQL, (Object)condition);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="order"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(Order order)
        {
            string SQL = SQLBuilder.BuildInsertSQL(order, TableName);
            int result = Connection.ExecuteSql(SQL, order);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="order"></param>
        /// <returns>更新是否成功</returns>
        public bool Update(Order order)
        {
            string SQL = SQLBuilder.BuildUpdateSQL(order, new { order_id = order.order_id }, TableName);
            int result = Connection.ExecuteSql(SQL, order);
            return result == 1 ? true : false;
        }
    }
}
