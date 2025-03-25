using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class Business
    {
        public int? BusinessId { get; private set; }
        public string BusinessName { get; private set; }
        public string BusinessImage { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string EmailAddress { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
       
        public Business(int? Businessid, string businessname, string businessimage, string FirstName, string LastName, string PhoneNumber, string Address,
            string EmailAddress, string Username, string Password)
        {
            if (string.IsNullOrWhiteSpace(businessname))
                throw new ArgumentException("Business name cannot be null or whitespace.", nameof(businessname));
            if (string.IsNullOrWhiteSpace(businessimage))
                throw new ArgumentException("Business image cannot be null or whitespace.", nameof(businessimage));
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("First name cannot be null or whitespace.", nameof(FirstName));
            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Last name cannot be null or whitespace.", nameof(LastName));
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                throw new ArgumentException("Phone number cannot be null or whitespace.", nameof(PhoneNumber));
            if (string.IsNullOrWhiteSpace(Address))
                throw new ArgumentException("Address cannot be null or whitespace.", nameof(Address));
            if (string.IsNullOrWhiteSpace(EmailAddress))
                throw new ArgumentException("Email address cannot be null or whitespace.", nameof(EmailAddress));
            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("Username cannot be null or whitespace.", nameof(Username));
            if (string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("Password cannot be null or whitespace.", nameof(Password));

            this.BusinessId = Businessid;
            this.BusinessName = businessname;
            this.BusinessImage = businessimage;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.EmailAddress = EmailAddress;
            this.Username = Username;
            this.Password = Password;
        }

        public void SetPassword(string newPassword)
        {
            // Hash the new password securely
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(newPassword, 13);
        }
    }
}
