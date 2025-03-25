using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLibrary.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestClass]
    public class AccountServiceTests
    {
        IAccountService accountService = new AccountService(new MockAccountRepository());
        Business business = new Business(40, "Ilse's craft", "testc.jpg", "ilse", "Hoogstraten", "03473453453", "Prinsenhage", "Ilse@gmail.com", "Ilse123", "123");

        [TestMethod]
        public void PasswordChecker()
        {
            IAccountService accountService = new AccountService(new MockAccountRepository());

            string password1 = "Hello123!";
            string password2 = "Hello123!";
            bool results = accountService.PasswordChecker(password1, password2);
            Assert.IsTrue(results);
        }


       
        public void AddBusinessTest()
        {
            accountService.AddBusiness(business);
        }

  
        //public void RemoveBusinessTest()
        //{
        //    accountService.DeleteBusiness(business.BusinessName);
        //}


        //public void GetBusinessTest()
        //{
        //    accountService.GetBusiness(business.BusinessName);
        //}

    }
}
