using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle_Rental_System.BLL;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.DAO;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System.Interfaces;
using Vehicle_Rental_System.MODEL;
using Vehicle_Rental_System.Validations;

namespace Vehicle_Rental_System
{
    public class Program
    {
        static CustomerBLL customerBLL = new CustomerBLL();
        static VehicleBLL vehicleBLL = new VehicleBLL();
        static bool storageConfigured = false;
        static int defaultStorageChoice = 1; // Default to SQLgit add
        
        static async Task Main(string[] args)
        {
            EnsureStorageSetup();

            await ShowMainMenu();
        }
        
        static void EnsureStorageSetup()
        {
            if (!storageConfigured)
            {
                ConfigureStorage(defaultStorageChoice);
                storageConfigured = true;
            }
        }
        
        static void ConfigureStorage(int choice)
        {
            ICustomerStorage customerStorage;
            IVehicleStorage vehicleStorage;
            
            if (choice == 1)
            {
                customerStorage = new CustomerDAL();
                vehicleStorage = new VehicleDAL();
            }
            else
            {
                customerStorage = new JSonCustomerStorageDAL();
                vehicleStorage = new JSonVehicleStorageDAL();
            }
            
            customerBLL.UseStorage(customerStorage);
            vehicleBLL.UseStorage(vehicleStorage);
        }
        
        static async Task ShowMainMenu()
        {
            bool temp = true;
            while (temp)
            {
                Console.WriteLine("\n=== Vehicle Rental System ===");
                Console.WriteLine("1. Customer Sign up");
                Console.WriteLine("2. Customer Sign in");
                Console.WriteLine("3. Admin Sign in");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = CustomValidations.GetValidatedInputInt("Enter your choice: ", CustomValidations.IsValidId);
                switch (choice)
                {
                    case 1:
                        await CustomerAddAsync();
                        Console.WriteLine("\nPlease sign in with your account:");
                        await CxSignInAsync();
                        break;
                    case 2:
                        await CxSignInAsync();
                        break;
                    case 3:
                        await AdSignInAsync();
                        break;
                    case 4:
                        temp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }
            }
        }
        
        static async Task ShowCustomerMenu()
        {
            bool customerTemp = true;
            while (customerTemp)
            {
                Console.WriteLine("\n=== Customer Menu ===");
                Console.WriteLine("1. View All Vehicles");
                //Console.WriteLine("2. View Vehicle by ID");
                Console.WriteLine("2. Back to Main Menu");
                Console.Write("Enter your choice: ");

                int choice = CustomValidations.GetValidatedInputInt("Enter your choice: ", CustomValidations.IsValidId);
                switch (choice)
                {
                    case 1:
                        await VehicleGetAllAsync();
                        break;
                    //case 2:
                    //    await VehicleGetByIdAsync();
                    //    break;
                    case 2:
                        customerTemp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }
            }
        }
        
        static async Task ShowAdminMenu()
        {
            bool adminTemp = true;
            while (adminTemp)
            {
                Console.WriteLine("\n=== Admin Menu ===");
                Console.WriteLine("1. Change Storage Type");
                Console.WriteLine("2. View All Customers");
                Console.WriteLine("3. View All Vehicles");
                Console.WriteLine("4. Add Vehicle");
                Console.WriteLine("5. Delete Vehicle");
                Console.WriteLine("6. View Customer by ID");
                Console.WriteLine("7. Delete Customer");
                Console.WriteLine("8. Get all customer and vehicle details");
                Console.WriteLine("9. Back to Main Menu");
                //Console.Write("Enter your choice: ");
                
                //int choice = Convert.ToInt32(Console.ReadLine());
                int choice = CustomValidations.GetValidatedInputInt("Enter your choice: ", CustomValidations.IsValidId);
                switch (choice)
                {
                    case 1:
                        AdminChangeStorage();
                        break;
                    case 2:
                        await CustomerGetAllAsync();
                        break;
                    case 3:
                        await VehicleGetAllAsync();
                        break;
                    case 4:
                        await VehicleAddAsync();
                        break;
                    case 5:
                        await VehicleDeleteAsync();
                        break;
                    case 6:
                        await CustomerGetByIdAsync();
                        break;
                    case 7:
                        await CustomerDeleteAsync();
                        break;
                    case 8:
                        Task<List<CustomerSignUp>> t1 = CustomerGetAllAsync();
                        Task<List<Vehicle>> t2 = VehicleGetAllAsync();
                        await Task.WhenAll(t1, t2);
                        break;
                    case 9:
                        adminTemp = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again!");
                        break;
                }
            }
        }
        
