using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Interfaces;
using DataAccessLibrary;
using BusinessLayer.Models;
using BusinessLayer.Services;

namespace CraftConnectDeskPresent
{
    public partial class LogIn : Form
    {

        private IAccountService accountservice;
        private IItemService itemservice;
        
        public LogIn(IAccountService accountservice, IItemService itemservice)
        {
            InitializeComponent();
            this.accountservice = accountservice;
            this.itemservice = itemservice;
            AddAccount();
        }

        private void AddAccount()
        {
          
        }
        private void BEnterLog_Click(object sender, EventArgs e)
        {
            string username = TBUserName.Text;
            string password = TBPassword.Text;


         
            if (accountservice != null)
            {
                try
                {
                    Admin AuthorizedAdmin = accountservice.AuthenticateAdmin(username, password);
                    if (AuthorizedAdmin != null)
                    {
                        this.Hide();
                        CraftConnectForm craft = new CraftConnectForm(null, AuthorizedAdmin, itemservice);
                        craft.FormClosed += (s, args) => this.Close();   // Hides the login form and closes it when craft is closed
                        craft.Show();
                    }
                    else
                    {
                        // When Admin is not authorized, check for Business credentials
                        string storedHash = accountservice.GetBusinessByUserName(username).Password;
                        Business Authorizedbusiness = accountservice.AuthenticateBusiness(username, storedHash);

                        if (Authorizedbusiness != null)
                        {
                            if (accountservice.VerifyPassword(password, storedHash))
                            {
                                this.Hide();
                                CraftConnectForm craft = new CraftConnectForm(Authorizedbusiness, null, itemservice);
                                craft.FormClosed += (s, args) => this.Close();   // Hides the login form and closes it when craft is closed
                                craft.Show();
                            }
                            else
                            {
                                MessageBox.Show("Wrong credentials");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong credentials");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception if necessary
                    MessageBox.Show("Wrong credentials");
                }
            }
            else
            {
                MessageBox.Show("Account service is null");
            }
        }

        private void BSignUp_Click(object sender, EventArgs e)
        {
            SignUp signupform = new SignUp(accountservice);

            this.Hide();

            signupform.FormClosed += (s, args) => this.Close();     // Hides the login form and closes it when signupform is closed

            signupform.Show();
        }
    }
}
