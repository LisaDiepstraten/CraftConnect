using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class DatabaseExceptionHandler : Exception
    {
        public DatabaseExceptionHandler()
        {
        }

        public DatabaseExceptionHandler(string message)
            : base(message)
        {
        }

        public DatabaseExceptionHandler(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class BusinessNotFoundException : DatabaseExceptionHandler
    {
        public BusinessNotFoundException()
        {
        }

        public BusinessNotFoundException(string message)
            : base(message)
        {
        }

        public BusinessNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class UserNotFoundException : DatabaseExceptionHandler
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class InvalidPasswordException : DatabaseExceptionHandler
    {
        public InvalidPasswordException()
        {
        }

        public InvalidPasswordException(string message)
            : base(message)
        {
        }

        public InvalidPasswordException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    public class WorkshopNotFoundException : DatabaseExceptionHandler
    {
        public WorkshopNotFoundException()
        {
        }

        public WorkshopNotFoundException(string message)
            : base(message)
        {
        }

        public WorkshopNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    public class ProductNotFoundException : DatabaseExceptionHandler
    {
        public ProductNotFoundException()
        {
        }

        public ProductNotFoundException(string message)
            : base(message)
        {
        }

        public ProductNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}

    


