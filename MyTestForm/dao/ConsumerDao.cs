using ConsoleApp1.dba;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MyTestForm.domain;
using Insight.Database;
using MyTestForm.Util;

namespace MyTestForm.dao
{
    class ConsumerDao
    {
        private static MySqlConnection Connection;
        private string TableName = "consumer";

        public ConsumerDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Consumer> SelectAll()
        {
            string SQL = SQLBuilder.BuilSelectAllSQL(TableName);
            var consumers = Connection.QuerySql<Consumer>(SQL);
            return consumers;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Consumer> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var consumers = Connection.QuerySql<Consumer>(SQL, (object)condition);
            return consumers;
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
        /// <param name="consumer"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(Consumer consumer)
        {
            string SQL = SQLBuilder.BuildInsertSQL(consumer, TableName);
            int result = Connection.ExecuteSql(SQL, consumer);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="consumer"></param>
        /// <returns>更新是否成功</returns>
        public bool Update(Consumer consumer)
        {
            string SQL = SQLBuilder.BuildUpdateSQL(consumer, new { consumer_id = consumer.consumer_id }, TableName);
            int result = Connection.ExecuteSql(SQL, consumer);
            return result == 1 ? true : false;
        }
    }
}
