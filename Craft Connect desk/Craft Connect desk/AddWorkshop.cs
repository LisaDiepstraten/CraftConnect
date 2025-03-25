using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraftConnectDeskPresent
{
    public partial class AddWorkshop : Form
    {
        private IItemService itemservice;
        private Business Authorizedbusiness;
        private CraftConnectForm mainform;
        public AddWorkshop(Business Authorizedbusiness, IItemService itemservice, CraftConnectForm mainform)
        {
            this.itemservice = itemservice;
            this.Authorizedbusiness = Authorizedbusiness;
            this.mainform = mainform;
            InitializeComponent();
        }

        private void BSubmitW_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBWorkshopName.Text != null && TBDescription.Text != null && TBImage.Text != null && TBLocation.Text != null && CBDuration.SelectedIndex > -1 && TBPrice.Text != null
               && TBAmountOPlaces.Text != null && TBDays.Text != null && CBITemType.SelectedIndex > -1)
                {
                    string workshopname = TBWorkshopName.Text;
                    string description = TBDescription.Text;
                    string image = TBImage.Text;
                    string location = TBLocation.Text;

                    DurationType duration = (DurationType)CBDuration.SelectedIndex;
                    //decimal price = Convert.ToDecimal(TBPrice.Text);

                    string text = TBPrice.Text;

                    decimal price;
                    if (decimal.TryParse(text, out price))
                    {
                        price = Convert.ToDecimal(TBPrice.Text);

                    }
                    else
                    {
                        MessageBox.Show("Invalid decimal input");
                    }

                    string text2 = TBAmountOPlaces.Text;

                    int amountOfPlaces;
                    if (int.TryParse(text2, out amountOfPlaces))
                    {
                        amountOfPlaces = Convert.ToInt32(TBAmountOPlaces.Text);
                    }
                    else
                    {

                        MessageBox.Show("Invalid integer input");
                    }

                   string daysavailable = TBDays.Text;
                    int AuthorizedbusinessId = (int)Authorizedbusiness.BusinessId;
                    //MessageBox.Show(AuthorizedbusinessId.ToString());
                    TypeOfItem ItemType = (TypeOfItem)CBITemType.SelectedIndex;

                    if (Authorizedbusiness != null && AuthorizedbusinessId != null)
                    {
                        Item workshop = new Workshop(null, workshopname, description, image, location, price, amountOfPlaces, daysavailable, AuthorizedbusinessId, ItemType, duration);
                        itemservice.AddWorkshop((Workshop)workshop);
                        MessageBox.Show("Workshop added");
                        mainform.DatagridLoad();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please try again");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields");
                }
                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Argument error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (LogicLayerException ex)
            {
                MessageBox.Show($"Logic layer error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CouponNotFoundException ex)
            {
                MessageBox.Show($"Coupon not found error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CouponServiceException ex)
            {
                MessageBox.Show($"Coupon service error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatabaseExceptionHandler ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