        static void AdminChangeStorage()
        {
            Console.WriteLine("\nCurrent Storage: " + (defaultStorageChoice == 1 ? "SQL" : "JSON"));
            Console.WriteLine("1. SQL");
            Console.WriteLine("2. JSON");
            Console.Write("Select new storage type: ");

            int choice = CustomValidations.GetValidatedInputInt("Enter your choice: ", CustomValidations.IsValidId);
            if (choice == 1 || choice == 2)
            {
                defaultStorageChoice = choice;
                ConfigureStorage(defaultStorageChoice);
                Console.WriteLine("Storage changed to: " + (choice == 1 ? "SQL" : "JSON"));
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }


        static async Task CustomerAddAsync()    
        {
            string name = CustomValidations.GetValidatedInputString("Enter Name: ", CustomValidations.IsValidName);
            string phone = CustomValidations.GetValidatedInputString("Enter Phone Number: ", CustomValidations.IsValidPhoneNumber);
            string email = CustomValidations.GetValidatedInputString("Enter Email ID: ", CustomValidations.IsValidEmail);
            string address = CustomValidations.GetValidatedInputString("Enter Address: ", CustomValidations.IsValidAddress);
            string password = CustomValidations.GetValidatedInputString("Enter Password: ", CustomValidations.IsValidPassword);

            try
            {
                CustomerSignUp cSu = await customerBLL.CustomerAddAsync(name, phone, email, address, password);
                Console.WriteLine("Customer Added Successfully");
            }
            catch (IncorrectUserDataException ex)
            {
                Console.WriteLine($"Validation Failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Registration Failed: {ex.Message}");
            }
        }

        static async Task<CustomerSignUp> CustomerGetByIdAsync()
        {
            int customerId = CustomValidations.GetValidatedInputInt("Enter Customer ID: ", CustomValidations.IsValidId);
            try
            {
                CustomerSignUp customer = await customerBLL.CustomerGetByIdAsync(customerId);
                if (customer != null)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"ID:           {customer.Id}");
                    Console.WriteLine($"Name:         {customer.Name}");
                    Console.WriteLine($"Phone:        {customer.PhoneNumber}");
                    Console.WriteLine($"Email:        {customer.EmailId}");
                    Console.WriteLine($"Address:      {customer.Address}");
                    //Console.WriteLine($"Password:     {customer.Password}");
                    Console.WriteLine("------------------------------");
                }
                else
                {
                    Console.WriteLine($"No customer exists with ID {customerId}");
                    //return null;
                }
                return customer;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static async Task<List<CustomerSignUp>> CustomerGetAllAsync()
        {
            List<CustomerSignUp> cSignUp = await customerBLL.CustomerGetAllAsync();
            Console.WriteLine(" Customers List ");
            if (cSignUp.Count == 0)
            {
                Console.WriteLine("No records found.");
            }
            else
            {
                foreach (CustomerSignUp c in cSignUp)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"ID:           {c.Id}");
                    Console.WriteLine($"Name:         {c.Name}");
                    Console.WriteLine($"Phone:        {c.PhoneNumber}");
                    Console.WriteLine($"Email:        {c.EmailId}");
                    Console.WriteLine($"Address:      {c.Address}");
                    //Console.WriteLine($"Password:     {c.Password}");
                    Console.WriteLine("------------------------------");
                }
            }
            return cSignUp;
        }

        static async Task<bool> CustomerDeleteAsync()
        {
            int customerId = CustomValidations.GetValidatedInputInt("Enter Customer ID: ", CustomValidations.IsValidId);

           return await customerBLL.CustomerDeleteAsync(customerId);
            
        }

