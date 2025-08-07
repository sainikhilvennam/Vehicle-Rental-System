using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.MODEL;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System.Validations;
using Vehicle_Rental_System.Interfaces;


namespace Vehicle_Rental_System.BLL
{
    public class CustomerBLL
    {
        private ICustomerStorage storage;

        public void UseStorage(ICustomerStorage customerStorage)
        {
            storage = customerStorage;
        }
        public async Task<CustomerSignUp> CustomerAddAsync(string name, string phone, string email, string address, string password)
        {
            CustomerSignUp cSU = new CustomerSignUp
            {
                Name = name,
                PhoneNumber = phone,
                EmailId = email,
                Address = address,
                Password = password
            };
                return await storage.CustomerAddAsync(cSU);
        }

        public async Task CustomerUpdateAsync(int id,CustomerSignUp cSU)
        {
            await storage.CustomerUpdateAsync(id,cSU);
        }

        public async Task<bool> CustomerDeleteAsync(int id) {
            return await storage.CustomerDeleteAsync(id); 
        }

        public async Task<List<CustomerSignUp>> CustomerGetAllAsync()
        {
            return await storage.CustomerGetAllAsync();
        } 

        public async Task<CustomerSignUp> CustomerGetByIdAsync(int id)
        {
           
            return await storage.CustomerGetByIdAsync(id);
        }

        public async Task<bool> SignInAsync(string email,string password)
        {
            return await storage.SignInAsync(email, password);
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await storage.CheckEmailExistsAsync(email);
        }
    }
}
