using Xunit;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System.Validations;

namespace Vehicle_Rental_System.Tests
{
    public class CustomValidationsTest
    {
        [Theory]
        [InlineData("sainikhil")]
        [InlineData("sai nikhil")]
        [InlineData("sai")]
        [InlineData("sai nikhil naidu vennam")]
        [InlineData("sa")]
        public void IsValidaName_ValidName_ReturnsInput(string name)
        {
            string results=CustomValidations.GetValidatedInputString_WindowForms(name, CustomValidations.IsValidName);
            Assert.Equal(name, results);
        }
        [Theory]
        [InlineData(" ")]
        [InlineData("sai-")]
        [InlineData(null)]
        [InlineData("@")]
        [InlineData("sai nikhil123")]
        [InlineData("sai$nikhil")]
        [InlineData("sai nikhil1")]
        [InlineData("53")]
        public void IsValidaName_InvalidName_ThrowsException(string name)
        {
            Assert.Throws<IncorrectUserDataException>(() =>
                CustomValidations.GetValidatedInputString_WindowForms(name, CustomValidations.IsValidName)
            );
        }

        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("test@outlook.com")]
        [InlineData("test@yahoo.com")]
        public void IsValidEmail_ValidEmail_ReturnsInput(string email)
        {
            string results=CustomValidations.GetValidatedInputString_WindowForms(email, CustomValidations.IsValidEmail);
            Assert.Equal(email, results);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("test")]
        [InlineData("test@")]
        [InlineData("test@gmail")]
        [InlineData("test@gmail.")]
        [InlineData("test@gmail.c")]
        public void IsValidEmail_InvalidEmail_ThrowsException(string email)
        {
            Assert.Throws<IncorrectUserDataException>(() => 
                CustomValidations.GetValidatedInputString_WindowForms(email, CustomValidations.IsValidEmail)
            );
        }

        [Theory]
        [InlineData("8297004146")]
        [InlineData("9876543210")]
        public void IsValidPhoneNumber_ValidPhone_ReturnsInput(string phone)
        {
            string results = CustomValidations.GetValidatedInputString_WindowForms(phone, CustomValidations.IsValidPhoneNumber);
            Assert.Equal(phone, results);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData("12345678901")]
        [InlineData("abcdefghij")]
        [InlineData("123-456-789")]
        public void IsValidPhoneNumber_InvalidPhone_ThrowsException(string phone)
        {
            Assert.Throws<IncorrectUserDataException>(() =>
                CustomValidations.GetValidatedInputString_WindowForms(phone, CustomValidations.IsValidPhoneNumber)
            );
        }

        [Theory]
        [InlineData("Password123")]
        [InlineData("Test1234")]
        [InlineData("Abc1234")]
        public void IsValidPassword_ValidPassword_ReturnsInput(string password)
        {
            string results = CustomValidations.GetValidatedInputString_WindowForms(password, CustomValidations.IsValidPassword);
            Assert.Equal(password, results);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData("ThisPasswordIsTooLong")]
        [InlineData("Pass@123")]
        public void IsValidPassword_InvalidPassword_ThrowsException(string password)
        {
            Assert.Throws<IncorrectUserDataException>(() =>
                CustomValidations.GetValidatedInputString_WindowForms(password, CustomValidations.IsValidPassword)
            );
        }
    }
}