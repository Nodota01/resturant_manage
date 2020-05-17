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
    class MeterialDao
    {
        private static MySqlConnection Connection;
        private string TableName = "meterial";

        public MeterialDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部未删除的数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Meterial> SelectAll()
        {
            string SQL = SQLBuilder.BuildSelectSQL(new { is_deleted = false }, TableName);
            var meterials = Connection.QuerySql<Meterial>(SQL, new { is_deleted = false });
            return meterials;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Meterial> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var meterials = Connection.QuerySql<Meterial>(SQL, (object)condition);
            return meterials;
        }

        /// <summary>
        /// 条件模糊查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Meterial> SelectLike(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectLikeSQL(condition, TableName);
            var meterials = Connection.QuerySql<Meterial>(SQL, (object)condition);
            return meterials;
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
            int result = Connection.ExecuteSql(SQL, new { is_deleted = true, meterial_id = condition.meterial_id });
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="meterial"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(Meterial meterial)
        {
            string SQL = SQLBuilder.BuildInsertSQL(meterial, TableName);
            int result = Connection.ExecuteSql(SQL, meterial);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="meterial"></param>
        /// <returns>更新是否成功</returns>
        public bool Update(Meterial meterial)
        {
            string SQL = SQLBuilder.BuildUpdateSQL(meterial, new { meterial_id = meterial.meterial_id }, TableName);
            int result = Connection.ExecuteSql(SQL, meterial);
            return result == 1 ? true : false;
        }
    }
}
