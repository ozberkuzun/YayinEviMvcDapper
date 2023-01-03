using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;

namespace YayınEviMvcDapper.Models
{
    public class DP
    {
        private static string connectionString = @"Server=316-16\SQLEXPRESS;Database=KitapEvi;uid=sa;pwd=I$kur2022#!";


        public static void ExecuteWReturn(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                baglanti.Execute(procadi, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }



        public static T ExecuteReturnScalar<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                return (T)Convert.ChangeType(baglanti.ExecuteScalar(procadi, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }


        public static IEnumerable<T> ReturnList<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                return baglanti.Query<T>(procadi, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }

}