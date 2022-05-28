using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using YouthGroup.Data;

//Author: Jack Puschnigg

namespace YouthGroup.Pages.Admin
{
    //Allows only Admins and apporved users to view posts
    [Authorize(Roles = "ADMIN, USER")]
    public class IndexModel : PageModel
    {
        private readonly YouthGroup.Data.ApplicationDbContext _context;

        public IndexModel(YouthGroup.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public static List<Post> Posts { get; set; }

        public async Task OnGetAsync()
        {
            Posts = (from Posts in _context.Posts.Take(10)
                              select Posts).ToList();
        }
    }
}
