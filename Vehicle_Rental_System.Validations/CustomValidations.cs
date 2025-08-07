using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vehicle_Rental_System.Exceptions;

namespace Vehicle_Rental_System.Validations
{
    public static class CustomValidations
    {
        public static void IsValidName(string name)
        {
            if(string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-Z\s]{2,50}$"))
            {
                throw new IncorrectUserDataException("Invalid name. Name should contain only alphabets and spaces.");
            }
        }

        public static void IsValidPhoneNumber(string phoneNumber)
        {
            if(string.IsNullOrWhiteSpace(phoneNumber) || !Regex.IsMatch(phoneNumber, @"^\d{10}$"))
            {
                throw new IncorrectUserDataException("Invalid phone number. Phone number should be 10 digits.");
            }
        }

        public static void IsValidEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,3}$"))
            {
                throw new IncorrectUserDataException("Invalid email address.");
            }
        }

        public static void IsValidAddress(string address)
        {
            if(string.IsNullOrEmpty(address) || !Regex.IsMatch(address,@"^[a-zA-Z0-9\s,.-]{2,100}$"))
            {
                throw new IncorrectUserDataException("Invalid address. ");
            }
        }

        public static void IsValidPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password) || !Regex.IsMatch(password, @"^[a-zA-Z0-9]{7,14}$"))
            {
                throw new IncorrectUserDataException("Invalid password. Password should be 7-14 characters long and contain only letters and numbers.");
            }
        }

        public static void IsValidBrandModel(string brandmodel)
        {
            if(string.IsNullOrWhiteSpace(brandmodel) || !Regex.IsMatch(brandmodel, @"^[a-zA-Z0-9\s]{2,50}$"))
            {
                throw new IncorrectUserDataException("Invalid brand model. Brand model should contain only alphabets, numbers and spaces.");
            }
        }

        public static void IsValidMileage(string mileage)
        {
            if(string.IsNullOrWhiteSpace(mileage) || !Regex.IsMatch(mileage, @"^\d{1,3}$"))
            {
                throw new IncorrectUserDataException("Invalid mileage. Mileage should be a positive integer.");
            }
        }
        public static void IsValidRegistrationNumber(string registrationnumber)
        {
            if(string.IsNullOrWhiteSpace(registrationnumber) || !Regex.IsMatch(registrationnumber, @"^(TS|AP)[0-9]{2}[a-zA-Z]{2}[0-9]{4}$"))
            {
                throw new IncorrectUserDataException("Invalid registration number. Registration number should be in the format TS01AB1234.");
            }
        }

        public static void IsValidSeatingCapacity(string seatingCapacity)
        {
            if(string.IsNullOrWhiteSpace(seatingCapacity) || !Regex.IsMatch(seatingCapacity, @"^\d{1,2}$"))
            {
                throw new IncorrectUserDataException("Invalid seating capacity. Seating capacity should be a positive integer.");
            }
        }

        public static void IsValidRentalRate(string rentalRate)
        {
            if (string.IsNullOrWhiteSpace(rentalRate) || !Regex.IsMatch(rentalRate, @"^\d{1,4}$"))
            {
                throw new IncorrectUserDataException("Invalid rental rate. Rental rate should be a positive integer.");
            }
        }

        public static void IsValidIsAvailable(string isAvailable)
        {
            if(string.IsNullOrWhiteSpace(isAvailable) || !Regex.IsMatch(isAvailable, @"^(Available|Not Available)$"))
            {
                throw new IncorrectUserDataException("Invalid data. Please enter 'Available' or 'Not Available'.");
            }
        }

        public static void IsValidId(int id)
        {
            if(id <= 0)
            {
                throw new IncorrectUserDataException("Invalid ID. ID should be a positive integer. ");
            }
        }
        public static void IsValidIdChoice(int id)
        {
            if (id != 1 && id != 2)
            {
                throw new IncorrectUserDataException("Invalid choice. Please enter 1 for SQL or 2 for JSON.");
            }
        }

        // for console app

        public static string GetValidatedInputString(string prompt, Action<string> validationFunc)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                try
                {
                    validationFunc(input);
                    return input;
                }
                catch (IncorrectUserDataException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static int GetValidatedInputInt(string prompt, Action<int> validationFunc)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    try
                    {
                        validationFunc(value); // calls IsValidId(int id)
                        return value;
                    }
                    catch (IncorrectUserDataException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number. Please enter a valid integer.");
                }
            }
        }

        // for window forms
        public static string GetValidatedInputString_WindowForms(string input, Action<string> validationFunc)
        {
            try
            {
                validationFunc(input);
                return input;
            }
            catch (IncorrectUserDataException ex)
            {
                throw new IncorrectUserDataException(ex.Message); // or return null, based on need
            }
        }

        // for window forms
        public static int GetValidatedInputInt_WindowForms(int input, Action<int> validationFunc)
        {
            try
            {
                validationFunc(input);
                return input;
            }
            catch (IncorrectUserDataException ex)
            {
                throw new IncorrectUserDataException(ex.Message); // or return null, based on need
            }
        }



    }
}
