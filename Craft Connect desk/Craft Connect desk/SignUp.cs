using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using DocumentFormat.OpenXml.Drawing.Diagrams;
using BusinessLayer.Services;
using BusinessLayer.Models;
using BusinessLayer.Interfaces;
using DataAccessLibrary;

namespace CraftConnectDeskPresent
{
    public partial class SignUp : Form
    {

        private IAccountService accountservice;

        public SignUp(IAccountService accountservice)
        {
            InitializeComponent();
            this.accountservice = accountservice;
         
        }

        private void BSubmitSU_Click(object sender, EventArgs e)
        {
            string password = TBPassword.Text;
            string password2 = TBPassword2.Text;
            if (accountservice.PasswordChecker(password, password2) == true)
            {

                string BusinessName = TBBusinessN.Text;
                string picture = TBURL.Text;
                string FirstName = TBFirstName.Text;
                string LastName = TBLastName.Text;
                string PhoneNumber = TBPhoneN.Text;
                string Address = TBAdress.Text;
                string Email = TBEmailA.Text;
                string Username = TBUserName.Text;
                string Password = TBPassword.Text;

                if (
                string.IsNullOrWhiteSpace(BusinessName) || string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(PhoneNumber) ||
                string.IsNullOrWhiteSpace(Address) || string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password)) { MessageBox.Show("Please fill in all the fields."); }

                else
                {
                    Business business = new Business(null, BusinessName, picture, FirstName, LastName, PhoneNumber, Address, Email, Username, Password);

                    try
                    {

                        accountservice.AddBusiness(business);
                        MessageBox.Show("Business created successfully.");

                        Business AuthorizedBusiness = accountservice.AuthenticateBusiness(Username, Password);
                        this.Hide();

                        IAccountRepository repo = new AccountRepository();
                        IAccountService accountService = new AccountService(repo);
                        IItemRepository repoitem = new ItemRepository();
                        IItemService itemservice = new ItemService(repoitem);
                        LogIn login = new LogIn(accountService, itemservice);
                        
                        login.FormClosed += (s, args) => this.Close();    // Hides the signup form and closes it when mainform is closed

                        login.Show();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "Database ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                


            }
            else
            {
                MessageBox.Show("Please check credentials");
            }

        }

        private void BSubmitImage_Click(object sender, EventArgs e)
        {
        }

        private void RBBusiness_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RBAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
