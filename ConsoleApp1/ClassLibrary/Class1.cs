using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{    
    public class MySql
    {
        private MySqlConnection conn;

        public MySql()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = string.Format("server={0};user={1};password={2};database={3}", "192.168.3.127", "root", "1234", "test");
                conn.Open();
            }
            catch
            {
                Console.WriteLine("데이터베이스 접속 오류!");
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                return cmd.ExecuteReader();
            }
            catch
            {
                return null;
            }
        }

        public int NoneQuery(string sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
        }


    }
}
