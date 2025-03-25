using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLibrary;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;


namespace CraftConnectDeskPresent
{
    public partial class CraftConnectForm : Form
    {
        //private AccountService accountservice;
        private Business Authorizedbusiness;
        private Admin AuthorizedAdmin;
        private IItemService itemservice;
        private ICouponRepository couponRepo;
        private CouponService couponService;


        public CraftConnectForm(Business Authorizedbusiness, Admin AuthorizedAdmin, IItemService itemservice)
        {
            this.Authorizedbusiness = Authorizedbusiness;
            this.AuthorizedAdmin = AuthorizedAdmin;
            this.itemservice = itemservice;

            couponRepo = new CouponRepository();
            couponService = new CouponService(couponRepo);
            InitializeComponent();
            DatagridLoad();


        }



        public void DatagridLoad()
        {
            if (Authorizedbusiness != null)
            {
                TBCraftConnect.TabPages.Remove(TPCoupons);
                DGVWorkshop.Rows.Clear();

                try
                {
                    foreach (Workshop work in itemservice.GetWorkshop((int)Authorizedbusiness.BusinessId))
                    {
                        DGVWorkshop.Rows.Add(new object[] { work.AmountOfPlaces, work.Location, work.Price, work.WorkshopName, work.WorkshopId });
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Invalid argument: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DatabaseExceptionHandler ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"Logic layer error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while retrieving workshops: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DGVProduct.Rows.Clear();

                try
                {
                    foreach (Product product in itemservice.GetProducts((int)Authorizedbusiness.BusinessId))
                    {
                        DGVProduct.Rows.Add(new object[] { product.AmountInStock, product.TypeOfItem, product.Price, product.ProductName, product.ProductID });
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Invalid argument: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DatabaseExceptionHandler ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"Logic layer error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while retrieving products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (AuthorizedAdmin != null)
            {
                BEditWorkshop.Hide();
                BEditProduct.Hide();
                AddWorkshop.Hide();
                BAddProduct.Hide();
                DGVWorkshop.Rows.Clear();
                TBCraftConnect.TabPages.Remove(TPProfile);

                try
                {
                    foreach (Workshop work in itemservice.GetAllWorkshops())
                    {
                        DGVWorkshop.Rows.Add(new object[] { work.AmountOfPlaces, work.Location, work.Price, work.WorkshopName, work.WorkshopId });
                    }
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"An error occurred while retrieving workshops: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while retrieving workshops: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DGVProduct.Rows.Clear();
                try
                {
                    foreach (Product product in itemservice.GetAllProducts())
                    {
                        DGVProduct.Rows.Add(new object[] { product.AmountInStock, product.TypeOfItem, product.Price, product.ProductName, product.ProductID });
                    }
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"An error occurred while retrieving products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while retrieving products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DGVCoupons.Rows.Clear();
                try
                {
                    foreach (Coupon coupon in couponService.GetAllCoupons())
                    {
                        DGVCoupons.Rows.Add(new object[] { coupon.Description, coupon.ExpirationDate, coupon.Name, coupon.Id });
                    }
                }
                catch (CouponNotFoundException ex)
                {
                    MessageBox.Show($"No coupons found: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (CouponServiceException ex)
                {
                    MessageBox.Show($"An error occurred while retrieving coupons: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while retrieving coupons: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void AddWorkshop_Click(object sender, EventArgs e)
        {
            if (itemservice != null)
            {
                try
                {
                    AddWorkshop addwork = new AddWorkshop(Authorizedbusiness, itemservice, this);
                    addwork.Show();
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"An error occurred while initializing the AddWorkshop form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while initializing the AddWorkshop form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Itemservice is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BLoad_Click(object sender, EventArgs e)
        {


        }

        private void BAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemservice != null)
                {
                    AddProduct addproduct = new AddProduct(Authorizedbusiness, itemservice, this);
                    addproduct.Show();
                }
                else
                {
                    MessageBox.Show("Itemservice is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (LogicLayerException ex)
            {
                MessageBox.Show($"An error occurred while initializing the AddProduct form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while initializing the AddProduct form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void CraftConnectForm_Load(object sender, EventArgs e) // when loading the mainform
        {
            try
            {
                if (Authorizedbusiness != null)
                {
                    try
                    {
                        LHello.Text = $"Hello {Authorizedbusiness.Username}, welcome to Craft Connect";
                        TBBusinessName.Text = Authorizedbusiness.BusinessName;
                        TBFirstname.Text = Authorizedbusiness.FirstName;
                        TBLastname.Text = Authorizedbusiness.LastName;
                        TBPhonenumber.Text = Authorizedbusiness.PhoneNumber;
                        TBAddress.Text = Authorizedbusiness.Address;
                        TBEmail.Text = Authorizedbusiness.EmailAddress;
                        TBUsername.Text = Authorizedbusiness.Username;
                        TBPassword.Text = Authorizedbusiness.Password;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while setting Authorizedbusiness details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (AuthorizedAdmin != null)
                {
                    try
                    {
                        LHello.Text = $"Hello {AuthorizedAdmin.Username}, welcome to Craft Connect";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while setting AuthorizedAdmin details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No authorized user found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred during form load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void BRemoveWo_Click(object sender, EventArgs e)
        {

            if (DGVWorkshop.CurrentCell == null)
            {
                MessageBox.Show("Please select a workshop");
                return;
            }
            int rowIndex = DGVWorkshop.CurrentCell.RowIndex;
            object cellValue = DGVWorkshop.Rows[rowIndex].Cells[4].Value;

            try
            {
                int workshopId = Convert.ToInt32(cellValue);
                MessageBox.Show(workshopId.ToString());

                try
                {
                    itemservice.RemoveWorkshop(workshopId);
                    DatagridLoad(); // Assuming this method reloads the data grid
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"An error occurred while removing the workshop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DatabaseExceptionHandler ex)
                {
                    MessageBox.Show($"A database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Invalid workshop ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while removing the workshop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a workshop that you want to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid workshop ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void BRemoveProduct_Click(object sender, EventArgs e)
        {
            if (DGVProduct.CurrentCell == null)
            {
                MessageBox.Show("Please select a products");
                return;
            }
            int rowIndex = DGVProduct.CurrentCell.RowIndex;
            object cellValue = DGVProduct.Rows[rowIndex].Cells[4].Value;

            try
            {
                int productId = Convert.ToInt32(cellValue);
                MessageBox.Show(productId.ToString());

                try
                {
                    itemservice.RemoveProduct(productId);
                    DatagridLoad(); // Assuming this method reloads the data grid
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"An error occurred while removing the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DatabaseExceptionHandler ex)
                {
                    MessageBox.Show($"A database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Invalid product ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while removing the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a product that you want to remove", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid product ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void BEditWorkshop_Click(object sender, EventArgs e)
        {
            if (DGVWorkshop.CurrentCell == null)
            {
                MessageBox.Show("Please select a workshop");
                return;
            }
            int rowIndex = DGVWorkshop.CurrentCell.RowIndex;

            object cellValue = DGVWorkshop.Rows[rowIndex].Cells[4].Value;

            try
            {
                int workshopId = Convert.ToInt32(cellValue);

                try
                {
                    Workshop workshop = itemservice.GetWorkshopById(workshopId);
                    UpdateWorkshop update = new UpdateWorkshop(itemservice, workshop, this);
                    update.Show();
                }
                catch (WorkshopNotFoundException ex)
                {
                    MessageBox.Show($"Workshop not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (LogicLayerException ex)
                {
                    MessageBox.Show($"An error occurred while retrieving the workshop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DatabaseExceptionHandler ex)
                {
                    MessageBox.Show($"A database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Invalid workshop ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred while retrieving the workshop: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a workshop that you want to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid workshop ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void BEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVProduct.CurrentCell == null)
                {
                    MessageBox.Show("Please select a product");
                    return;
                }

                int rowIndex = DGVProduct.CurrentCell.RowIndex;
                object cellValue = DGVProduct.Rows[rowIndex].Cells[4].Value;

                try
                {
                    int productId = Convert.ToInt32(cellValue);

                    try
                    {
                        Product product = itemservice.GetProductById(productId);
                        UpdateProduct update = new UpdateProduct(itemservice, product, this);
                        update.Show();
                    }
                    catch (ProductNotFoundException ex)
                    {
                        MessageBox.Show($"Product not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (LogicLayerException ex)
                    {
                        MessageBox.Show($"An error occurred while retrieving the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (DatabaseExceptionHandler ex)
                    {
                        MessageBox.Show($"A database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Invalid product ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An unexpected error occurred while retrieving the product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Please select a product that you want to update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid product ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEditCoupon_Click(object sender, EventArgs e)
        {

            try
            {
                if (DGVCoupons.CurrentCell == null)
                {
                    MessageBox.Show("Please select a coupon");
                    return;
                }
                int rowIndex = DGVCoupons.CurrentCell.RowIndex;
                object cellValue = DGVCoupons.Rows[rowIndex].Cells[3].Value;

                try
                {
                    int couponId = Convert.ToInt32(cellValue);

                    try
                    {
                        Coupon coupon = couponService.GetCouponById(couponId);
                        TBCouponDes.Text = coupon.Description;
                        CExpirationDate.SelectionEnd = coupon.ExpirationDate;
                        decimal percentage = coupon.Percentage * 100;
                        NUDPercentage.Value = percentage;
                        TBNameC.Text = coupon.Name;
                    }
                    catch (CouponNotFoundException ex)
                    {
                        MessageBox.Show($"Coupon not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (CouponServiceException ex)
                    {
                        MessageBox.Show($"An error occurred while retrieving the coupon: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (DatabaseExceptionHandler ex)
                    {
                        MessageBox.Show($"A database error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Invalid coupon ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An unexpected error occurred while retrieving the coupon: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Please select a coupon that you want to edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid coupon ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BAddCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (couponService == null)
                {
                    MessageBox.Show("Coupon service is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddCoupon coupon = new AddCoupon(couponService);
                coupon.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVCoupons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVWorkshop.Rows.Clear();
            DGVCoupons.Rows.Clear();
            DGVProduct.Rows.Clear();
            DatagridLoad();
        }

        private void BSubmitCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBCouponDes.Text != null && TBCouponDes.Text != null && CExpirationDate.SelectionRange.Start != null && TBNameC != null && NUDPercentage != null)
                {
                    if (DGVCoupons.CurrentCell == null)
                    {
                        MessageBox.Show("Please select a coupon");
                        return;
                    }
                    int rowIndex = DGVCoupons.CurrentCell.RowIndex;
                    object cellValue = DGVCoupons.Rows[rowIndex].Cells[3].Value;

                    Coupon coupon = couponService.GetCouponById(Convert.ToInt32(cellValue));
                    int id = (int)coupon.Id;
                    DiscountType discounttype = coupon.DiscountType;
                    string description = TBCouponDes.Text;
                    DateTime dateTime = CExpirationDate.SelectionRange.Start;
                    decimal percentage = (NUDPercentage.Value) / 100;
                    string name = TBNameC.Text;
                    Coupon singlecoupon = new Coupon(id, discounttype, name, description, dateTime, percentage);
                    couponService.UpdateCoupon(singlecoupon);
                    DatagridLoad();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid coupon ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CouponNotFoundException ex)
            {
                MessageBox.Show($"Coupon not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BLogOut_Click(object sender, EventArgs e)
        {
            IAccountRepository repo = new AccountRepository();
            IAccountService accountService = new AccountService(repo);
            IItemRepository repoitem = new ItemRepository();
            IItemService itemservice = new ItemService(repoitem);
            this.Hide();
            LogIn login = new LogIn(accountService, itemservice);
            login.Show();
        }
    }
}
