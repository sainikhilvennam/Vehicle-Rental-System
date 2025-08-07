using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.Interfaces;
using Vehicle_Rental_System.MODEL;
using Newtonsoft.Json;

namespace Vehicle_Rental_System.DAO
{
    public class JSonCustomerStorageDAL : ICustomerStorage
    {
        private readonly string filePath = "C:\\Users\\vsainikhil\\source\\repos\\Vehicle_Rental_System\\Vehicle_Rental_System\\Data\\customers.json";

        public async Task<CustomerSignUp> CustomerAddAsync(CustomerSignUp customer)
        {
            List<CustomerSignUp> customers = new List<CustomerSignUp>();
            if (File.Exists(filePath)){
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = await reader.ReadToEndAsync();
                    customers = JsonConvert.DeserializeObject<List<CustomerSignUp>>(json) ?? new List<CustomerSignUp>();
                }
            }
            
            customer.Id = customers.Count > 0 ? customers.Max(c => c.Id) + 1 : 1;
            customers.Add(customer);
            
            string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteAsync(updatedJson);
            }
            return customer;
        }

        public async Task<bool> CustomerDeleteAsync(int id)
        {
            if (!File.Exists(filePath)) return false;
            List < CustomerSignUp > customers = new List<CustomerSignUp>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = await reader.ReadToEndAsync();
                customers = JsonConvert.DeserializeObject<List<CustomerSignUp>>(json) ?? new List<CustomerSignUp>();
            }
            
            int removedCount =customers.RemoveAll(c => c.Id == id);
            if (removedCount == 0) {
                //Console.WriteLine($"No customer found with ID: {id}");
                return false;
            }
         
            string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
            using(StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteAsync(updatedJson);
            }
            return true;
            //Console.WriteLine($"Customer with ID {id} deleted successfully.");
        }

        public async Task<List<CustomerSignUp>> CustomerGetAllAsync()
        {
            if (!File.Exists(filePath)) return new List<CustomerSignUp>();
            string json;
            using (StreamReader reader = new StreamReader(filePath))
            {
                json = await reader.ReadToEndAsync();
            }
            return JsonConvert.DeserializeObject<List<CustomerSignUp>>(json) ?? new List<CustomerSignUp>();
        }

        public async Task<CustomerSignUp> CustomerGetByIdAsync(int id)
        {
            if (!File.Exists(filePath)) return null;
            List<CustomerSignUp> customers;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json=await reader.ReadToEndAsync();
                customers = JsonConvert.DeserializeObject<List<CustomerSignUp>>(json) ?? new List<CustomerSignUp>();
            }
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public async Task CustomerUpdateAsync(int id, CustomerSignUp cSignUp)
        {
            if (!File.Exists(filePath)) return;
            List<CustomerSignUp> customers;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = await reader.ReadToEndAsync();
                customers = JsonConvert.DeserializeObject<List<CustomerSignUp>>(json) ?? new List<CustomerSignUp>();
            } 
            var existingCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = cSignUp.Name;
                existingCustomer.PhoneNumber = cSignUp.PhoneNumber;
                existingCustomer.EmailId = cSignUp.EmailId;
                existingCustomer.Address = cSignUp.Address;
                existingCustomer.Password = cSignUp.Password;
                
                string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    await writer.WriteAsync(updatedJson);
                }
            }
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            if (!File.Exists(filePath)) return false;
            List<CustomerSignUp> customers;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json= await reader.ReadToEndAsync();
                customers = JsonConvert.DeserializeObject<List<CustomerSignUp>>(json) ?? new List<CustomerSignUp>();
            }
            return customers.Any(c => c.EmailId == email && c.Password == password);
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            if (!File.Exists(filePath)) return false;
            List<CustomerSignUp> customers;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = await reader.ReadToEndAsync();
                customers = JsonConvert.DeserializeObject<List<CustomerSignUp>>(json) ?? new List<CustomerSignUp>();
            }
            return customers.Any(c => c.EmailId == email);
        }
    }
}
