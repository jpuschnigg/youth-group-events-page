using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YouthGroup.Data;

namespace YouthGroup.Pages.UserRoles
{
    [Authorize(Roles = "ADMIN")]
    public class IndexModel : PageModel
    {
        private readonly YouthGroup.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        //By injecting the userManager (add editing the services) you can see which roles belong to a user
        public IndexModel(YouthGroup.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<IdentityUser> UserList { get; set; }

        public async Task OnGetAsync()
        {
            UserList = await _context.Users.ToListAsync();
        }

        public async Task<string> GetRoles(IdentityUser user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            return string.Join(",", roles); ;
        }
    }
}