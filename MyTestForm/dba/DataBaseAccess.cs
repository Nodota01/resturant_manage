using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Insight.Database;
using System.Drawing;

namespace ConsoleApp1.dba
{
    class DataBaseAccess
    {
        private const string SERVER = "106.15.207.39";
        private const string PORT = "3306";
        private const string DATABASE = "restaurant";
        private const string USER = "user02";
        private const string PASSWORD = "user02";
        private const bool POOLING = true;
        private static readonly MySqlConnection mySqlConnection;

        //静态构造函数
        static DataBaseAccess() 
        {
            string connstr = "server=" + SERVER + ";" +
                             "port=" + PORT + ";" +
                             "user=" + USER + ";" +
                             "password=" + PASSWORD + ";" +
                             "database=" + DATABASE + ";" +
                             "pooling=" + POOLING + ";";

            try
            {
                mySqlConnection = new MySqlConnection(connstr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static MySqlConnection GetConnection() {
            return mySqlConnection;
        }
    }
}
