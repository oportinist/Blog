using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Entities.Concrete
{
    public class UserLogin:IdentityUserLogin<Guid>
    {
    }
}
