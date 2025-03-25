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
    public class SignupModel : PageModel
    {        
        [BindProperty]
        public SignupDTO SignupDTO { get; set; }
        private readonly IAccountRepository repo;
        private readonly IAccountService accountService;

        public SignupModel()
        {

            repo = new AccountRepository();
            accountService = new AccountService(repo);
        }
      
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Homepage"); // Redirect to the home page or any other page
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            
            if (ModelState.IsValid)
            {
                if (SignupDTO.Password == SignupDTO.Password2)
                {
                    //SignupDTO.HashPassword(SignupDTO.Password);
                    User user = new User(
                        null,
                        SignupDTO.Username,
                        SignupDTO.Firstname,
                        SignupDTO.Lastname,
                        SignupDTO.PhoneNumber,
                        SignupDTO.Address,
                        SignupDTO.Email,
                        SignupDTO.Password,
                        0,
                        0
                    );
                    bool userAdded = accountService.AddUser(user);
                    //bool userAdded = accountRepository.AddUser(user);

                    if (userAdded)
                    {
                        return RedirectToPage("/Login");
                    }
                    else
                    {
                        // Handle user not added (possibly due to some error)
                        return Page(); // Return the same page with errors
                    }
                }
                else
                {
                    TempData["NotSuccessFullSignUp"] = "Passwords do not match. Please check your credentials.";

                }
            }

            if (!ModelState.IsValid)
            {
                // ModelState is not valid, inspect errors
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Log or handle the error as needed
                    Console.WriteLine("Error: " + error.ErrorMessage);
                }
            }


            // If ModelState is not valid, return the same page with errors
            return Page();
        }
   
    }
}
