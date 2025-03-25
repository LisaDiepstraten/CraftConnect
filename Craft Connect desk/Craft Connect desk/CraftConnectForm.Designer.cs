namespace CraftConnectDeskPresent
{
    partial class CraftConnectForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CraftConnectForm));
            LCraftConnect = new Label();
            TPHome = new TabPage();
            LHello = new Label();
            PBCC = new PictureBox();
            TPWorkshop = new TabPage();
            BEditWorkshop = new Button();
            BRemoveWo = new Button();
            DGVWorkshop = new DataGridView();
            AmountOfPlaces = new DataGridViewTextBoxColumn();
            Location = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            AddWorkshop = new Button();
            BackgroundImage = new PictureBox();
            TPShop = new TabPage();
            BEditProduct = new Button();
            DGVProduct = new DataGridView();
            AmountInStock = new DataGridViewTextBoxColumn();
            TypeOfItemP = new DataGridViewTextBoxColumn();
            PriceP = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            ProductId = new DataGridViewTextBoxColumn();
            BRemoveProduct = new Button();
            BAddProduct = new Button();
            PBCC2 = new PictureBox();
            TPProfile = new TabPage();
            TBBusinessName = new TextBox();
            LBusinessName = new Label();
            LEmail = new Label();
            TBEmail = new TextBox();
            LAccount = new Label();
            TBPassword = new TextBox();
            TBUsername = new TextBox();
            TBAddress = new TextBox();
            TBPhonenumber = new TextBox();
            TBLastname = new TextBox();
            TBFirstname = new TextBox();
            LPassword = new Label();
            LUsername = new Label();
            LAddress = new Label();
            LPhonenumber = new Label();
            LLastname = new Label();
            LFirstname = new Label();
            pictureBox4 = new PictureBox();
            TBCraftConnect = new TabControl();
            TPCoupons = new TabPage();
            BSubmitCoupon = new Button();
            TBNameC = new TextBox();
            NUDPercentage = new NumericUpDown();
            CExpirationDate = new MonthCalendar();
            BAddCoupon = new Button();
            BEditCoupon = new Button();
            TBCouponDes = new TextBox();
            DGVCoupons = new DataGridView();
            DescriptionC = new DataGridViewTextBoxColumn();
            ExpirationDateC = new DataGridViewTextBoxColumn();
            NameC = new DataGridViewTextBoxColumn();
            DiscountType = new DataGridViewTextBoxColumn();
            PBCC6 = new PictureBox();
            BLogOut = new Button();
            TPHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBCC).BeginInit();
            TPWorkshop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVWorkshop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundImage).BeginInit();
            TPShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBCC2).BeginInit();
            TPProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            TBCraftConnect.SuspendLayout();
            TPCoupons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUDPercentage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVCoupons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBCC6).BeginInit();
            SuspendLayout();
            // 
            // LCraftConnect
            // 
            LCraftConnect.AutoSize = true;
            LCraftConnect.Font = new Font("Segoe UI", 25.875F, FontStyle.Bold, GraphicsUnit.Point);
            LCraftConnect.Location = new Point(126, 9);
            LCraftConnect.Name = "LCraftConnect";
            LCraftConnect.Size = new Size(485, 92);
            LCraftConnect.TabIndex = 1;
            LCraftConnect.Text = "Craft Connect";
            // 
            // TPHome
            // 
            TPHome.BackColor = Color.FromArgb(27, 154, 170);
            TPHome.Controls.Add(LHello);
            TPHome.Controls.Add(PBCC);
            TPHome.Location = new Point(4, 64);
            TPHome.Name = "TPHome";
            TPHome.Padding = new Padding(3);
            TPHome.Size = new Size(1558, 941);
            TPHome.TabIndex = 0;
            TPHome.Text = "Home";
            // 
            // LHello
            // 
            LHello.AutoSize = true;
            LHello.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point);
            LHello.Location = new Point(166, 180);
            LHello.Name = "LHello";
            LHello.Size = new Size(789, 72);
            LHello.TabIndex = 5;
            LHello.Text = "Welcome to Craft Connect";
            // 
            // PBCC
            // 
            PBCC.Image = (Image)resources.GetObject("PBCC.Image");
            PBCC.Location = new Point(-13, -25);
            PBCC.Name = "PBCC";
            PBCC.Size = new Size(1577, 1004);
            PBCC.SizeMode = PictureBoxSizeMode.StretchImage;
            PBCC.TabIndex = 4;
            PBCC.TabStop = false;
            // 
            // TPWorkshop
            // 
            TPWorkshop.BackColor = Color.FromArgb(206, 217, 232);
            TPWorkshop.Controls.Add(BEditWorkshop);
            TPWorkshop.Controls.Add(BRemoveWo);
            TPWorkshop.Controls.Add(DGVWorkshop);
            TPWorkshop.Controls.Add(AddWorkshop);
            TPWorkshop.Controls.Add(BackgroundImage);
            TPWorkshop.Location = new Point(4, 64);
            TPWorkshop.Name = "TPWorkshop";
            TPWorkshop.Padding = new Padding(3);
            TPWorkshop.Size = new Size(1558, 941);
            TPWorkshop.TabIndex = 1;
            TPWorkshop.Text = "Workshop";
            // 
            // BEditWorkshop
            // 
            BEditWorkshop.Location = new Point(1230, 329);
            BEditWorkshop.Name = "BEditWorkshop";
            BEditWorkshop.Size = new Size(241, 99);
            BEditWorkshop.TabIndex = 8;
            BEditWorkshop.Text = "Edit Workshop";
            BEditWorkshop.UseVisualStyleBackColor = true;
            BEditWorkshop.Click += BEditWorkshop_Click;
            // 
            // BRemoveWo
            // 
            BRemoveWo.Location = new Point(1230, 481);
            BRemoveWo.Name = "BRemoveWo";
            BRemoveWo.Size = new Size(241, 119);
            BRemoveWo.TabIndex = 7;
            BRemoveWo.Text = "Remove Workshop";
            BRemoveWo.UseVisualStyleBackColor = true;
            BRemoveWo.Click += BRemoveWo_Click;
            // 
            // DGVWorkshop
            // 
            DGVWorkshop.BackgroundColor = Color.White;
            DGVWorkshop.BorderStyle = BorderStyle.None;
            DGVWorkshop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVWorkshop.Columns.AddRange(new DataGridViewColumn[] { AmountOfPlaces, Location, Price, Name, Id });
            DGVWorkshop.Location = new Point(23, 75);
            DGVWorkshop.Name = "DGVWorkshop";
            DGVWorkshop.RowHeadersWidth = 82;
            DGVWorkshop.RowTemplate.Height = 41;
            DGVWorkshop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVWorkshop.Size = new Size(1088, 694);
            DGVWorkshop.TabIndex = 5;
            // 
            // AmountOfPlaces
            // 
            AmountOfPlaces.HeaderText = "Amount of places";
            AmountOfPlaces.MinimumWidth = 10;
            AmountOfPlaces.Name = "AmountOfPlaces";
            AmountOfPlaces.Width = 200;
            // 
            // Location
            // 
            Location.HeaderText = "Location";
            Location.MinimumWidth = 10;
            Location.Name = "Location";
            Location.Width = 200;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 10;
            Price.Name = "Price";
            Price.Width = 200;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.MinimumWidth = 10;
            Name.Name = "Name";
            Name.Width = 200;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 10;
            Id.Name = "Id";
            Id.Width = 200;
            // 
            // AddWorkshop
            // 
            AddWorkshop.Location = new Point(1230, 652);
            AddWorkshop.Name = "AddWorkshop";
            AddWorkshop.Size = new Size(241, 117);
            AddWorkshop.TabIndex = 1;
            AddWorkshop.Text = "Add Workshop";
            AddWorkshop.UseVisualStyleBackColor = true;
            AddWorkshop.Click += AddWorkshop_Click;
            // 
            // BackgroundImage
            // 
            BackgroundImage.Image = (Image)resources.GetObject("BackgroundImage.Image");
            BackgroundImage.Location = new Point(-13, -25);
            BackgroundImage.Name = "BackgroundImage";
            BackgroundImage.Size = new Size(1577, 1004);
            BackgroundImage.SizeMode = PictureBoxSizeMode.StretchImage;
            BackgroundImage.TabIndex = 4;
            BackgroundImage.TabStop = false;
            // 
            // TPShop
            // 
            TPShop.Controls.Add(BEditProduct);
            TPShop.Controls.Add(DGVProduct);
            TPShop.Controls.Add(BRemoveProduct);
            TPShop.Controls.Add(BAddProduct);
            TPShop.Controls.Add(PBCC2);
            TPShop.Location = new Point(4, 64);
            TPShop.Name = "TPShop";
            TPShop.Padding = new Padding(3);
            TPShop.Size = new Size(1558, 941);
            TPShop.TabIndex = 2;
            TPShop.Text = "Shop";
            TPShop.UseVisualStyleBackColor = true;
            // 
            // BEditProduct
            // 
            BEditProduct.Location = new Point(1249, 266);
            BEditProduct.Name = "BEditProduct";
            BEditProduct.Size = new Size(224, 108);
            BEditProduct.TabIndex = 8;
            BEditProduct.Text = "Edit product";
            BEditProduct.UseVisualStyleBackColor = true;
            BEditProduct.Click += BEditProduct_Click;
            // 
            // DGVProduct
            // 
            DGVProduct.BackgroundColor = Color.White;
            DGVProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVProduct.Columns.AddRange(new DataGridViewColumn[] { AmountInStock, TypeOfItemP, PriceP, ProductName, ProductId });
            DGVProduct.Location = new Point(139, 93);
            DGVProduct.Name = "DGVProduct";
            DGVProduct.RowHeadersWidth = 82;
            DGVProduct.RowTemplate.Height = 41;
            DGVProduct.Size = new Size(988, 612);
            DGVProduct.TabIndex = 7;
            // 
            // AmountInStock
            // 
            AmountInStock.HeaderText = "Amount in stock";
            AmountInStock.MinimumWidth = 10;
            AmountInStock.Name = "AmountInStock";
            AmountInStock.Width = 200;
            // 
            // TypeOfItemP
            // 
            TypeOfItemP.HeaderText = "Item Type";
            TypeOfItemP.MinimumWidth = 10;
            TypeOfItemP.Name = "TypeOfItemP";
            TypeOfItemP.Width = 200;
            // 
            // PriceP
            // 
            PriceP.HeaderText = "Price";
            PriceP.MinimumWidth = 10;
            PriceP.Name = "PriceP";
            PriceP.Width = 200;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Name";
            ProductName.MinimumWidth = 10;
            ProductName.Name = "ProductName";
            ProductName.Width = 200;
            // 
            // ProductId
            // 
            ProductId.HeaderText = "Id";
            ProductId.MinimumWidth = 10;
            ProductId.Name = "ProductId";
            ProductId.Width = 200;
            // 
            // BRemoveProduct
            // 
            BRemoveProduct.Location = new Point(1249, 436);
            BRemoveProduct.Name = "BRemoveProduct";
            BRemoveProduct.Size = new Size(224, 113);
            BRemoveProduct.TabIndex = 6;
            BRemoveProduct.Text = "Remove product";
            BRemoveProduct.UseVisualStyleBackColor = true;
            BRemoveProduct.Click += BRemoveProduct_Click;
            // 
            // BAddProduct
            // 
            BAddProduct.Location = new Point(1249, 609);
            BAddProduct.Name = "BAddProduct";
            BAddProduct.Size = new Size(224, 115);
            BAddProduct.TabIndex = 1;
            BAddProduct.Text = "add product";
            BAddProduct.UseVisualStyleBackColor = true;
            BAddProduct.Click += BAddProduct_Click;
            // 
            // PBCC2
            // 
            PBCC2.Image = (Image)resources.GetObject("PBCC2.Image");
            PBCC2.Location = new Point(-13, -25);
            PBCC2.Name = "PBCC2";
            PBCC2.Size = new Size(1577, 1004);
            PBCC2.SizeMode = PictureBoxSizeMode.StretchImage;
            PBCC2.TabIndex = 4;
            PBCC2.TabStop = false;
            // 
            // TPProfile
            // 
            TPProfile.Controls.Add(TBBusinessName);
            TPProfile.Controls.Add(LBusinessName);
            TPProfile.Controls.Add(LEmail);
            TPProfile.Controls.Add(TBEmail);
            TPProfile.Controls.Add(LAccount);
            TPProfile.Controls.Add(TBPassword);
            TPProfile.Controls.Add(TBUsername);
            TPProfile.Controls.Add(TBAddress);
            TPProfile.Controls.Add(TBPhonenumber);
            TPProfile.Controls.Add(TBLastname);
            TPProfile.Controls.Add(TBFirstname);
            TPProfile.Controls.Add(LPassword);
            TPProfile.Controls.Add(LUsername);
            TPProfile.Controls.Add(LAddress);
            TPProfile.Controls.Add(LPhonenumber);
            TPProfile.Controls.Add(LLastname);
            TPProfile.Controls.Add(LFirstname);
            TPProfile.Controls.Add(pictureBox4);
            TPProfile.Location = new Point(4, 64);
            TPProfile.Name = "TPProfile";
            TPProfile.Padding = new Padding(3);
            TPProfile.Size = new Size(1558, 941);
            TPProfile.TabIndex = 4;
            TPProfile.Text = "Profile";
            TPProfile.UseVisualStyleBackColor = true;
            // 
            // TBBusinessName
            // 
            TBBusinessName.Enabled = false;
            TBBusinessName.Location = new Point(264, 181);
            TBBusinessName.Name = "TBBusinessName";
            TBBusinessName.Size = new Size(315, 39);
            TBBusinessName.TabIndex = 21;
            // 
            // LBusinessName
            // 
            LBusinessName.AutoSize = true;
            LBusinessName.Location = new Point(63, 184);
            LBusinessName.Name = "LBusinessName";
            LBusinessName.Size = new Size(174, 32);
            LBusinessName.TabIndex = 20;
            LBusinessName.Text = "Business name";
            // 
            // LEmail
            // 
            LEmail.AutoSize = true;
            LEmail.Location = new Point(736, 474);
            LEmail.Name = "LEmail";
            LEmail.Size = new Size(162, 32);
            LEmail.TabIndex = 19;
            LEmail.Text = "Email address";
            // 
            // TBEmail
            // 
            TBEmail.Enabled = false;
            TBEmail.Location = new Point(961, 467);
            TBEmail.Name = "TBEmail";
            TBEmail.Size = new Size(315, 39);
            TBEmail.TabIndex = 18;
            // 
            // LAccount
            // 
            LAccount.AutoSize = true;
            LAccount.BackColor = Color.Transparent;
            LAccount.Font = new Font("Arial", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            LAccount.Location = new Point(736, 68);
            LAccount.Name = "LAccount";
            LAccount.Size = new Size(297, 51);
            LAccount.TabIndex = 17;
            LAccount.Text = "Your Account";
            // 
            // TBPassword
            // 
            TBPassword.Enabled = false;
            TBPassword.Location = new Point(961, 605);
            TBPassword.Name = "TBPassword";
            TBPassword.Size = new Size(315, 39);
            TBPassword.TabIndex = 16;
            // 
            // TBUsername
            // 
            TBUsername.Enabled = false;
            TBUsername.Location = new Point(961, 535);
            TBUsername.Name = "TBUsername";
            TBUsername.Size = new Size(315, 39);
            TBUsername.TabIndex = 15;
            // 
            // TBAddress
            // 
            TBAddress.Enabled = false;
            TBAddress.Location = new Point(961, 398);
            TBAddress.Name = "TBAddress";
            TBAddress.Size = new Size(315, 39);
            TBAddress.TabIndex = 14;
            // 
            // TBPhonenumber
            // 
            TBPhonenumber.Enabled = false;
            TBPhonenumber.Location = new Point(961, 330);
            TBPhonenumber.Name = "TBPhonenumber";
            TBPhonenumber.Size = new Size(315, 39);
            TBPhonenumber.TabIndex = 13;
            // 
            // TBLastname
            // 
            TBLastname.Enabled = false;
            TBLastname.Location = new Point(961, 249);
            TBLastname.Name = "TBLastname";
            TBLastname.Size = new Size(315, 39);
            TBLastname.TabIndex = 12;
            // 
            // TBFirstname
            // 
            TBFirstname.Enabled = false;
            TBFirstname.Location = new Point(961, 177);
            TBFirstname.Name = "TBFirstname";
            TBFirstname.Size = new Size(315, 39);
            TBFirstname.TabIndex = 11;
            // 
            // LPassword
            // 
            LPassword.AutoSize = true;
            LPassword.Location = new Point(736, 612);
            LPassword.Name = "LPassword";
            LPassword.Size = new Size(115, 32);
            LPassword.TabIndex = 10;
            LPassword.Text = "Password";
            // 
            // LUsername
            // 
            LUsername.AutoSize = true;
            LUsername.Location = new Point(736, 542);
            LUsername.Name = "LUsername";
            LUsername.Size = new Size(124, 32);
            LUsername.TabIndex = 9;
            LUsername.Text = "Username";
            // 
            // LAddress
            // 
            LAddress.AutoSize = true;
            LAddress.Location = new Point(736, 405);
            LAddress.Name = "LAddress";
            LAddress.Size = new Size(100, 32);
            LAddress.TabIndex = 8;
            LAddress.Text = "Address";
            // 
            // LPhonenumber
            // 
            LPhonenumber.AutoSize = true;
            LPhonenumber.Location = new Point(736, 337);
            LPhonenumber.Name = "LPhonenumber";
            LPhonenumber.Size = new Size(175, 32);
            LPhonenumber.TabIndex = 7;
            LPhonenumber.Text = "Phone number";
            // 
            // LLastname
            // 
            LLastname.AutoSize = true;
            LLastname.Location = new Point(738, 256);
            LLastname.Name = "LLastname";
            LLastname.Size = new Size(119, 32);
            LLastname.TabIndex = 6;
            LLastname.Text = "Lastname";
            // 
            // LFirstname
            // 
            LFirstname.AutoSize = true;
            LFirstname.Location = new Point(741, 184);
            LFirstname.Name = "LFirstname";
            LFirstname.Size = new Size(121, 32);
            LFirstname.TabIndex = 5;
            LFirstname.Text = "Firstname";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(-13, -25);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(1577, 1004);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // TBCraftConnect
            // 
            TBCraftConnect.Appearance = TabAppearance.FlatButtons;
            TBCraftConnect.Controls.Add(TPProfile);
            TBCraftConnect.Controls.Add(TPShop);
            TBCraftConnect.Controls.Add(TPWorkshop);
            TBCraftConnect.Controls.Add(TPHome);
            TBCraftConnect.Controls.Add(TPCoupons);
            TBCraftConnect.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TBCraftConnect.ItemSize = new Size(161, 60);
            TBCraftConnect.Location = new Point(12, 114);
            TBCraftConnect.Name = "TBCraftConnect";
            TBCraftConnect.Padding = new Point(15, 6);
            TBCraftConnect.RightToLeft = RightToLeft.Yes;
            TBCraftConnect.RightToLeftLayout = true;
            TBCraftConnect.SelectedIndex = 0;
            TBCraftConnect.Size = new Size(1566, 1009);
            TBCraftConnect.TabIndex = 0;
            // 
            // TPCoupons
            // 
            TPCoupons.Controls.Add(BSubmitCoupon);
            TPCoupons.Controls.Add(TBNameC);
            TPCoupons.Controls.Add(NUDPercentage);
            TPCoupons.Controls.Add(CExpirationDate);
            TPCoupons.Controls.Add(BAddCoupon);
            TPCoupons.Controls.Add(BEditCoupon);
            TPCoupons.Controls.Add(TBCouponDes);
            TPCoupons.Controls.Add(DGVCoupons);
            TPCoupons.Controls.Add(PBCC6);
            TPCoupons.Location = new Point(4, 64);
            TPCoupons.Name = "TPCoupons";
            TPCoupons.Padding = new Padding(3);
            TPCoupons.Size = new Size(1558, 941);
            TPCoupons.TabIndex = 5;
            TPCoupons.Text = "Coupons";
            TPCoupons.UseVisualStyleBackColor = true;
            // 
            // BSubmitCoupon
            // 
            BSubmitCoupon.Location = new Point(1190, 583);
            BSubmitCoupon.Name = "BSubmitCoupon";
            BSubmitCoupon.Size = new Size(250, 97);
            BSubmitCoupon.TabIndex = 13;
            BSubmitCoupon.Text = "Submit";
            BSubmitCoupon.UseVisualStyleBackColor = true;
            BSubmitCoupon.Click += BSubmitCoupon_Click;
            // 
            // TBNameC
            // 
            TBNameC.Location = new Point(31, 855);
            TBNameC.Name = "TBNameC";
            TBNameC.Size = new Size(1086, 39);
            TBNameC.TabIndex = 12;
            // 
            // NUDPercentage
            // 
            NUDPercentage.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            NUDPercentage.Location = new Point(1190, 494);
            NUDPercentage.Name = "NUDPercentage";
            NUDPercentage.Size = new Size(240, 39);
            NUDPercentage.TabIndex = 11;
            NUDPercentage.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // CExpirationDate
            // 
            CExpirationDate.Location = new Point(706, 493);
            CExpirationDate.Name = "CExpirationDate";
            CExpirationDate.TabIndex = 10;
            // 
            // BAddCoupon
            // 
            BAddCoupon.Location = new Point(1207, 247);
            BAddCoupon.Name = "BAddCoupon";
            BAddCoupon.Size = new Size(223, 73);
            BAddCoupon.TabIndex = 9;
            BAddCoupon.Text = "Add";
            BAddCoupon.UseVisualStyleBackColor = true;
            BAddCoupon.Click += BAddCoupon_Click;
            // 
            // BEditCoupon
            // 
            BEditCoupon.Location = new Point(1207, 141);
            BEditCoupon.Name = "BEditCoupon";
            BEditCoupon.Size = new Size(223, 73);
            BEditCoupon.TabIndex = 7;
            BEditCoupon.Text = "Edit";
            BEditCoupon.UseVisualStyleBackColor = true;
            BEditCoupon.Click += BEditCoupon_Click;
            // 
            // TBCouponDes
            // 
            TBCouponDes.Location = new Point(31, 493);
            TBCouponDes.Multiline = true;
            TBCouponDes.Name = "TBCouponDes";
            TBCouponDes.ScrollBars = ScrollBars.Vertical;
            TBCouponDes.Size = new Size(595, 288);
            TBCouponDes.TabIndex = 6;
            // 
            // DGVCoupons
            // 
            DGVCoupons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVCoupons.Columns.AddRange(new DataGridViewColumn[] { DescriptionC, ExpirationDateC, NameC, DiscountType });
            DGVCoupons.Location = new Point(6, 48);
            DGVCoupons.Name = "DGVCoupons";
            DGVCoupons.RowHeadersWidth = 82;
            DGVCoupons.RowTemplate.Height = 41;
            DGVCoupons.Size = new Size(1178, 391);
            DGVCoupons.TabIndex = 0;
            DGVCoupons.CellContentClick += DGVCoupons_CellContentClick;
            // 
            // DescriptionC
            // 
            DescriptionC.HeaderText = "Description";
            DescriptionC.MinimumWidth = 10;
            DescriptionC.Name = "DescriptionC";
            DescriptionC.Width = 400;
            // 
            // ExpirationDateC
            // 
            ExpirationDateC.HeaderText = "Expiration Date";
            ExpirationDateC.MinimumWidth = 10;
            ExpirationDateC.Name = "ExpirationDateC";
            ExpirationDateC.Width = 200;
            // 
            // NameC
            // 
            NameC.HeaderText = "Name Coupon";
            NameC.MinimumWidth = 10;
            NameC.Name = "NameC";
            NameC.Width = 300;
            // 
            // DiscountType
            // 
            DiscountType.HeaderText = "Id";
            DiscountType.MinimumWidth = 10;
            DiscountType.Name = "DiscountType";
            DiscountType.Width = 200;
            // 
            // PBCC6
            // 
            PBCC6.Image = (Image)resources.GetObject("PBCC6.Image");
            PBCC6.Location = new Point(-9, -32);
            PBCC6.Name = "PBCC6";
            PBCC6.Size = new Size(1577, 1004);
            PBCC6.SizeMode = PictureBoxSizeMode.StretchImage;
            PBCC6.TabIndex = 5;
            PBCC6.TabStop = false;
            // 
            // BLogOut
            // 
            BLogOut.Location = new Point(1412, 23);
            BLogOut.Name = "BLogOut";
            BLogOut.Size = new Size(150, 46);
            BLogOut.TabIndex = 2;
            BLogOut.Text = "Log out";
            BLogOut.UseVisualStyleBackColor = true;
            BLogOut.Click += BLogOut_Click;
            // 
            // CraftConnectForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(122, 156, 198);
            ClientSize = new Size(1574, 1125);
            Controls.Add(BLogOut);
            Controls.Add(TBCraftConnect);
            Controls.Add(LCraftConnect);
           
            Text = "Craft Connect";
            Load += CraftConnectForm_Load;
            TPHome.ResumeLayout(false);
            TPHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBCC).EndInit();
            TPWorkshop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVWorkshop).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundImage).EndInit();
            TPShop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBCC2).EndInit();
            TPProfile.ResumeLayout(false);
            TPProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            TBCraftConnect.ResumeLayout(false);
            TPCoupons.ResumeLayout(false);
            TPCoupons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUDPercentage).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVCoupons).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBCC6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LCraftConnect;
        private TabPage TPHome;
        private Label LHello;
        private PictureBox PBCC;
        private TabPage TPWorkshop;
        private Button BEditWorkshop;
        private Button BRemoveWo;
        private DataGridView DGVWorkshop;
        private DataGridViewTextBoxColumn AmountOfPlaces;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Id;
        private Button AddWorkshop;
        private PictureBox BackgroundImage;
        private TabPage TPShop;
        private Button BEditProduct;
        private DataGridView DGVProduct;
        private DataGridViewTextBoxColumn AmountInStock;
        private DataGridViewTextBoxColumn TypeOfItemP;
        private DataGridViewTextBoxColumn PriceP;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductId;
        private Button BRemoveProduct;
        private Button BAddProduct;
        private PictureBox PBCC2;
        private TabPage TPProfile;
        private TextBox TBBusinessName;
        private Label LBusinessName;
        private Label LEmail;
        private TextBox TBEmail;
        private Label LAccount;
        private TextBox TBPassword;
        private TextBox TBUsername;
        private TextBox TBAddress;
        private TextBox TBPhonenumber;
        private TextBox TBLastname;
        private TextBox TBFirstname;
        private Label LPassword;
        private Label LUsername;
        private Label LAddress;
        private Label LPhonenumber;
        private Label LLastname;
        private Label LFirstname;
        private PictureBox pictureBox4;
        private TabControl TBCraftConnect;
        private TabPage TPCoupons;
        private DataGridView DGVCoupons;
        private PictureBox PBCC6;
        private TextBox TBCouponDes;
        private Button BEditCoupon;
        private Button BAddCoupon;
        private Button BSubmitCoupon;
        private TextBox TBNameC;
        private NumericUpDown NUDPercentage;
        private MonthCalendar CExpirationDate;
        private DataGridViewTextBoxColumn DescriptionC;
        private DataGridViewTextBoxColumn ExpirationDateC;
        private DataGridViewTextBoxColumn NameC;
        private DataGridViewTextBoxColumn DiscountType;
        private Button BLogOut;
    }
}
