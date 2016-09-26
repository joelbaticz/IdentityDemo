using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectX.ViewModels
{
    public class AddToRoleViewModel
    {
        public int id { get; set; }
        public IEnumerable<IdentityRole> roles { get; set; }

    }
}
