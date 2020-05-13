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
        /// 查询全部未删除的数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Consumer> SelectAll()
        {
            string SQL = SQLBuilder.BuildSelectSQL(new {is_deleted = false },TableName);
            var consumers = Connection.QuerySql<Consumer>(SQL,new { is_deleted = false });
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
        /// 条件模糊查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Consumer> SelectLike(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectLikeSQL(condition, TableName);
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
            //string SQL = SQLBuilder.BuildDeleteSQL(condition, TableName);
            //将是否删除设置为1
            string SQL = SQLBuilder.BuildUpdateSQL(new { is_deleted = true }, condition, TableName);
            int result = Connection.ExecuteSql(SQL, new { is_deleted = true, consumer_id = condition.consumer_id });
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
