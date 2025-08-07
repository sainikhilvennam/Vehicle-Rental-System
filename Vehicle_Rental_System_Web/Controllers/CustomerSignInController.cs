using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vehicle_Rental_System.BLL;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.DAO;
using Vehicle_Rental_System.MODEL;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System_Web.Models.ViewModels;

namespace Vehicle_Rental_System_Web.Controllers
{
    public class CustomerSignInController : Controller
    {
        private readonly CustomerBLL _customerBLL;
        private readonly VehicleBLL _vehicleBLL;
        
        public CustomerSignInController()
        {
            _customerBLL = new CustomerBLL();
            _customerBLL.UseStorage(new CustomerDAL());
            
            _vehicleBLL = new VehicleBLL();
            _vehicleBLL.UseStorage(new VehicleDAL());
        }

        // GET: Customer signIn
        [HttpGet]
        public IActionResult CustomerSignIn_Web()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerSignIn_Web(CustomerSignInViewModel model )
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                bool result = await _customerBLL.SignInAsync(model.EmailId, model.Password);
                if (result)
                {
                    // Store customer session
                    HttpContext.Session.SetString("CustomerEmail", model.EmailId);
                    TempData["SuccessMessage"] = "Welcome! You have successfully signed in.";
                    return RedirectToAction("display"); // or wherever you want to redirect
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"SignIn failed: {ex.Message}");
                return View(model);
            }
        }

        public async Task<IActionResult> display()
        {
            // Check if customer is signed in
            var customerEmail = HttpContext.Session.GetString("CustomerEmail");
            if (string.IsNullOrEmpty(customerEmail))
            {
                return RedirectToAction("CustomerSignIn_Web");
            }

            try
            {
                // Get all vehicles from database
                var vehicles = await _vehicleBLL.VehicleGetAllAsync();
                
                // Pass customer email to view
                ViewBag.CustomerEmail = customerEmail;
                
                return View(vehicles);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading vehicles: {ex.Message}";
                return View(new List<Vehicle>());
            }
        }


        
    }
}
