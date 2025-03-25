namespace CraftConnectDeskPresent
{
    partial class UpdateProduct
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
            TBImagePU = new TextBox();
            LImagePU = new Label();
            CBItemTypeU = new ComboBox();
            ItemTypeU = new Label();
            NUDAmountProductU = new NumericUpDown();
            LAmountISU = new Label();
            LDescriptionPU = new Label();
            LPricePU = new Label();
            LProductNameU = new Label();
            label1 = new Label();
            BSubmitPU = new Button();
            TBDescriptionPU = new TextBox();
            TBPricePU = new TextBox();
            TBProductNameU = new TextBox();
            ((System.ComponentModel.ISupportInitialize)NUDAmountProductU).BeginInit();
            SuspendLayout();
            // 
            // TBImagePU
            // 
            TBImagePU.Location = new Point(289, 557);
            TBImagePU.Name = "TBImagePU";
            TBImagePU.Size = new Size(478, 39);
            TBImagePU.TabIndex = 54;
            // 
            // LImagePU
            // 
            LImagePU.AutoSize = true;
            LImagePU.Location = new Point(61, 564);
            LImagePU.Name = "LImagePU";
            LImagePU.Size = new Size(80, 32);
            LImagePU.TabIndex = 53;
            LImagePU.Text = "Image";
            // 
            // CBItemTypeU
            // 
            CBItemTypeU.FormattingEnabled = true;
            CBItemTypeU.Items.AddRange(new object[] { "Painting,", "Pottery,", "FiberArts,", "Prints,", "Drawing,", "Jewelry,", "Calligrapher,", "CeramicsAndGlass,", "Scrapbooking,", "ScentedProducts," });
            CBItemTypeU.Location = new Point(289, 480);
            CBItemTypeU.Name = "CBItemTypeU";
            CBItemTypeU.Size = new Size(242, 40);
            CBItemTypeU.TabIndex = 52;
            // 
            // ItemTypeU
            // 
            ItemTypeU.AutoSize = true;
            ItemTypeU.Location = new Point(61, 488);
            ItemTypeU.Name = "ItemTypeU";
            ItemTypeU.Size = new Size(116, 32);
            ItemTypeU.TabIndex = 51;
            ItemTypeU.Text = "Item type";
            // 
            // NUDAmountProductU
            // 
            NUDAmountProductU.Location = new Point(289, 417);
            NUDAmountProductU.Name = "NUDAmountProductU";
            NUDAmountProductU.Size = new Size(240, 39);
            NUDAmountProductU.TabIndex = 50;
            NUDAmountProductU.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // LAmountISU
            // 
            LAmountISU.AutoSize = true;
            LAmountISU.Location = new Point(61, 424);
            LAmountISU.Name = "LAmountISU";
            LAmountISU.Size = new Size(189, 32);
            LAmountISU.TabIndex = 49;
            LAmountISU.Text = "Amount in stock";
            // 
            // LDescriptionPU
            // 
            LDescriptionPU.AutoSize = true;
            LDescriptionPU.Location = new Point(61, 197);
            LDescriptionPU.Name = "LDescriptionPU";
            LDescriptionPU.Size = new Size(135, 32);
            LDescriptionPU.TabIndex = 48;
            LDescriptionPU.Text = "Description";
            // 
            // LPricePU
            // 
            LPricePU.AutoSize = true;
            LPricePU.Location = new Point(61, 126);
            LPricePU.Name = "LPricePU";
            LPricePU.Size = new Size(65, 32);
            LPricePU.TabIndex = 47;
            LPricePU.Text = "Price";
            // 
            // LProductNameU
            // 
            LProductNameU.AutoSize = true;
            LProductNameU.Location = new Point(61, 58);
            LProductNameU.Name = "LProductNameU";
            LProductNameU.Size = new Size(163, 32);
            LProductNameU.TabIndex = 46;
            LProductNameU.Text = "Product name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 177);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 45;
            // 
            // BSubmitPU
            // 
            BSubmitPU.Location = new Point(289, 685);
            BSubmitPU.Name = "BSubmitPU";
            BSubmitPU.Size = new Size(200, 46);
            BSubmitPU.TabIndex = 44;
            BSubmitPU.Text = "Submit";
            BSubmitPU.UseVisualStyleBackColor = true;
            BSubmitPU.Click += BSubmitPU_Click;
            // 
            // TBDescriptionPU
            // 
            TBDescriptionPU.Location = new Point(289, 197);
            TBDescriptionPU.Multiline = true;
            TBDescriptionPU.Name = "TBDescriptionPU";
            TBDescriptionPU.Size = new Size(383, 197);
            TBDescriptionPU.TabIndex = 43;
            // 
            // TBPricePU
            // 
            TBPricePU.Location = new Point(289, 119);
            TBPricePU.Name = "TBPricePU";
            TBPricePU.Size = new Size(200, 39);
            TBPricePU.TabIndex = 42;
            // 
            // TBProductNameU
            // 
            TBProductNameU.Location = new Point(289, 51);
            TBProductNameU.Name = "TBProductNameU";
            TBProductNameU.Size = new Size(200, 39);
            TBProductNameU.TabIndex = 41;
            // 
            // UpdateProduct
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(779, 787);
            Controls.Add(TBImagePU);
            Controls.Add(LImagePU);
            Controls.Add(CBItemTypeU);
            Controls.Add(ItemTypeU);
            Controls.Add(NUDAmountProductU);
            Controls.Add(LAmountISU);
            Controls.Add(LDescriptionPU);
            Controls.Add(LPricePU);
            Controls.Add(LProductNameU);
            Controls.Add(label1);
            Controls.Add(BSubmitPU);
            Controls.Add(TBDescriptionPU);
            Controls.Add(TBPricePU);
            Controls.Add(TBProductNameU);
            Name = "UpdateProduct";
            Text = "UpdateProduct";
            ((System.ComponentModel.ISupportInitialize)NUDAmountProductU).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TBImagePU;
        private Label LImagePU;
        private ComboBox CBItemTypeU;
        private Label ItemTypeU;
        private NumericUpDown NUDAmountProductU;
        private Label LAmountISU;
        private Label LDescriptionPU;
        private Label LPricePU;
        private Label LProductNameU;
        private Label label1;
        private Button BSubmitPU;
        private TextBox TBDescriptionPU;
        private TextBox TBPricePU;
        private TextBox TBProductNameU;
    }
}