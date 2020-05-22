using ConsoleApp1.dba;
using Insight.Database;
using MySql.Data.MySqlClient;
using MyTestForm.domain;
using MyTestForm.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestForm.dao
{
    class DeskDao
    {
        private static MySqlConnection Connection;
        private string TableName = "desk";

        public DeskDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部未删除数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Desk> SelectAll()
        {
            string SQL = "SELECT * FROM desk WHERE is_deleted=0 ORDER BY desk_name ASC";
            var records = Connection.QuerySql<Desk>(SQL);
            return records;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Desk> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var records = Connection.QuerySql<Desk>(SQL, (Object)condition);
            return records;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="desk"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(Desk desk)
        {
            //其余取默认值
            var deskI = new { desk_id = desk.desk_id, desk_name = desk.desk_name };
            string SQL = SQLBuilder.BuildInsertSQL(deskI, TableName);
            int result = Connection.ExecuteSql(SQL, deskI);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="desk"></param>
        /// <returns>更新是否成功</returns>
        public bool Update(Desk desk)
        {
            string SQL = SQLBuilder.BuildUpdateSQL(desk, new { desk_id = desk.desk_id }, TableName);
            int result = Connection.ExecuteSql(SQL, desk);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 设置桌子的访问记录
        /// </summary>
        /// <param name="desk"></param>
        /// <returns></returns>
        public bool SetVisitRecord(Desk desk)
        {
            var des = new { desk_id = desk.desk_id, current_record = desk.current_record };
            string SQL = SQLBuilder.BuildUpdateSQL(des,
                new { desk_id = desk.desk_id },
                TableName);
            int result = Connection.ExecuteSql(SQL, des);
            return result == 1 ? true : false;
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
            int result = Connection.ExecuteSql(SQL, new { is_deleted = true, desk_id = condition.desk_id });
            return result == 1 ? true : false;
        }



    }
}
