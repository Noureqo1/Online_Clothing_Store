using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjectDemo.models
{
    [BindProperties(SupportsGet = true)]
    public class users
    {
        [Required]
        public required string ID { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public required string UserName { get; set; }
        public String? Email { get; set; }
        public int? Pasword { get; set; }
        public DateTime? BirthDate { get; set; }
        public object? Password { get; internal set; }
        public object? ConfirmPassword { get; internal set; }
        public object? Name { get; internal set; }
        public object PhoneNumber { get; internal set; }
    }
}
