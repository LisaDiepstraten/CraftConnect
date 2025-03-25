using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.MockDataRepo;

namespace UnitTest
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public void PasswordCheckerTest()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());

            string password1 = "Hello123!";
            string password2 = "Hello123!";
            bool results = accountService.PasswordChecker(password1, password2);
            Assert.IsTrue(results);
        }

        [TestMethod]
        public void PasswordCheckerTestFail()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());

            string password1 = "Hello123!";
            string password2 = "Hello";
            bool results = accountService.PasswordChecker(password1, password2);
            Assert.IsFalse(results);
        }


        [TestMethod]
        public void AddBusinessTest()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());
            Business bus = new Business(1, "Joel craft", "test.jpg", "Joel", "Hansen", "023966284", "Tilburg", "Joel@gmail.com", "JoelH", "Pass123!");
            bool result = accountService.AddBusiness(bus);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddUserTest()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());
            User user = new User(1, "JoelH", "Joel", "Hansen", "023966284", "Tilburg", "Joel@gmail.com", "pass123!", 8, 8);
            bool result = accountService.AddUser(user);
            Assert.IsTrue(result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddBusiness_ShouldThrowException_WhenInvalidEmailAddress()
        {
            // Arrange
            IAccountService accountService = new AccountService(new MockAccountRepo());
            Business bus = new Business(1, "Joel craft", "test.jpg", "Joel", "Hansen", "023966284", "Tilbuh", "Joelgmail.com", "JoelH", "Pass123!");

            // Act
            accountService.AddBusiness(bus);
        }



        [TestMethod]
        public void AuthenticateAdminLogInTest()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());
            Admin admin = new Admin(1, "Software", "SoftwareD", "TheBest123");
            string username = "SoftwareD";
            string password = "TheBest123";
            Admin resultAd = accountService.AuthenticateAdmin(username, password);
            Assert.AreEqual(admin.AdminId, resultAd.AdminId);
            Assert.AreEqual(admin.Username, resultAd.Username);
            Assert.AreEqual(admin.Username, resultAd.Username);
            Assert.AreEqual(admin.Password, resultAd.Password);

        }
        

        [TestMethod]
        public void SetHashedPassword()
        {
            IAccountService accountService = new AccountService(new MockAccountRepo());
            string password = "Soyasaus";
            string hashedPassword = accountService.SetHashedPw(password);

            // Verify if the provided password can be verified against the hashed result
            bool passwordMatchesHash = BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);

            Assert.IsTrue(passwordMatchesHash);
        }


       
    }
}
