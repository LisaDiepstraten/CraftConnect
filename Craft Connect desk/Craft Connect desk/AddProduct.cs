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
using BusinessLayer.Models;
using BusinessLayer.Services;


namespace CraftConnectDeskPresent
{
    public partial class AddProduct : Form
    {
        private Business authorizedbusiness;
        private IItemService itemservice;
        private CraftConnectForm mainform;

        public AddProduct(Business Authorizedbusiness, IItemService itemservice, CraftConnectForm mainform)
        {
            this.authorizedbusiness = Authorizedbusiness;
            this.itemservice = itemservice;
            this.mainform = mainform;

            InitializeComponent();

        }

        private void BSubmitP_Click(object sender, EventArgs e)
        {

            string productname = TBProductName.Text;
            string description = TBDescriptionP.Text;
            string image = TBImageP.Text;
            //decimal pricep = Convert.ToDecimal(TBPriceP.Text);

            decimal pricep;
            if (!decimal.TryParse(TBPriceP.Text, out pricep))
            {
                MessageBox.Show("Invalid price input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if price input is invalid
            }

            pricep = Convert.ToDecimal(TBPriceP.Text);
            TypeOfItem itemtype = (TypeOfItem)CBItemType.SelectedIndex;
            int amountinstock = Convert.ToInt32(NUDAmountProduct.Value);

            if (string.IsNullOrWhiteSpace(productname) ||
                 string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(image) ||
                pricep <= 0 ||
                amountinstock <= 0 || CBItemType.SelectedIndex == -1)
            {
                    MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit the method if any field is empty or invalid
                }

                if (authorizedbusiness != null && (int)authorizedbusiness.BusinessId != null)
                {
                    Item product = new Product(null, productname, description, image, pricep, (int)authorizedbusiness.BusinessId, itemtype, amountinstock);
                    itemservice.AddProduct((Product)product);
                    MessageBox.Show("Product added");
                    mainform.DatagridLoad();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Please try again");
                }

            }
        }
    }
