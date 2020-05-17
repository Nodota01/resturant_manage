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
    class DishesDao
    {
        private static MySqlConnection Connection;
        private string TableName = "dishes";

        public DishesDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部未删除的数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<Dishes> SelectAll()
        {
            string SQL = SQLBuilder.BuildSelectSQL(new { is_deleted = false }, TableName);
            var dishess = Connection.QuerySql<Dishes>(SQL, new { is_deleted = false });
            return dishess;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Dishes> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var dishess = Connection.QuerySql<Dishes>(SQL, (object)condition);
            return dishess;
        }

        /// <summary>
        /// 条件模糊查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<Dishes> SelectLike(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectLikeSQL(condition, TableName);
            var dishess = Connection.QuerySql<Dishes>(SQL, (object)condition);
            return dishess;
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
            int result = Connection.ExecuteSql(SQL, new { is_deleted = true, dishes_id = condition.dishes_id });
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(Dishes dishes)
        {
            string SQL = SQLBuilder.BuildInsertSQL(dishes, TableName);
            int result = Connection.ExecuteSql(SQL, dishes);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns>更新是否成功</returns>
        public bool Update(Dishes dishes)
        {
            string SQL = SQLBuilder.BuildUpdateSQL(dishes, new { dishes_id = dishes.dishes_id }, TableName);
            int result = Connection.ExecuteSql(SQL, dishes);
            return result == 1 ? true : false;
        }
    }
}
