using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraftConnectDeskPresent
{
    public partial class UpdateProduct : Form
    {
        private IItemService itemservice;
        private Product product;
        private CraftConnectForm mainform;
        public UpdateProduct(IItemService itemservice,Product product, CraftConnectForm mainform)
        {
            this.itemservice = itemservice;
            this.product = product;
            this.mainform = mainform;
            InitializeComponent();
            LoadData();
            
        }

        public void LoadData()
        {
            TBProductNameU.Text = product.ProductName;
            TBPricePU.Text = product.Price.ToString();
            TBDescriptionPU.Text = product.Description.ToString();
            NUDAmountProductU.Value = Convert.ToInt32(product.AmountInStock);
            CBItemTypeU.Text = product.TypeOfItem.ToString();
            TBImagePU.Text = product.Image; 

            
        }

        private void BSubmitPU_Click(object sender, EventArgs e)
        {
            int productId = (int)product.ProductID;
            Product getproduct = itemservice.GetProductById(productId); 
            int businessId = product.BusinessId;
            string name = TBProductNameU.Text;
            decimal price = Convert.ToDecimal(TBPricePU.Text);
            string description = TBDescriptionPU.Text;
            int amount = Convert.ToInt32(NUDAmountProductU.Value);
            TypeOfItem typeOfItem = getproduct.TypeOfItem;
            if (CBItemTypeU.SelectedIndex != -1)
            {
                 typeOfItem = (TypeOfItem)CBItemTypeU.SelectedIndex;
            }
          
            string image = TBImagePU.Text;
            if (productId != null && getproduct.Id != null && name != null && description != null && image != null && price != null && businessId != null && typeOfItem != null && amount != null)
            {

                Item productp = new Product(productId, getproduct.Id, name, description, image, price, businessId, typeOfItem, amount);
                itemservice.UpdateProduct((Product)productp);
                mainform.DatagridLoad();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
    }
}
