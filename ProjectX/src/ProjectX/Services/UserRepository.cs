using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProjectX.Models;

namespace ProjectX.Services
{
    public class UserRepository: BaseRepository<ProjectXUser>, IUserRepository
    {
    }
}
