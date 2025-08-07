using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.MODEL;

namespace Vehicle_Rental_System.Interfaces
{
    public interface ICustomerStorage
    {
        Task<List<CustomerSignUp>> CustomerGetAllAsync();
        Task<CustomerSignUp> CustomerGetByIdAsync(int id);
        Task<CustomerSignUp> CustomerAddAsync(CustomerSignUp cSignUp);
        Task CustomerUpdateAsync(int id, CustomerSignUp cSignUp);
        Task<bool> CustomerDeleteAsync(int id);
        Task<bool> SignInAsync(string EmailId, string Password);
        Task<bool> CheckEmailExistsAsync(string email);
    }
}
