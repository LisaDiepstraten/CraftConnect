using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationCraftConnect.Models;

namespace WebApplicationCraftConnect.Pages
{
    [Authorize(Roles = $"{nameof(UserTypes.customer)},{nameof(UserTypes.admin)}")]
    public class ProductModel : PageModel
    {
        private readonly IItemRepository repoitem;
        private readonly IItemService itemservice;

        public ProductModel()
        {
            repoitem = new ItemRepository();
            itemservice = new ItemService(repoitem);
        }


        //private ItemRepository itemRepository = new ItemRepository();
        public Product oneproduct;

        public void OnGet(int? id)
        {
            if (!id.HasValue)
            {
                ModelState.AddModelError("error", "id is required");
                return;
            }
            GetProduct(id);
        }
        public void GetProduct(int? id)
        {
            oneproduct = itemservice.GetProductById((int)id);
            //oneproduct = itemRepository.GetProductByIdP((int)id);
        }
    }
}
