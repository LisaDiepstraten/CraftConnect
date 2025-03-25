using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace BusinessLayer.Models
{
    public class User 
    {
        public int? UserId { get; private set; }
        public string Username { get; private set; }
        public string FirstName {  get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber {  get; private set; }
        public string Address {  get; private set; }
        public string EmailAddress {  get; private set; }
        //public int? AccountId { get; private set; }
        public string Password { get; private set; }
        public int Points { get; private set; }
        public int? ShoppingcartId { get; private set; }

        public User(int? userid, string Username, string FirstName, string LastName, string PhoneNumber, string address, string emailaddress,
             string Password, int points, int? shoppingcartId)
        {
            this.UserId = userid;
            this.Username = !string.IsNullOrWhiteSpace(Username) ? Username : throw new ArgumentException("Username cannot be null or whitespace.", nameof(Username));
            this.FirstName = !string.IsNullOrWhiteSpace(FirstName) ? FirstName : throw new ArgumentException("First name cannot be null or whitespace.", nameof(FirstName));
            this.LastName = !string.IsNullOrWhiteSpace(LastName) ? LastName : throw new ArgumentException("Last name cannot be null or whitespace.", nameof(LastName));
            this.PhoneNumber = !string.IsNullOrWhiteSpace(PhoneNumber) && PhoneNumber.Length <= 11 ? PhoneNumber : throw new ArgumentException("Phone number must have at most 1o digits and cannot be null or whitespace.", nameof(PhoneNumber));
            this.Address = address;
            this.EmailAddress = !string.IsNullOrWhiteSpace(emailaddress) ? emailaddress : throw new ArgumentException("emailaddress cannot be null or whitespace", nameof(emailaddress));
            this.Password = !string.IsNullOrWhiteSpace(Password) ? Password : throw new ArgumentException("password cannot be null or whitespace", nameof(Password));
            this.Points = points;
            this.ShoppingcartId = shoppingcartId;
       
        }

        public void SetPassword(string newPassword)
        {
            // Hash the new password securely
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(newPassword, 13);
        }

    }
}
