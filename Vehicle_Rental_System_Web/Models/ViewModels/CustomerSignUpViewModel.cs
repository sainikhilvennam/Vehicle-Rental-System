using System.ComponentModel.DataAnnotations;

namespace Vehicle_Rental_System_Web.Models.ViewModels
{
    public class CustomerSignUpViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]{2,50}$", ErrorMessage = "Invalid name. Name should contain only alphabets and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number. Phone number should be 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.-]{2,100}$", ErrorMessage = "Invalid address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^[a-zA-Z0-9]{7,14}$", ErrorMessage = "Invalid password. Password should be 7-14 characters long and contain only letters and numbers.")]
        public string Password { get; set; }
    }
}
