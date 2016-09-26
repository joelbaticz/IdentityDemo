using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectX.Services
{
    public interface IRoleRepository:IRepository<IdentityRole>
    {
    }
}
