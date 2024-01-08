using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectDemo.Pages
{
    [BindProperties(SupportsGet = true)]
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public models.users User { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Validate password confirmation
            if (User.Password != User.ConfirmPassword)
            {
                ErrorMessage = "Password and Confirm Password do not match.";
                return Page();
            }

            // Connect to the database
            string connectionString = ConfigurationManager.ConnectionStrings["Data Source=LAPTOP-OH72TN5U;Initial Catalog=PROJECT1;Integrated Security=True"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert the user data into the database
                string query = "INSERT INTO users (Name, Email, PhoneNumber, Password) VALUES (@Name, @Email, @PhoneNumber, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", User.Name);
                command.Parameters.AddWithValue("@Email", User.Email);
                command.Parameters.AddWithValue("@PhoneNumber", User.PhoneNumber);
                command.Parameters.AddWithValue("@Password", User.Password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // User registration successful
                    // You can implement your success logic here

                    return RedirectToPage("/Index");
                }
                else
                {
                    // Failed to insert user data into the database
                    ErrorMessage = "An error occurred during registration. Please try again.";
                }
            }

            return Page();
            
        }
    }
}
