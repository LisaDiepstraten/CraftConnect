namespace CraftConnectDeskPresent
{
    partial class AddCoupon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TBCouponName = new TextBox();
            LCouponName = new Label();
            label1 = new Label();
            TBDescriptionC = new TextBox();
            LDescriptionC = new Label();
            MCExpirationD = new MonthCalendar();
            LExpirationDate = new Label();
            NUDPercentage = new NumericUpDown();
            LPercentage = new Label();
            BSubmitCoupon = new Button();
            ((System.ComponentModel.ISupportInitialize)NUDPercentage).BeginInit();
            SuspendLayout();
            // 
            // TBCouponName
            // 
            TBCouponName.Location = new Point(280, 153);
            TBCouponName.Name = "TBCouponName";
            TBCouponName.Size = new Size(592, 39);
            TBCouponName.TabIndex = 0;
            // 
            // LCouponName
            // 
            LCouponName.AutoSize = true;
            LCouponName.Location = new Point(52, 160);
            LCouponName.Name = "LCouponName";
            LCouponName.Size = new Size(166, 32);
            LCouponName.TabIndex = 1;
            LCouponName.Text = "Coupon name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 53);
            label1.Name = "label1";
            label1.Size = new Size(219, 32);
            label1.TabIndex = 2;
            label1.Text = "Add a new Coupon";
            // 
            // TBDescriptionC
            // 
            TBDescriptionC.Location = new Point(280, 231);
            TBDescriptionC.Multiline = true;
            TBDescriptionC.Name = "TBDescriptionC";
            TBDescriptionC.Size = new Size(592, 94);
            TBDescriptionC.TabIndex = 3;
            // 
            // LDescriptionC
            // 
            LDescriptionC.AutoSize = true;
            LDescriptionC.Location = new Point(52, 234);
            LDescriptionC.Name = "LDescriptionC";
            LDescriptionC.Size = new Size(166, 64);
            LDescriptionC.TabIndex = 4;
            LDescriptionC.Text = "Description \r\nof the coupon";
            // 
            // MCExpirationD
            // 
            MCExpirationD.Location = new Point(280, 337);
            MCExpirationD.Name = "MCExpirationD";
            MCExpirationD.TabIndex = 5;
            // 
            // LExpirationDate
            // 
            LExpirationDate.AutoSize = true;
            LExpirationDate.Location = new Point(52, 337);
            LExpirationDate.Name = "LExpirationDate";
            LExpirationDate.Size = new Size(173, 32);
            LExpirationDate.TabIndex = 6;
            LExpirationDate.Text = "Expiration date";
            // 
            // NUDPercentage
            // 
            NUDPercentage.Location = new Point(28, 615);
            NUDPercentage.Name = "NUDPercentage";
            NUDPercentage.Size = new Size(240, 39);
            NUDPercentage.TabIndex = 7;
            // 
            // LPercentage
            // 
            LPercentage.AutoSize = true;
            LPercentage.Location = new Point(28, 559);
            LPercentage.Name = "LPercentage";
            LPercentage.Size = new Size(132, 32);
            LPercentage.TabIndex = 8;
            LPercentage.Text = "Percentage";
            // 
            // BSubmitCoupon
            // 
            BSubmitCoupon.Location = new Point(712, 608);
            BSubmitCoupon.Name = "BSubmitCoupon";
            BSubmitCoupon.Size = new Size(150, 46);
            BSubmitCoupon.TabIndex = 9;
            BSubmitCoupon.Text = "Submit";
            BSubmitCoupon.UseVisualStyleBackColor = true;
            BSubmitCoupon.Click += BSubmitCoupon_Click;
            // 
            // AddCoupon
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(951, 716);
            Controls.Add(BSubmitCoupon);
            Controls.Add(LPercentage);
            Controls.Add(NUDPercentage);
            Controls.Add(LExpirationDate);
            Controls.Add(MCExpirationD);
            Controls.Add(LDescriptionC);
            Controls.Add(TBDescriptionC);
            Controls.Add(label1);
            Controls.Add(LCouponName);
            Controls.Add(TBCouponName);
            Name = "AddCoupon";
            ((System.ComponentModel.ISupportInitialize)NUDPercentage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TBCouponName;
        private Label LCouponName;
        private Label label1;
        private TextBox TBDescriptionC;
        private Label LDescriptionC;
        private MonthCalendar MCExpirationD;
        private Label LExpirationDate;
        private NumericUpDown NUDPercentage;
        private Label LPercentage;
        private Button BSubmitCoupon;
    }
}