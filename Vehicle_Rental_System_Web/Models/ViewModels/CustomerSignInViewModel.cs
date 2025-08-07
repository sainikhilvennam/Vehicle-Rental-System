using System.ComponentModel.DataAnnotations;

namespace Vehicle_Rental_System_Web.Models.ViewModels
{
    public class CustomerSignInViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^[a-zA-Z0-9]{7,14}$", ErrorMessage = "Invalid password. Password should be 7-14 characters long and contain only letters and numbers.")]
        public string Password { get; set; }
    }
}