        static async Task<Vehicle> VehicleGetByIdAsync()
        {
            int vehicleId = CustomValidations.GetValidatedInputInt("Enter Vehicle ID: ", CustomValidations.IsValidId);

            Vehicle vehicle = await vehicleBLL.VehicleGetByIdAsync(vehicleId);
            if (vehicle != null)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine($"ID:                 {vehicle.Id}");
                Console.WriteLine($"Brand Model:        {vehicle.BrandModel}");
                Console.WriteLine($"Mileage:            {vehicle.Mileage}");
                Console.WriteLine($"Registration No.:   {vehicle.RegistrationNumber}");
                Console.WriteLine($"Seating Capacity:   {vehicle.SeatingCapacity}");
                Console.WriteLine($"Rental Rate:        ${vehicle.RentalRate}");
                Console.WriteLine($"Available:          {vehicle.IsAvailable}");
                Console.WriteLine("------------------------------");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
            return vehicle;
        }

        static async Task<List<Vehicle>> VehicleGetAllAsync() 
        {
            List<Vehicle> vehicles = await vehicleBLL.VehicleGetAllAsync();
            Console.WriteLine(" Vehicles List ");
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No records found.");
            }
            else
            {
                foreach (Vehicle v in vehicles)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"ID:                {v.Id}");
                    Console.WriteLine($"Brand Model:       {v.BrandModel}");
                    Console.WriteLine($"Mileage:           {v.Mileage}");
                    Console.WriteLine($"Registration No.:  {v.RegistrationNumber}");
                    Console.WriteLine($"Seating Capacity:  {v.SeatingCapacity}");
                    Console.WriteLine($"Rental Rate:       ${v.RentalRate}");
                    Console.WriteLine($"Available:         {v.IsAvailable}");
                    Console.WriteLine("------------------------------");
                }
            }
            return vehicles;
        }

        static async Task VehicleAddAsync()
        {
            string brandModel = CustomValidations.GetValidatedInputString("Enter BrandModel: ", CustomValidations.IsValidBrandModel);
            string mileage = CustomValidations.GetValidatedInputString("Enter Mileage : ", CustomValidations.IsValidMileage);
            string registrationNumber = CustomValidations.GetValidatedInputString("Enter Registration Number: ", CustomValidations.IsValidRegistrationNumber);
            string seatingCapacity = CustomValidations.GetValidatedInputString("Enter Seating Capacity : ", CustomValidations.IsValidSeatingCapacity);
            string rentalRate = CustomValidations.GetValidatedInputString("Enter Rental Rate : ", CustomValidations.IsValidRentalRate);
            string isAvailable = CustomValidations.GetValidatedInputString("Is Available : ", CustomValidations.IsValidIsAvailable);

            try
            {
                await vehicleBLL.VehicleAddAsync(brandModel, mileage, registrationNumber, seatingCapacity, rentalRate, isAvailable);
                Console.WriteLine("Vehicle Added Successfully");
            }catch(IncorrectUserDataException ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        static async Task<bool> VehicleDeleteAsync()
        {
            int vehicleId = CustomValidations.GetValidatedInputInt("Enter vehicle Id to Delete: ", CustomValidations.IsValidId);
            return await vehicleBLL.VehicleDeleteAsync(vehicleId);
            //Console.WriteLine("Vehicle deleted successfully.");
        }

        static async Task CxSignInAsync()
        {
            while (true)
            {
                string email = CustomValidations.GetValidatedInputString("Enter Email ID: ", CustomValidations.IsValidEmail);
                string password = CustomValidations.GetValidatedInputString("Enter Password: ", CustomValidations.IsValidPassword);

                try
                {
                    bool temp = await customerBLL.SignInAsync(email, password);
                    if (temp == true)
                    {
                        Console.WriteLine("Sign-in successful.");
                        await ShowCustomerMenu();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid email or password. Please try again");
                    }
                }
                catch (IncorrectUserDataException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static async Task AdSignInAsync()
        {
            while (true)
            {
                string email = CustomValidations.GetValidatedInputString("Enter Email ID: ", CustomValidations.IsValidEmail);
                string password = CustomValidations.GetValidatedInputString("Enter Password: ", CustomValidations.IsValidPassword);
                try
                {
                    bool temp = await vehicleBLL.SignInAsync(email, password);
                    if (temp == true)
                    {
                        Console.WriteLine("Sign-in successful.");
                        await ShowAdminMenu();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid email or password. Please try again");
                    }
                }
                catch (IncorrectUserDataException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}