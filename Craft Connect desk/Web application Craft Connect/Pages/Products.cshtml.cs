using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebApplicationCraftConnect.Models;

namespace WebApplicationCraftConnect.Pages
{
    [Authorize(Roles = $"{nameof(UserTypes.customer)},{nameof(UserTypes.admin)}")]
    public class ProductsModel : PageModel
    {
        private readonly IItemRepository repoitem;
        private readonly IItemService itemservice;

        public ProductsModel()
        {
            repoitem = new ItemRepository();
            itemservice = new ItemService(repoitem);
        }

        //ItemRepository itemRepository = new ItemRepository();
        public List<Product> products;

        public void OnGet(int pageNumber = 1)
        {
            Index(pageNumber);
            //GetProducts();
        }

        public List<Product> Products { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public void Index(int pageNumber = 1)
        {
            

            int itemsPerPage = 25;
            Products = itemservice.GetProductsByPagination(pageNumber);

            int totalItems = itemservice.GetAllProducts().Count;
            TotalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);

            CurrentPage = pageNumber;
        }


        public void GetProducts()
        {
            //products = itemservice.GetAllProducts();
            //products = itemRepository.GetAllProducts();
            

        }

    }
}
