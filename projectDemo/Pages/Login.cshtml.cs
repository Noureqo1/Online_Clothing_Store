using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectDemo.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public models.users User { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Connect to the database
            string connectionString = ConfigurationManager.ConnectionStrings["Data Source=LAPTOP-OH72TN5U;Initial Catalog=PROJECT1;Integrated Security=True"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Query the database to check if the user credentials match
                string query = "SELECT COUNT(*) FROM users WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", User.Email);
                command.Parameters.AddWithValue("@Password", User.Pasword);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    // User credentials match, log in the user
                    // You can implement your login logic here

                    return RedirectToPage("/Login");
                }
                else
                {
                    // User credentials do not match, display an error message
                    ErrorMessage = "Invalid credentials. Please try again.";
                }
            }

            return Page();
        }
    }
}