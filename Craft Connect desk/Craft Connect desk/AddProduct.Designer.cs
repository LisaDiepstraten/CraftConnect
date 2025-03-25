namespace CraftConnectDeskPresent
{
    partial class AddProduct
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
            LAmountIS = new Label();
            LDesP = new Label();
            LPriceP = new Label();
            LProductName = new Label();
            label1 = new Label();
            BSubmitP = new Button();
            TBDescriptionP = new TextBox();
            TBPriceP = new TextBox();
            TBProductName = new TextBox();
            NUDAmountProduct = new NumericUpDown();
            label2 = new Label();
            CBItemType = new ComboBox();
            LImageP = new Label();
            TBImageP = new TextBox();
            ((System.ComponentModel.ISupportInitialize)NUDAmountProduct).BeginInit();
            SuspendLayout();
            // 
            // LAmountIS
            // 
            LAmountIS.AutoSize = true;
            LAmountIS.Location = new Point(209, 431);
            LAmountIS.Name = "LAmountIS";
            LAmountIS.Size = new Size(189, 32);
            LAmountIS.TabIndex = 34;
            LAmountIS.Text = "Amount in stock";
            // 
            // LDesP
            // 
            LDesP.AutoSize = true;
            LDesP.Location = new Point(209, 204);
            LDesP.Name = "LDesP";
            LDesP.Size = new Size(135, 32);
            LDesP.TabIndex = 32;
            LDesP.Text = "Description";
            // 
            // LPriceP
            // 
            LPriceP.AutoSize = true;
            LPriceP.Location = new Point(209, 133);
            LPriceP.Name = "LPriceP";
            LPriceP.Size = new Size(65, 32);
            LPriceP.TabIndex = 29;
            LPriceP.Text = "Price";
            // 
            // LProductName
            // 
            LProductName.AutoSize = true;
            LProductName.Location = new Point(209, 65);
            LProductName.Name = "LProductName";
            LProductName.Size = new Size(163, 32);
            LProductName.TabIndex = 28;
            LProductName.Text = "Product name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(300, 184);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 27;
            // 
            // BSubmitP
            // 
            BSubmitP.Location = new Point(437, 692);
            BSubmitP.Name = "BSubmitP";
            BSubmitP.Size = new Size(200, 46);
            BSubmitP.TabIndex = 26;
            BSubmitP.Text = "Submit";
            BSubmitP.UseVisualStyleBackColor = true;
            BSubmitP.Click += BSubmitP_Click;
            // 
            // TBDescriptionP
            // 
            TBDescriptionP.Location = new Point(437, 204);
            TBDescriptionP.Multiline = true;
            TBDescriptionP.Name = "TBDescriptionP";
            TBDescriptionP.Size = new Size(383, 197);
            TBDescriptionP.TabIndex = 23;
            // 
            // TBPriceP
            // 
            TBPriceP.Location = new Point(437, 126);
            TBPriceP.Name = "TBPriceP";
            TBPriceP.Size = new Size(200, 39);
            TBPriceP.TabIndex = 20;
            // 
            // TBProductName
            // 
            TBProductName.Location = new Point(437, 58);
            TBProductName.Name = "TBProductName";
            TBProductName.Size = new Size(200, 39);
            TBProductName.TabIndex = 19;
            // 
            // NUDAmountProduct
            // 
            NUDAmountProduct.Location = new Point(437, 424);
            NUDAmountProduct.Name = "NUDAmountProduct";
            NUDAmountProduct.Size = new Size(240, 39);
            NUDAmountProduct.TabIndex = 36;
            NUDAmountProduct.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 495);
            label2.Name = "label2";
            label2.Size = new Size(116, 32);
            label2.TabIndex = 37;
            label2.Text = "Item type";
            // 
            // CBItemType
            // 
            CBItemType.FormattingEnabled = true;
            CBItemType.Items.AddRange(new object[] { "Painting,", "Pottery,", "FiberArts,", "Prints,", "Drawing,", "Jewelry,", "Calligrapher,", "CeramicsAndGlass,", "Scrapbooking,", "ScentedProducts," });
            CBItemType.Location = new Point(437, 487);
            CBItemType.Name = "CBItemType";
            CBItemType.Size = new Size(242, 40);
            CBItemType.TabIndex = 38;
            // 
            // LImageP
            // 
            LImageP.AutoSize = true;
            LImageP.Location = new Point(209, 571);
            LImageP.Name = "LImageP";
            LImageP.Size = new Size(80, 32);
            LImageP.TabIndex = 39;
            LImageP.Text = "Image";
            // 
            // TBImageP
            // 
            TBImageP.Location = new Point(437, 564);
            TBImageP.Name = "TBImageP";
            TBImageP.Size = new Size(200, 39);
            TBImageP.TabIndex = 40;
            // 
            // AddProduct
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(932, 781);
            Controls.Add(TBImageP);
            Controls.Add(LImageP);
            Controls.Add(CBItemType);
            Controls.Add(label2);
            Controls.Add(NUDAmountProduct);
            Controls.Add(LAmountIS);
            Controls.Add(LDesP);
            Controls.Add(LPriceP);
            Controls.Add(LProductName);
            Controls.Add(label1);
            Controls.Add(BSubmitP);
            Controls.Add(TBDescriptionP);
            Controls.Add(TBPriceP);
            Controls.Add(TBProductName);
            Name = "AddProduct";
            Text = "AddProduct";
            ((System.ComponentModel.ISupportInitialize)NUDAmountProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LAmountIS;
        private Label LDesP;
        private Label LPriceP;
        private Label LProductName;
        private Label label1;
        private Button BSubmitP;
        private TextBox TBDescriptionP;
        private TextBox TBPriceP;
        private TextBox TBProductName;
        private NumericUpDown NUDAmountProduct;
        private Label label2;
        private ComboBox CBItemType;
        private Label LImageP;
        private TextBox TBImageP;
    }
}