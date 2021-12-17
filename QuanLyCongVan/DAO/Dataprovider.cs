using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongVan.DAO
{
    class Dataprovider
    {

        //private SqlConnection con = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog = Project_cuoiki; Integrated Security = True");

        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog = QLCongVan_CNPM; Integrated Security = True"))
            {
                // mở kết nối

                con.Open();
                SqlCommand command = new SqlCommand(query, con);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public DataTable InsertQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=TRANPHAI\SQLEXPRESS;Initial Catalog = QLCongVan_CNPM; Integrated Security = True"))
            {
                // mở kết nối

                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
            }
            return data;
        }
    }
}
