namespace CraftConnectDeskPresent
{
    partial class UpdateWorkshop
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
            CBITemTypeC = new ComboBox();
            LItemType = new Label();
            CBDurationC = new ComboBox();
            TBImageC = new TextBox();
            LImage = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            BSubmitWChange = new Button();
            TBAmountOPlacesC = new TextBox();
            TBDaysC = new TextBox();
            TBDescriptionC = new TextBox();
            TBLocationC = new TextBox();
            TBPriceC = new TextBox();
            TBWorkshopNameC = new TextBox();
            SuspendLayout();
            // 
            // CBITemTypeC
            // 
            CBITemTypeC.FormattingEnabled = true;
            CBITemTypeC.Items.AddRange(new object[] { "Painting,", "Pottery,", "FiberArts,", "Prints,", "Drawing,", "Jewelry,", "Calligrapher,", "CeramicsAndGlass,", "Scrapbooking,", "ScentedProducts," });
            CBITemTypeC.Location = new Point(271, 258);
            CBITemTypeC.Name = "CBITemTypeC";
            CBITemTypeC.Size = new Size(242, 40);
            CBITemTypeC.TabIndex = 42;
            // 
            // LItemType
            // 
            LItemType.AutoSize = true;
            LItemType.Location = new Point(43, 266);
            LItemType.Name = "LItemType";
            LItemType.Size = new Size(120, 32);
            LItemType.TabIndex = 41;
            LItemType.Text = "Item Type";
            LItemType.TextAlign = ContentAlignment.TopCenter;
            // 
            // CBDurationC
            // 
            CBDurationC.FormattingEnabled = true;
            CBDurationC.Items.AddRange(new object[] { "0 - 30 min,", "30 - 60 min,", "60 - 90 min,", "90 - 120 min,", "Longer than 120 min," });
            CBDurationC.Location = new Point(271, 186);
            CBDurationC.Name = "CBDurationC";
            CBDurationC.Size = new Size(242, 40);
            CBDurationC.TabIndex = 40;
            // 
            // TBImageC
            // 
            TBImageC.Location = new Point(656, 333);
            TBImageC.Name = "TBImageC";
            TBImageC.Size = new Size(375, 39);
            TBImageC.TabIndex = 39;
            // 
            // LImage
            // 
            LImage.AutoSize = true;
            LImage.Location = new Point(539, 340);
            LImage.Name = "LImage";
            LImage.Size = new Size(80, 32);
            LImage.TabIndex = 38;
            LImage.Text = "Image";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 485);
            label8.Name = "label8";
            label8.Size = new Size(202, 32);
            label8.TabIndex = 37;
            label8.Text = "Amount of places";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(43, 409);
            label7.Name = "label7";
            label7.Size = new Size(165, 32);
            label7.TabIndex = 36;
            label7.Text = "Days available";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(504, 62);
            label6.Name = "label6";
            label6.Size = new Size(135, 32);
            label6.TabIndex = 35;
            label6.Text = "Description";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(46, 340);
            label5.Name = "label5";
            label5.Size = new Size(104, 32);
            label5.TabIndex = 34;
            label5.Text = "Location";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 194);
            label4.Name = "label4";
            label4.Size = new Size(107, 32);
            label4.TabIndex = 33;
            label4.Text = "Duration";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 119);
            label3.Name = "label3";
            label3.Size = new Size(65, 32);
            label3.TabIndex = 32;
            label3.Text = "Price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 51);
            label2.Name = "label2";
            label2.Size = new Size(188, 32);
            label2.TabIndex = 31;
            label2.Text = "Workshop name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 51);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 30;
            // 
            // BSubmitWChange
            // 
            BSubmitWChange.Location = new Point(656, 471);
            BSubmitWChange.Name = "BSubmitWChange";
            BSubmitWChange.Size = new Size(200, 46);
            BSubmitWChange.TabIndex = 29;
            BSubmitWChange.Text = "Submit changes";
            BSubmitWChange.UseVisualStyleBackColor = true;
            BSubmitWChange.Click += BSubmitWChange_Click;
            // 
            // TBAmountOPlacesC
            // 
            TBAmountOPlacesC.Location = new Point(271, 478);
            TBAmountOPlacesC.Name = "TBAmountOPlacesC";
            TBAmountOPlacesC.Size = new Size(200, 39);
            TBAmountOPlacesC.TabIndex = 28;
            // 
            // TBDaysC
            // 
            TBDaysC.Location = new Point(271, 402);
            TBDaysC.Name = "TBDaysC";
            TBDaysC.Size = new Size(200, 39);
            TBDaysC.TabIndex = 27;
            // 
            // TBDescriptionC
            // 
            TBDescriptionC.Location = new Point(656, 62);
            TBDescriptionC.Multiline = true;
            TBDescriptionC.Name = "TBDescriptionC";
            TBDescriptionC.Size = new Size(375, 206);
            TBDescriptionC.TabIndex = 26;
            // 
            // TBLocationC
            // 
            TBLocationC.Location = new Point(271, 333);
            TBLocationC.Name = "TBLocationC";
            TBLocationC.Size = new Size(200, 39);
            TBLocationC.TabIndex = 25;
            // 
            // TBPriceC
            // 
            TBPriceC.Location = new Point(271, 112);
            TBPriceC.Name = "TBPriceC";
            TBPriceC.Size = new Size(200, 39);
            TBPriceC.TabIndex = 24;
            // 
            // TBWorkshopNameC
            // 
            TBWorkshopNameC.Location = new Point(271, 44);
            TBWorkshopNameC.Name = "TBWorkshopNameC";
            TBWorkshopNameC.Size = new Size(200, 39);
            TBWorkshopNameC.TabIndex = 23;
            // 
            // UpdateWorkshop
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1060, 596);
            Controls.Add(CBITemTypeC);
            Controls.Add(LItemType);
            Controls.Add(CBDurationC);
            Controls.Add(TBImageC);
            Controls.Add(LImage);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BSubmitWChange);
            Controls.Add(TBAmountOPlacesC);
            Controls.Add(TBDaysC);
            Controls.Add(TBDescriptionC);
            Controls.Add(TBLocationC);
            Controls.Add(TBPriceC);
            Controls.Add(TBWorkshopNameC);
            Name = "UpdateWorkshop";
            Text = "UpdateWorkshop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CBITemTypeC;
        private Label LItemType;
        private ComboBox CBDurationC;
        private TextBox TBImageC;
        private Label LImage;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button BSubmitWChange;
        private TextBox TBAmountOPlacesC;
        private TextBox TBDaysC;
        private TextBox TBDescriptionC;
        private TextBox TBLocationC;
        private TextBox TBPriceC;
        private TextBox TBWorkshopNameC;
    }
}