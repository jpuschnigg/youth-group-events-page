using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouthGroup.Data
{
    public class Post
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImageName { set; get; }
        public string Time { get; set; }
    }
}
