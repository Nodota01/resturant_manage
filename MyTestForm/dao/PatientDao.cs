using ConsoleApp1.dba;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using ConsoleApp1.domain;
using Insight.Database;
using MyTestForm.Util;

//用到Insight框架！！！


namespace ConsoleApp1.dao
{
    class PatientDao
    {
        private static MySqlConnection Connection;
        private string TableName = "patient";

        public PatientDao() 
        {
            //获取连接
            Connection = DataBaseAccess.GetConnection();
        }

        //查询全部
        public IList<Patient> SelectAll()
        {
            var patients = Connection.QuerySql<Patient>("SELECT * FROM patient");
            return patients;
        }

        //条件查询
        public IList<Patient> Select(dynamic condition)
        {
            string SQLstr = SQLBuilder.BuildSelectSQL(condition, TableName);
            var patients = Connection.QuerySql<Patient>(SQLstr,(object)condition);
            return patients;
        }

        //成功返回1否则返回0
        public bool Delete(dynamic condition)
        {
            string SQLstr = SQLBuilder.BuildDeleteSQL(condition, TableName);
            int result = Connection.ExecuteSql(SQLstr, (object)condition);
            return result==1 ? true : false;
        }

        //添加
        public bool Insert(Patient patient) 
        {
            string SQLstr = SQLBuilder.BuildInsertSQL(patient, TableName);
            Console.WriteLine(SQLstr);
            int result = Connection.ExecuteSql(SQLstr, patient);
            //int result = Connection.ExecuteSql("INSERT patient(name, age, gender, native_place, is_merried, occupation, address) " +
             //           "VALUES(@name, @age, @gender, @native_place, @is_merried, @occupation, @address) ", patient);
            return result == 1 ? true : false;
        }

        //更新
        public bool Update(Patient patient)
        {
            patient.Update_date = DateTime.Now;
            string SQLstr = SQLBuilder.BuildUpdateSQL(patient, new {id = patient.Id }, TableName);
            Console.WriteLine(SQLstr);
            int result = Connection.ExecuteSql(SQLstr, patient);
            return result == 1 ? true : false;
        }

        
    }
}
