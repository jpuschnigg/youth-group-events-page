using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Author: Jack Puschnigg

namespace YouthGroup.Pages.Calendar
{
    //Allows only Admins and Users to view the calendar page
    [Authorize(Roles = "ADMIN, USER")]
    public class EventsModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
