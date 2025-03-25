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
    public partial class UpdateWorkshop : Form
    {
        private IItemService itemservice;
        private Workshop workshop;
        private CraftConnectForm mainform;
        public UpdateWorkshop(IItemService itemService, Workshop workshop, CraftConnectForm mainform)
        {
            this.itemservice = itemService;
            this.workshop = workshop;
            this.mainform = mainform;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            TBWorkshopNameC.Text = workshop.WorkshopName;
            TBPriceC.Text = workshop.Price.ToString();
            CBDurationC.Text = workshop.Duration.ToString();
            CBITemTypeC.Text = workshop.TypeOfItem.ToString();
            TBLocationC.Text = workshop.Location;
            TBDaysC.Text = workshop.DaysAvailable;
            TBAmountOPlacesC.Text = workshop.AmountOfPlaces.ToString();
            TBDescriptionC.Text = workshop.Description;
            TBImageC.Text = workshop.Image;
        }

        private void BSubmitWChange_Click(object sender, EventArgs e)
        {

            string name = TBWorkshopNameC.Text;
            decimal price;
            if (!decimal.TryParse(TBPriceC.Text, out price))
            {
                MessageBox.Show("Invalid price input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if price input is invalid
            }

            string location = TBLocationC.Text;
            string days = TBDaysC.Text;

            int amount;
            if (!int.TryParse(TBAmountOPlacesC.Text, out amount))
            {
                MessageBox.Show("Invalid amount of places input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if amount input is invalid
            }

            string desc = TBDescriptionC.Text;
            string image = TBImageC.Text;

            int workshopID = (int)workshop.WorkshopId;
            Workshop getworkshop = itemservice.GetWorkshopById(workshopID);
            DurationType duration = getworkshop.Duration; // Assuming DefaultValue is some default value for duration
            TypeOfItem item = getworkshop.TypeOfItem;

            if (CBDurationC.SelectedIndex != -1)
            {
                duration = (DurationType)CBDurationC.SelectedIndex;
                // Use duration as needed
            }

            if (CBITemTypeC.SelectedIndex != -1)
            {
                item = (TypeOfItem)CBITemTypeC.SelectedIndex;
            }

            int businessid = workshop.BusinessId;

            // Check if any of the fields are empty
            if (string.IsNullOrWhiteSpace(name) ||
                price <= 0 ||
                string.IsNullOrWhiteSpace(location) ||
                string.IsNullOrWhiteSpace(days) ||
                amount <= 0 ||
                string.IsNullOrWhiteSpace(desc) ||
                string.IsNullOrWhiteSpace(image))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if any field is empty or invalid
            }

            // All fields are filled correctly, proceed to update the workshop
            Item workshopW = new Workshop(workshopID, getworkshop.Id, name, desc, image, location, price, amount, days, businessid, item, duration);
            itemservice.UpdateWorkshop((Workshop)workshopW);
            MessageBox.Show("Workshop updated");
            mainform.DatagridLoad();
            this.Close();
        }
    }
}
