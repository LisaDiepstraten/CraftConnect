using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Exceptionhandler : Exception
    {


        public Exceptionhandler()
        {
        }

        public Exceptionhandler(string message)
            : base(message)
        {
        }

        public Exceptionhandler(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class CouponNotFoundException : Exceptionhandler
    {
        public CouponNotFoundException()
        {
        }

        public CouponNotFoundException(string message)
            : base(message)
        {
        }

        public CouponNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class CouponServiceException : Exceptionhandler
    {
        public CouponServiceException()
        {
        }

        public CouponServiceException(string message)
            : base(message)
        {
        }

        public CouponServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    public class LogicLayerException : Exception
    {
        public LogicLayerException()
        {
        }

        public LogicLayerException(string message)
            : base(message)
        {
        }

        public LogicLayerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
