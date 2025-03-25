using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLibrary;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationCraftConnect.Models;

namespace WebApplicationCraftConnect.Pages
{
    [Authorize(Roles = $"{nameof(UserTypes.customer)},{nameof(UserTypes.admin)}")]
    public class CartModel : PageModel
    {
       

        private IItemRepository itemrepository;
        private ICartRepository cartRepository;
        private IAccountRepository accountrepository;
        private ItemService itemService;
        private CartService cartService;
        private AccountService accountService;
      
        private DiscountGiver discountInitialise;
        private ICouponRepository couponRepository;
        private CouponService couponService;
        public List<Coupon> CouponList = new List<Coupon>();



        public CartModel()
        {
           
            discountInitialise = new DiscountGiver(DiscountType.CustomDiscount);
            itemrepository = new ItemRepository();
            cartRepository = new CartRepository();
            accountrepository = new AccountRepository();
            accountService = new AccountService(accountrepository);
            cartService = new CartService(cartRepository);
            itemService = new ItemService(itemrepository);
            couponRepository = new CouponRepository();
            couponService = new CouponService(couponRepository);
        }

        public decimal discount { get; set; }
        public DiscountType discountType { get; set; }

       
       
        public List<Product> cartproducts = new List<Product>();
        public List<Workshop> cartworkshops = new List<Workshop>();
        public void OnGet(int? id) // item id, method is called when page gets requested
        {
            

            cartproducts.Clear();
            cartworkshops.Clear();
            if (id != null)
            {
                var page = Request.Query["page"];
                var buttontype = Request.Query["ButtonType"];
                if (page == "Products")
                {
                    AddProductToCart((int)id);
                }
                if (page == "Workshops")
                {
                    AddWorkshopToCart((int)id);
                }

            }
            else
            {
                LoadAllItemsOfUser();

                LoadAllItemsOfUser();
                LoadAllCouponsOfUser();

                ViewData["DisplayCartTotal"] = LoadCartTotal();

             

            }
            LoadAllItemsOfUser();

            LoadAllItemsOfUser();
            LoadAllCouponsOfUser();

            ViewData["DisplayCartTotal"] = LoadCartTotal();

        }
        public IActionResult OnPostChooseDiscount(int DiscountId, DiscountType discounttype)
        {
            if (ModelState.IsValid)
            {
                
                discount = GetDiscountedPrice(DiscountId, discounttype);
                discountType = discounttype;

                TempData["DisplayTotalAfterCoupon"] = discount.ToString();
                TempData["DisplayTotalAmount"] = (LoadCartTotal() - discount).ToString();
                return RedirectToPage("/Cart");
            }
            return RedirectToPage("/Cart");

        }


