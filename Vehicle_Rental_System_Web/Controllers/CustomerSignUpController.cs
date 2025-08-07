using Microsoft.AspNetCore.Mvc;
using Vehicle_Rental_System.BLL;
using Vehicle_Rental_System.DAO;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System_Web.Models.ViewModels;
using Vehicle_Rental_System.DAL;
using System.Threading.Tasks;

namespace Vehicle_Rental_System_Web.Controllers
{
    public class CustomerSignUpController : Controller
    {
        private readonly CustomerBLL _customerBLL;

        public CustomerSignUpController()
        {
            _customerBLL = new CustomerBLL();
            _customerBLL.UseStorage(new CustomerDAL()); // Use JSON storage
        }

        // GET: Show customer signup form
        [HttpGet]
        public IActionResult CustomerSignUp_Web()
        {
            return View();
        }

        // POST: Process signup form
        [HttpPost]
        public async Task<IActionResult> CustomerSignUp_Web(CustomerSignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Check if email exists
                bool emailExists = await _customerBLL.IsEmailExistsAsync(model.EmailId);
                if (emailExists)
                {
                    ModelState.AddModelError("EmailId", "Email already exists.");
                    return View(model);
                }

                // Call your BLL method to add customer
                await _customerBLL.CustomerAddAsync(
                    model.Name,
                    model.PhoneNumber,
                    model.EmailId,
                    model.Address,
                    model.Password
                );

                TempData["SuccessMessage"] = "Form submitted successfully";
                return RedirectToAction("Success");
            }
            catch (IncorrectUserDataException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Registration failed: {ex.Message}");
                return View(model);
            }
        }

        // GET: Show success page
        public IActionResult Success()
        {
            return View();
        }


    }
}
