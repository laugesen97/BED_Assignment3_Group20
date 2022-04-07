using Assignment3_Group20.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment3_Group20.Areas.Identity.Pages
{
    public class UsersModel : PageModel
    {
        public ApplicationDbContext _context { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
        = Enumerable.Empty<IdentityUser>();
        public UsersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Users = _context.Users;
        }
    }
}
