using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataAccessLibrary;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebApplicationCraftConnect.Models;


namespace WebApplicationCraftConnect.Pages
{
    [Authorize(Roles = $"{nameof(UserTypes.customer)},{nameof(UserTypes.admin)}")]
    
    public class WorkshopModel : PageModel
    {
        //private ItemRepository itemRepository = new ItemRepository();
        public Workshop oneworkshop;

        private readonly IItemRepository repoitem;
        private readonly IItemService itemservice;


        public WorkshopModel()
        {
            repoitem = new ItemRepository();
            itemservice = new ItemService(repoitem);
        }
        public void OnGet(int? id)
        {
            if (!id.HasValue)
            {
                ModelState.AddModelError("error", "id is required");
                return;
            }
            GetWorkshop(id);
        }

        public void GetWorkshop(int? id)
        {
            oneworkshop = itemservice.GetWorkshopById((int)id);
            //oneworkshop = itemRepository.GetWorkshopById((int)id);
          





        }

    }
}
