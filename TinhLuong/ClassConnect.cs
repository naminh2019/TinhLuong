using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TinhLuong
{

    public class ClassConnect
    {
        public static string strConnect = "Data Source=.;Initial Catalog=Quanlyxuong;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(strConnect);
            try
            {
                connection.Open();
            }
            catch //(Exception ex)
            {
                //("error" + ex.Message);
            }
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
    }
    public class clsChamCong
    {
        public int MaNhanVien { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan InMorning { get; set; }
        public TimeSpan OutMorning { get; set; }
        public TimeSpan InAfternoon { get; set; }
        public TimeSpan OutAfternoon { get; set; }
        public TimeSpan InOvertime { get; set; }
        public TimeSpan OutOvertime { get; set; }
        public TimeSpan NumberOvertime { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}