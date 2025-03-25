using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationCraftConnect.Models;

namespace WebApplicationCraftConnect.Pages
{
    [Authorize(Roles = nameof(UserTypes.customer))]
    public class CustomerModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
