using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.Interfaces;
using Vehicle_Rental_System.MODEL;



namespace Vehicle_Rental_System.DAL
{
   
    public class CustomerDAL : ICustomerStorage
    {
        private readonly string connectionString;
        public CustomerDAL()
        {
            // Hardcoded connection string to bypass config issues if you use console or web then change this connection string use app.config
            connectionString = "Server=INHYNVSAINIKH01;Database=Vehicle_Rental_System;Integrated Security=True;";
        }

        public async Task<CustomerSignUp> CustomerAddAsync(CustomerSignUp cSU) 
        {
            using(SqlConnection sQ=new SqlConnection(connectionString))
            {
                await sQ.OpenAsync();
                string query = "INSERT INTO CustomerSignUp (Name, PhoneNumber, EmailId, Address, Password) VALUES (@Name, @PhoneNumber, @EmailId, @Address, @Password)";
                using(SqlCommand command=new SqlCommand(query, sQ))
                {
                    command.Parameters.AddWithValue("@Name", cSU.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", cSU.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", cSU.EmailId);
                    command.Parameters.AddWithValue("@Address", cSU.Address);
                    command.Parameters.AddWithValue("@Password", cSU.Password);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return cSU;
        }   

        public async Task CustomerUpdateAsync(int id,CustomerSignUp cSU)
        {
            using(SqlConnection sQ=new SqlConnection(connectionString))
            {
                await sQ.OpenAsync();
                string query = "UPDATE CustomerSignUp SET Name = @Name, PhoneNumber = @PhoneNumber, EmailId = @EmailId, Address = @Address, Password = @Password WHERE Id = @id";
                using(SqlCommand command=new SqlCommand(query, sQ))
                {
                    command.Parameters.AddWithValue("@Name", cSU.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", cSU.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailId", cSU.EmailId);
                    command.Parameters.AddWithValue("@Address", cSU.Address);
                    command.Parameters.AddWithValue("@Password", cSU.Password);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
         public async Task<bool> CustomerDeleteAsync(int id)
        {
            using(SqlConnection sQ=new SqlConnection(connectionString))
            {
                await sQ.OpenAsync();
                string query = "DELETE FROM CustomerSignUp WHERE Id = @id";
                using(SqlCommand command=new SqlCommand(query, sQ))
                {
                    command.Parameters.AddWithValue("@Id", id);
                   int rowsAffected=await command.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public async Task<List<CustomerSignUp>> CustomerGetAllAsync()
        {
            List<CustomerSignUp> customerList = new List<CustomerSignUp>();
            using(SqlConnection sQ=new SqlConnection(connectionString))
            {
                await sQ.OpenAsync();
                string query = "SELECT * FROM CustomerSignUp";
                using(SqlCommand command=new SqlCommand(query, sQ))
                {
                    using(SqlDataReader reader=await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            CustomerSignUp customer = new CustomerSignUp
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                EmailId = reader["EmailId"].ToString(),
                                Address = reader["Address"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                            customerList.Add(customer);
                        }
                    }
                }
            }
            return customerList;
        }

        public async Task<CustomerSignUp> CustomerGetByIdAsync(int id)
        {
            CustomerSignUp customer = null;
            using(SqlConnection sQ=new SqlConnection(connectionString))
            {
                await sQ.OpenAsync();
                string query = "SELECT * FROM CustomerSignUp WHERE Id = @id";
                using(SqlCommand command=new SqlCommand(query, sQ))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using(SqlDataReader reader=await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            customer = new CustomerSignUp
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                EmailId = reader["EmailId"].ToString(),
                                Address = reader["Address"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                        }
                    }
                }
            }
            return customer;
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            using(SqlConnection sQ=new SqlConnection(connectionString))
            {
                await sQ.OpenAsync();
                string query = "SELECT * FROM CustomerSignUp WHERE EmailId = @email AND Password = @password";
                using(SqlCommand command=new SqlCommand(query, sQ))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    using(SqlDataReader reader=await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            using (SqlConnection sQ = new SqlConnection(connectionString))
            {
                await sQ.OpenAsync();
                string query = "SELECT COUNT(*) FROM CustomerSignUp WHERE EmailId = @Email";
                using (SqlCommand command = new SqlCommand(query, sQ))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = (int)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

    }
}
