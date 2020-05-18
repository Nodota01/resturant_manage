using ConsoleApp1.dba;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MyTestForm.domain;
using Insight.Database;
using MyTestForm.Util;

namespace MyTestForm.dao
{
    class ConsumeDao
    {
        private static MySqlConnection Connection;
        private string TableName = "dishes_consume";

        public ConsumeDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 获取材料列表
        /// </summary>
        /// <param name="dishes_id">给定菜品id</param>
        /// <returns>材料id列表</returns>
        public IList<Consume> GetConsumeMeterials(string dishes_id)
        {
            var con = new { dishes_id = dishes_id };
            string SQL = SQLBuilder.BuildSelectSQL(con,TableName);
            var meterials = Connection.QuerySql<Consume>(SQL,(Object)con);
            return meterials;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询结果集</param>
        /// <returns></returns>
        public IList<Consume> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var meterials = Connection.QuerySql<Consume>(SQL, (Object)condition);
            return meterials;
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
        /// <returns>添加是否成功</returns>
        public bool Insert(Consume consume)
        {
            string SQL = SQLBuilder.BuildInsertSQL(consume, TableName);
            int result = Connection.ExecuteSql(SQL, consume);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>更新是否成功</returns>
        public bool Update(Consume consume)
        {
            string SQL = SQLBuilder.BuildUpdateSQL(consume, new { dishes_id = consume.dishes_id }, TableName);
            int result = Connection.ExecuteSql(SQL, consume);
            return result == 1 ? true : false;
        }
    }
}
