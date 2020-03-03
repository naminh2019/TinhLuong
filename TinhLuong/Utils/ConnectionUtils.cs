using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace TinhLuong
{
    public class ConnectionUtils
    {
        public static string strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True;Connection Timeout=30;Connection Lifetime=0;Min Pool Size=0;Max Pool Size=100;Pooling=true;";
        //public static SqlConnection connection;
        //public static SqlConnection getConnection()
        //{
        //    if (connection == null)
        //    {
        //        connection = new SqlConnection(strConnect);
        //    }
        //    if (connection.State == ConnectionStae.Closed)
        //        connection.Open();
        //    return connection;
        //}
        public static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(strConnect);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        public static DataTable findAll(String query)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = getConnection();
                DataTable dataTable = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static void ExeCuteNonquery(SqlCommand cmd)
        {

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = getConnection();
                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public static void ExeCuteReader(SqlCommand cmd)
        {

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = getConnection();
                cmd.Connection = sqlConnection;
                cmd.ExecuteReader();
            }
            catch
            {
                throw new Exception("Error ");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static int Update(SqlCommand cmd)
        {

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = getConnection();
                cmd.Connection = sqlConnection;
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static int ExecuteScalar(SqlCommand cmd)
        {

            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = getConnection();
                cmd.Connection = sqlConnection;
                int result = (Int32) cmd.ExecuteScalar();
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }


}
