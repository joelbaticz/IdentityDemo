using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProjectX.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectX.Services
{
    public class MyDBContext: IdentityDbContext<ProjectXUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=ProjectXDB; Trusted_Connection=True;");
        }


    }
}
