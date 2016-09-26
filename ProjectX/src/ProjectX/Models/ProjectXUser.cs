using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectX.Models
{
    public class ProjectXUser : IdentityUser
    {
        public string ExtraProp { get; set; }


    }
}
