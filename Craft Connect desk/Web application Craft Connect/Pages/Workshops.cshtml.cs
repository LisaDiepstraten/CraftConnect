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
    public class WorkshopsModel : PageModel
    {
        //ItemRepository itemRepository = new ItemRepository();

        public List<Workshop> workshops;
        private readonly IItemRepository repoitem;
        private readonly IItemService itemservice;


        public WorkshopsModel()
        {
            repoitem = new ItemRepository();
            itemservice = new ItemService(repoitem);
        }
        public void OnGet()
        {
            GetWorkshop();
        }

        

        public void GetWorkshop()
        {
           workshops = itemservice.GetAllWorkshops();
           //workshops = itemRepository.GetAllWorkshops();

        }
    }
}
