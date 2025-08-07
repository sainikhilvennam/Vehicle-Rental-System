using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System.Exceptions
{
    public class CustomerAlreadyExistsException : Exception
    {
        public CustomerAlreadyExistsException(string message) : base(message) { }

    }
}
