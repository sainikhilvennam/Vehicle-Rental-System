using Moq;
using System.Threading.Tasks;
using Xunit;
using Vehicle_Rental_System.MODEL;
using Vehicle_Rental_System.Interfaces;
using Vehicle_Rental_System.BLL;

namespace Vehicle_Rental_System.Tests
{
    public class CustomerTest
    {
        [Fact]
        public async Task CustomerAddAsync_IsCustomerSaved_Saved()
        {
            // Arrange
            var mockStorage = new Mock<ICustomerStorage>();
            var customerBLL = new CustomerBLL();
            customerBLL.UseStorage(mockStorage.Object);

            CustomerSignUp customerSignUp = new CustomerSignUp
            {
                Id = 1,
                Name = "sainikhil",
                PhoneNumber = "8297004146",
                EmailId = "sainikhilvennam@gmail.com",
                Address = "somajiguda",
                Password = "Sai34526"
            };

            // Setup mock to return success
            mockStorage.Setup(x => x.CustomerAddAsync(It.IsAny<CustomerSignUp>()))
                      .ReturnsAsync(customerSignUp);

            // Act
            await customerBLL.CustomerAddAsync(
                customerSignUp.Name,
                customerSignUp.PhoneNumber,
                customerSignUp.EmailId,
                customerSignUp.Address,
                customerSignUp.Password
            );

            // Assert
            mockStorage.Verify(x => x.CustomerAddAsync(It.Is<CustomerSignUp>(c => c.EmailId==customerSignUp.EmailId&&c.Name==customerSignUp.Name)), Times.Once);
        }
        [Fact]
        public async Task CustomerGetAllAsync_GetCustomers_returnsList()
        {
            var mockStorage = new Mock<ICustomerStorage>();
            var customerBLL = new CustomerBLL();
            customerBLL.UseStorage(mockStorage.Object);

            var list = new List<CustomerSignUp> {
                new CustomerSignUp
                {
                    Id = 1,
                    Name = "sainikhil",
                    PhoneNumber = "8297004146",
                    EmailId = "vennam@gmail.com",
                    Address = "somajiguda",
                    Password = "Seeyou"
                },
                new CustomerSignUp
                {
                    Id = 2,
                    Name = "sanju",
                    PhoneNumber = "9987644146",
                    EmailId = "sanju@outlook.com",
                    Address = "hyderabad",
                    Password = "ByeAlll"
                }
            };

            // Setup mock to return the list
            mockStorage.Setup(x => x.CustomerGetAllAsync())
                       .ReturnsAsync(list);

            // Act
            var result = await customerBLL.CustomerGetAllAsync();

            // Assert
            Assert.Equal(list.Count, result.Count);
            Assert.Equal(list[0].EmailId, result[0].EmailId);
            mockStorage.Verify(x => x.CustomerGetAllAsync(), Times.Once); // Ensures method was called
        }
        [Fact]
        public async Task CustomerGetAllAsync_NoCustomers_ReturnsEmptyList()
        {
            // Arrange
            var mockStorage = new Mock<ICustomerStorage>();
            var customerBLL = new CustomerBLL();
            customerBLL.UseStorage(mockStorage.Object);

            var emptyList = new List<CustomerSignUp>();
            mockStorage.Setup(x => x.CustomerGetAllAsync()).ReturnsAsync(emptyList);

            // Act
            var result = await customerBLL.CustomerGetAllAsync();

            // Assert
            Assert.Empty(result);
            mockStorage.Verify(x => x.CustomerGetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task SignInAsync_IsCustomerSignedIn_SignedIn()
        {
            // Arrange
            var mockStorage = new Mock<ICustomerStorage>();
            var customerBLL = new CustomerBLL();
            customerBLL.UseStorage(mockStorage.Object);

            string email = "sainikhilvennam@gmail.com";
            string password = "Sai4657";

            // Setup mock to return true for successful sign in
            mockStorage.Setup(x => x.SignInAsync(email, password))
                      .ReturnsAsync(true);

            // Act
            bool result = await customerBLL.SignInAsync(email, password);

            // Assert
            Assert.True(result);
            mockStorage.Verify(x => x.SignInAsync(email, password), Times.Once);
        }

        [Fact]
        public async Task CustomerDeleteAsync_IsCustomerDeleted_Deleted()
        {
            var mockStorage=new Mock<ICustomerStorage>();
            var customerBLL = new CustomerBLL();
            customerBLL.UseStorage(mockStorage.Object);
            int customerId = 1;

            //mockStorage.Setup(x => x.CustomerDeleteAsync(customerId))
            //          .ReturnsAsync(true);

            await customerBLL.CustomerDeleteAsync(customerId);

            mockStorage.Verify(x => x.CustomerDeleteAsync(customerId), Times.Once);

        }
    }
}
