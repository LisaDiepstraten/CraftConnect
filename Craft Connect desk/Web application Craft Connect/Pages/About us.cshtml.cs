using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationCraftConnect.Models;

namespace WebApplicationCraftConnect.Pages
{
    [Authorize(Roles = $"{nameof(UserTypes.customer)},{nameof(UserTypes.admin)}")]
    public class About_usModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
