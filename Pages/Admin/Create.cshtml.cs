using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using YouthGroup.Data;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using YouthGroup.Pages.Admin;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

//Author: Jack Puschnigg


namespace YouthGroup.Pages.Admin
{
    //Allows only Admins to view 'create posts' page
    [Authorize(Roles = "ADMIN")]
    public class CreateModel : PageModel
    {

        //Declare variables needed to store post data
        public static string ImageName { set; get; }

        public static bool ToDelete { get; set; }

        public static int postCounter { get; set; }

        [BindProperty]
        public IFormFile Image { set; get; }

        [BindProperty]
        public Post Post { get; set; }


        private static YouthGroup.Data.ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public CreateModel(YouthGroup.Data.ApplicationDbContext context, IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
            _context = context;
        }

        public IActionResult OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Stays on same page if posts are deleted
            if (ToDelete.Equals(true) && IndexModel.Posts.Count == 1)
            {
                return RedirectToPage("./Create");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Verifies the image file is valid
            if (Image != null)
            {
                var fileName = GetUniqueName(Image.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, fileName);
                Image.CopyTo(new FileStream(filePath, FileMode.Create));
                ImageName = fileName; // Set the file name
                Post.ImageName = ImageName;
            }

            //Used to count the current number of posted images
            //Prevents flex card stretching
            postCounter++;

            //Instantiate the time
            Post.Time = DateTime.Now.ToString();

            //Deletes posts if necessary
            if (ToDelete.Equals(true))
            {
                for (int i = 0; i < IndexModel.Posts.Count(); i++)
                {
                    _context.Posts.Remove(IndexModel.Posts[i]);
                }

                ToDelete = false;
            }

            await _context.Posts.AddAsync(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        //Creates image file path/URL
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

        //Deletes the posts from the database when the 'delete posts' button is clicked
        public async Task<IActionResult> OnPostDelete()
        {
            ToDelete = true;

            if (ToDelete.Equals(true) && IndexModel.Posts.Count == 1)
            {
                ToDelete = false;
                return RedirectToPage("./Create");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                var fileName = GetUniqueName(Image.FileName);
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, fileName);
                Image.CopyTo(new FileStream(filePath, FileMode.Create));
                ImageName = fileName; // Set the file name
                Post.ImageName = ImageName;
                Post.Time = DateTime.Now.ToString();
            }

            if (ToDelete.Equals(true))
            {
                for (int i = 0; i < IndexModel.Posts.Count(); i++)
                {
                    _context.Posts.Remove(IndexModel.Posts[i]);
                }

                postCounter = 0;

                ToDelete = false;
            }

            await _context.Posts.AddAsync(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
