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
    class VisitRecordDao
    {
        private static MySqlConnection Connection;
        private string TableName = "visit_record";

        public VisitRecordDao()
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>查询结果</returns>
        public IList<VisitRecord> SelectAll()
        {
            string SQL = SQLBuilder.BuildSelectAllSQL(TableName);
            var records = Connection.QuerySql<VisitRecord>(SQL, new { is_deleted = false });
            return records;
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>查询结果</returns>
        public IList<VisitRecord> Select(dynamic condition)
        {
            string SQL = SQLBuilder.BuildSelectSQL(condition, TableName);
            var records = Connection.QuerySql<VisitRecord>(SQL, (object)condition);
            return records;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition">删除条件</param>
        /// <returns>删除是否成功</returns>
        public bool Delete(dynamic condition)
        {
            string SQL = SQLBuilder.BuildDeleteSQL(condition, TableName);
            int result = Connection.ExecuteSql(SQL,(Object)condition);
            return result == 1 ? true : false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="visitRecord"></param>
        /// <returns>添加是否成功</returns>
        public bool Insert(VisitRecord visitRecord)
        {
            //不插入访问时间，数据库自动填充默认值
            var visit = new { visit_record_id = visitRecord.visit_record_id, desk_id = visitRecord.desk_id, 
                            consumer_num = visitRecord.consumer_num};
            string SQL = SQLBuilder.BuildInsertSQL(visit, TableName);
            int result = Connection.ExecuteSql(SQL, (Object)visit);
            return result == 1 ? true : false;
        }
    }
}
