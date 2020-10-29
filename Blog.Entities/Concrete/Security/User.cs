using Blog.Shared.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Blog.Entities.Concrete
{
    public class User : IdentityUser<Guid>
    { 
        //public ICollection<Article> Articles { get; set; }
        public string Picture { get; set; } 
    }
}