        public IActionResult OnPostRemoveProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                RemoveProductFromCart(productId);
                return RedirectToPage("/Cart");
            }
            return RedirectToPage("/Cart");

        }

        public IActionResult OnPostRemoveWorkshop(int workshopId)
        {
            if (ModelState.IsValid)
            {
                RemoveWorkshopFromCart(workshopId);
                return RedirectToPage("/Cart");
            }
            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostCheckout()
        {
            if (ModelState.IsValid)
            {
                User user = getUser();
                decimal cartTotal = LoadCartTotal();
                cartService.SetPointsUser(cartTotal, (int)user.UserId); // setting points in the database
               
                itemService.DecreaseAmount((int)user.ShoppingcartId);
                cartService.EmptyCart((int)user.ShoppingcartId);
                return RedirectToPage("/Cart");
            }
            return RedirectToPage("/Cart");
        }

        public decimal CalculateCartAmount()
        {
            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);

                User user = accountService.GetUserById((int)userIdValue);
                decimal ShoppingCartAmount = cartService.GetTotalOfCart((int)user.ShoppingcartId);
                return ShoppingCartAmount;
            }
            return 0;
        }


        public void AddWorkshopToCart(int workshopid)
        {

            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);

                User user = accountService.GetUserById((int)userIdValue);   //getting the cart id with the userid
                cartService.InsertWorkshopToCart((int)user.ShoppingcartId, workshopid);  // adding the workshop to the cart of the user
                List<int> workshopids = new List<int>();
                workshopids = cartService.GetIDsFromCartW((int)user.ShoppingcartId);  // here I get all the workshop id's that are in the shopping cart for that user

                
                cartworkshops = cartService.GetWorkshopsWithQuantity((int)user.ShoppingcartId);
                
            }
            
        }

        public void AddProductToCart(int productid)
        {
            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);

                User user = accountService.GetUserById((int)userIdValue);

                cartService.InsertProductToCart((int)user.ShoppingcartId, productid);  // adding the product to the cart of the user
                List<int> productids = new List<int>();
                productids = cartService.GetIDsFromCartP((int)user.ShoppingcartId);  // here I get all the product id's that are in the shopping cart for that user

               
                cartproducts = cartService.GetProductsWithQuantity((int)user.ShoppingcartId);
            }
        }

        public void LoadAllItemsOfUser()
        {

            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);
                User user = accountService.GetUserById((int)userIdValue);

                List<int> productids = new List<int>(); // could also do it with objects
                productids = cartService.GetIDsFromCartP((int)user.ShoppingcartId);  // here I get all the product id's that are in the shopping cart for that user
               
                cartproducts = cartService.GetProductsWithQuantity((int)user.ShoppingcartId);
                List<int> workshopids = new List<int>();
                workshopids = cartService.GetIDsFromCartW((int)user.ShoppingcartId);  // here I get all the workshops id's that are in the shopping cart for that user
                
                cartworkshops = cartService.GetWorkshopsWithQuantity((int)user.ShoppingcartId);
            }
        }

        public void RemoveProductFromCart(int productid)
        {
            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);
                User user = accountService.GetUserById((int)userIdValue);
                Product product = itemService.GetProductById(productid);
                
                cartService.RemoveProductCart((int)user.ShoppingcartId, (int)product.ProductID);
                cartproducts.Clear();
                cartworkshops.Clear();
                LoadAllItemsOfUser();
            }
        }
        public void RemoveWorkshopFromCart(int workshopid)
        {
            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);
                User user = accountService.GetUserById((int)userIdValue);
                Workshop workshop = itemService.GetWorkshopById(workshopid);
                
                cartService.RemoveWorkshopCart((int)user.ShoppingcartId, (int)workshop.WorkshopId);
                cartproducts.Clear();
                cartworkshops.Clear();
                LoadAllItemsOfUser();
            }

        }

        public void LoadAllCouponsOfUser()
        {
            CouponList = couponService.GetAllCouponsInTime();

        }

        public decimal LoadCartTotal()
        {
            if(TempData["DisplayTotalAmount"] != null)
            {
                return Convert.ToDecimal(TempData["DisplayTotalAmount"]);
            }
            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);
                User user = accountService.GetUserById((int)userIdValue);
 
                return cartService.GetTotalOfCart((int)user.UserId);
            }
            return 0;
        }

        public User getUser()
        {
            var userIdClaim = HttpContext.User.FindFirst("UserId"); // getting the userid from the claims
            if (userIdClaim != null)
            {
                int userIdValue = Convert.ToInt32(userIdClaim.Value);
                User user = accountService.GetUserById((int)userIdValue);
                return user;
            }
            return null;
        }

      
        public decimal GetDiscountedPrice(int discountId, DiscountType discounttype )
        {
           
            
            decimal Cartamount = CalculateCartAmount();
            int Amountbusinesssupp = couponService.GetAmountSupportedBuss((int)getUser().ShoppingcartId);
            decimal TotalPriceAmountType = couponService.GetTotalPriceAmountType((int)getUser().ShoppingcartId);
            int CountType = couponService.GetHighestCountType((int)getUser().ShoppingcartId);
           
            decimal percentage = couponService.GetDiscountPercentage(discountId);
            discountInitialise = new DiscountGiver
               (discounttype);
            decimal discount = discountInitialise.ApplyDiscount(Cartamount, Amountbusinesssupp, percentage, TotalPriceAmountType, CountType);
            return discount;
        }
    }
}