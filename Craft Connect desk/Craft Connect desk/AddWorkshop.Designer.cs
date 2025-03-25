namespace CraftConnectDeskPresent
{
    partial class AddWorkshop
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
            TBWorkshopName = new TextBox();
            TBPrice = new TextBox();
            TBLocation = new TextBox();
            TBDescription = new TextBox();
            TBDays = new TextBox();
            TBAmountOPlaces = new TextBox();
            BSubmitW = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            LImage = new Label();
            TBImage = new TextBox();
            CBDuration = new ComboBox();
            LItemType = new Label();
            CBITemType = new ComboBox();
            SuspendLayout();
            // 
            // TBWorkshopName
            // 
            TBWorkshopName.Location = new Point(406, 186);
            TBWorkshopName.Name = "TBWorkshopName";
            TBWorkshopName.Size = new Size(200, 39);
            TBWorkshopName.TabIndex = 1;
            // 
            // TBPrice
            // 
            TBPrice.Location = new Point(406, 254);
            TBPrice.Name = "TBPrice";
            TBPrice.Size = new Size(200, 39);
            TBPrice.TabIndex = 2;
            // 
            // TBLocation
            // 
            TBLocation.Location = new Point(406, 475);
            TBLocation.Name = "TBLocation";
            TBLocation.Size = new Size(200, 39);
            TBLocation.TabIndex = 4;
            // 
            // TBDescription
            // 
            TBDescription.Location = new Point(791, 204);
            TBDescription.Multiline = true;
            TBDescription.Name = "TBDescription";
            TBDescription.Size = new Size(375, 206);
            TBDescription.TabIndex = 5;
            // 
            // TBDays
            // 
            TBDays.Location = new Point(406, 544);
            TBDays.Name = "TBDays";
            TBDays.Size = new Size(200, 39);
            TBDays.TabIndex = 6;
            // 
            // TBAmountOPlaces
            // 
            TBAmountOPlaces.Location = new Point(406, 620);
            TBAmountOPlaces.Name = "TBAmountOPlaces";
            TBAmountOPlaces.Size = new Size(200, 39);
            TBAmountOPlaces.TabIndex = 7;
            // 
            // BSubmitW
            // 
            BSubmitW.Location = new Point(776, 613);
            BSubmitW.Name = "BSubmitW";
            BSubmitW.Size = new Size(200, 46);
            BSubmitW.TabIndex = 8;
            BSubmitW.Text = "Submit";
            BSubmitW.UseVisualStyleBackColor = true;
            BSubmitW.Click += BSubmitW_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(269, 193);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(178, 193);
            label2.Name = "label2";
            label2.Size = new Size(188, 32);
            label2.TabIndex = 10;
            label2.Text = "Workshop name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(178, 261);
            label3.Name = "label3";
            label3.Size = new Size(65, 32);
            label3.TabIndex = 11;
            label3.Text = "Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(178, 336);
            label4.Name = "label4";
            label4.Size = new Size(107, 32);
            label4.TabIndex = 12;
            label4.Text = "Duration";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(181, 482);
            label5.Name = "label5";
            label5.Size = new Size(104, 32);
            label5.TabIndex = 13;
            label5.Text = "Location";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(639, 204);
            label6.Name = "label6";
            label6.Size = new Size(135, 32);
            label6.TabIndex = 14;
            label6.Text = "Description";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(178, 551);
            label7.Name = "label7";
            label7.Size = new Size(165, 32);
            label7.TabIndex = 15;
            label7.Text = "Days available";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(178, 627);
            label8.Name = "label8";
            label8.Size = new Size(202, 32);
            label8.TabIndex = 16;
            label8.Text = "Amount of places";
            // 
            // LImage
            // 
            LImage.AutoSize = true;
            LImage.Location = new Point(674, 482);
            LImage.Name = "LImage";
            LImage.Size = new Size(80, 32);
            LImage.TabIndex = 18;
            LImage.Text = "Image";
            // 
            // TBImage
            // 
            TBImage.Location = new Point(791, 475);
            TBImage.Name = "TBImage";
            TBImage.Size = new Size(200, 39);
            TBImage.TabIndex = 19;
            // 
            // CBDuration
            // 
            CBDuration.FormattingEnabled = true;
            CBDuration.Items.AddRange(new object[] { "0 - 30 min,", "30 - 60 min,", "60 - 90 min,", "90 - 120 min,", "Longer than 120 min," });
            CBDuration.Location = new Point(406, 328);
            CBDuration.Name = "CBDuration";
            CBDuration.Size = new Size(242, 40);
            CBDuration.TabIndex = 20;
            // 
            // LItemType
            // 
            LItemType.AutoSize = true;
            LItemType.Location = new Point(178, 408);
            LItemType.Name = "LItemType";
            LItemType.Size = new Size(120, 32);
            LItemType.TabIndex = 21;
            LItemType.Text = "Item Type";
            LItemType.TextAlign = ContentAlignment.TopCenter;
            // 
            // CBITemType
            // 
            CBITemType.FormattingEnabled = true;
            CBITemType.Items.AddRange(new object[] { "Painting,", "Pottery,", "FiberArts,", "Prints,", "Drawing,", "Jewelry,", "Calligrapher,", "CeramicsAndGlass,", "Scrapbooking,", "ScentedProducts," });
            CBITemType.Location = new Point(406, 400);
            CBITemType.Name = "CBITemType";
            CBITemType.Size = new Size(242, 40);
            CBITemType.TabIndex = 22;
            // 
            // AddWorkshop
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1244, 803);
            Controls.Add(CBITemType);
            Controls.Add(LItemType);
            Controls.Add(CBDuration);
            Controls.Add(TBImage);
            Controls.Add(LImage);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BSubmitW);
            Controls.Add(TBAmountOPlaces);
            Controls.Add(TBDays);
            Controls.Add(TBDescription);
            Controls.Add(TBLocation);
            Controls.Add(TBPrice);
            Controls.Add(TBWorkshopName);
            Name = "AddWorkshop";
            Text = "AddWorkshop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TBWorkshopName;
        private TextBox TBPrice;
        private TextBox TBLocation;
        private TextBox TBDescription;
        private TextBox TBDays;
        private TextBox TBAmountOPlaces;
        private Button BSubmitW;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label LImage;
        private TextBox TBImage;
        private ComboBox CBDuration;
        private Label LItemType;
        private ComboBox CBITemType;
    }
}