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
    public partial class AddCoupon : Form
    {
        CouponService Couponservice;
        public AddCoupon(CouponService couponservice)
        {
            this.Couponservice = couponservice;
            InitializeComponent();
        }

        private void BSubmitCoupon_Click(object sender, EventArgs e)
        {
            string couponname = TBCouponName.Text;
            string description = TBDescriptionC.Text;
            DateTime dateTime = MCExpirationD.SelectionRange.Start;
            decimal percentage = (NUDPercentage.Value) / 100;
            
            if (string.IsNullOrWhiteSpace(couponname) ||
                string.IsNullOrWhiteSpace(description) ||
                percentage <= 0 || MCExpirationD.SelectionRange.Start != null && MCExpirationD.SelectionStart != DateTime.MinValue)
            {
                MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            Coupon coupon = new Coupon(null, DiscountType.CustomDiscount, couponname, description, dateTime, percentage);
            Couponservice.AddCoupon(coupon);
            this.Hide();
        }
    }
}
