using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace ProjectDemo.Pages
{
    public class ExploreModel : PageModel
    {
        private string connectionString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=Project6;Integrated Security=True";
        private SqlConnection con = new SqlConnection();

        public ExploreModel()
        {
            con.ConnectionString = connectionString;
        }

        public DataTable ReadTable(string table)
        {
            DataTable dt = new DataTable();
            string query = "select * from Prodcts";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                dt.Load(cmd.ExecuteReader());

            }
            catch (SqlException err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;

        }
    }

}
