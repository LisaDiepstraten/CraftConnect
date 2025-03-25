using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationCraftConnect.Models;

namespace WebApplicationCraftConnect.Pages
{
    [Authorize(Roles = nameof(UserTypes.admin))]
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
