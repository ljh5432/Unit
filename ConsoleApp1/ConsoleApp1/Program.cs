﻿using ClassLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Class1 c1 = new Class1();
            Console.WriteLine(c1.Add(1, 3));
            */

            ClassLibrary.MySql my = new ClassLibrary.MySql();

            // 테이블 데이터 확인 부분
            string sql = "select * from Member";
            MySqlDataReader sdr = my.Reader(sql);
            int cnt = 0;
            while (sdr.Read())
            {
                cnt++;
            }
            sdr.Close();
            Console.WriteLine("총 데이터 수 : {0}", cnt);

            // 입력 처리 부분
            sql = "insert into Member (mId, mPass, mName)  values ('test','1','테스터')";
            int status = my.NoneQuery(sql);
            Console.WriteLine("데이터 삽입 결과 : {0}", status);

            // 입력한 데이터 PK 가져오기 
            sql = "select max(mNo) as mNo from Member";
            sdr = my.Reader(sql);
            int mNo = 0;
            while (sdr.Read())
            {
                mNo = Convert.ToInt32(sdr["mNo"]);
            }
            sdr.Close();
            Console.WriteLine("mNo = {0}", mNo);

            // 수정 처리 부분
            sql = string.Format("update Member set mName = '테스터2' where mNo = {0}", mNo);
            status = my.NoneQuery(sql);
            Console.WriteLine("데이터 수정 결과 : {0}", status);

            // 삭제 처리 부분
            sql = string.Format("update Member set delYn = 'Y' where mNo = {0}", mNo);
            status = my.NoneQuery(sql);
            Console.WriteLine("데이터 삭제 결과 : {0}", status);

        }
    }
}
