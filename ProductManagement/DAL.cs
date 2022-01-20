using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
namespace ProductManagement
{
    class DAL
    {
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            // Initialization
            int rowCount = 0;
            SqlConnection sqlConnection = new SqlConnection(DatabaseUtil.DbConnection());
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                // Settings  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 60;
                sqlCommand.Parameters.AddRange(parameters);

                // Open
                sqlConnection.Open();

                // Result
                rowCount = sqlCommand.ExecuteNonQuery();

                // Close 
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // ClosE  
                sqlConnection.Close();

                throw ex;
            }

            return rowCount;
        }

        public static IList<T> ExecuteQuery<T>(string query, SqlParameter[] parameters, Func<IDataRecord, T> func)
        {
            // Initialization
            IDataReader dr = null;
            
            var sqlConnection = new SqlConnection(DatabaseUtil.DbConnection());
            var sqlCommand = new SqlCommand();
            var result = new List<T>();
            try
            {
                // Settings
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 60;
                sqlCommand.Parameters.AddRange(parameters);

                // Open
                sqlConnection.Open();

                // Result
                dr = sqlCommand.ExecuteReader();

                while (dr.Read()){
                    result.Add(func(dr));
                }

                // Close
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close
                sqlConnection.Close();

                throw ex;
            }

            return result;
        }

        public static int ExecuteNonDeleteQuery(string query)
        {
            // Initialization
            int rowCount = 0;
            
            SqlConnection sqlConnection = new SqlConnection(DatabaseUtil.DbConnection());
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                // Settings 
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 60;
                

                // Open
                sqlConnection.Open();

                // Result
                rowCount = sqlCommand.ExecuteNonQuery();

                // Close
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close 
                sqlConnection.Close();

                throw ex;
            }

            return rowCount;
        }

        public static int ExecuteNonQueryNoPar(string query)
        {
            // Initialization  
            int rowCount = 0;
            
            SqlConnection sqlConnection = new SqlConnection(DatabaseUtil.DbConnection());
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                // Settings
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 60;
                

                // Open  
                sqlConnection.Open();

                // Result 
                rowCount = sqlCommand.ExecuteNonQuery();

                // Close  
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                // Close  
                sqlConnection.Close();
                Trace.WriteLine(ex);
                throw ex;
            }

            return rowCount;
        }
    }
}
