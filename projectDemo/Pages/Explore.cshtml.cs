using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ProjectDemo.Pages
{
    public class ExploreModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public ExploreModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public models.users tempUser { get; set; }
        public List<models.users> usersList { get; set; }
        public List<models.Products> products { get; set; }
        public void OnGET()
        {
            string connectionString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=projectdemo;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string query1 = "SELECT * FROM users";

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query1, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                usersList = new List<models.users>();
                while (reader.Read())
                {
                    tempUser = new models.users();

                    tempUser.id =int.Parse(reader[0].ToString());
                    tempUser.name = reader[1].ToString();
                    tempUser.email = reader[2].ToString();

                    usersList.Add(tempUser);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
