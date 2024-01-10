using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection;

namespace ProjectDemo.Pages
{
    public class CartModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public CartModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public models.Cart tempCart { get; set; }
        public List<models.Cart> CartList { get; set; }
        public void OnGet()
        {
            string ConString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=Project6;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConString);
            string querystring = "Select * from Cart";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();
                CartList = new List<models.Cart> { };
                while (reader.Read())
                {
                    tempCart= new models.Cart();
                    tempCart.Delivery_time = reader[0].ToString();
                    tempCart.Quantity= int.Parse(reader[1].ToString());
                    tempCart.Delivery_Fee= double.Parse(reader[2].ToString());
                    tempCart.Voucher= reader[3].ToString();
                    tempCart.Total_Price = double.Parse(reader[4].ToString());
                    tempCart.Status_Voucher = reader[5].ToString();
                    tempCart.P_ID = int.Parse(reader[6].ToString());

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();

            }

        }
    }
}