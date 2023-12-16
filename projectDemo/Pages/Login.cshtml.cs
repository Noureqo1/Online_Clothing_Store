using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace ProjectDemo.Pages
{

    public class loginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class LoginModel : PageModel
    {
        public void OnPost()
        {
            // Implement login logic here, checking username and password
            // against your chosen authentication system (e.g., database, identity provider)

            // If login successful, redirect to Home page
            // Otherwise, set ErrorMessage property for display on the page

            // For example:
            //if (/* username and password match */)
            //{
            //    Response.Redirect("/Home");
            //}
            //else
            //{
            //    Model.ErrorMessage = "Invalid username or password.";
            //}
        }
    }
}
