using ConsoleApp1.dba;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MyTestForm.domain;
using Insight.Database;
using MyTestForm.Util;

namespace MyTestForm.dao
{
    class DishedConsumeDao
    {
        private static MySqlConnection Connection;
        private string TableName = "dishes_consume";

        public DishedConsumeDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 获取材料列表
        /// </summary>
        /// <param name="dishes_id">给定菜品id</param>
        /// <returns>材料id列表</returns>
        public IList<string> GetConsumeMeterials(string dishes_id)
        {
            var con = new { dishes_id = dishes_id };
            var meterials = Connection.QuerySql<string>("STLECT meterial_id FROM dishes_consume WHERE dishes_id=@dishes_id ",
                (Object)con);
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
            int result = Connection.ExecuteSql(SQL);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>添加是否成功</returns>
        public bool Insert(string dishes_id, string meterial_id)
        {
            var pare = new
            {
                dishes_id = dishes_id,
                meterial_id = meterial_id
            };
            string SQL = SQLBuilder.BuildInsertSQL(pare, TableName);
            int result = Connection.ExecuteSql(SQL, pare);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>更新是否成功</returns>
        public bool Update(string dishes_id, string meterial_id)
        {
            var pare = new
            {
                dishes_id = dishes_id,
                meterial_id = meterial_id
            };
            string SQL = SQLBuilder.BuildUpdateSQL(pare, new { dishes_id = dishes_id }, TableName);
            int result = Connection.ExecuteSql(SQL, pare);
            return result == 1 ? true : false;
        }
    }
}
