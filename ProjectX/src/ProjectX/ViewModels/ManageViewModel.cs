using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProjectX.Models;

namespace ProjectX.ViewModels
{
    public class ManageViewModel
    {

        public IEnumerable<ProjectXUser> Users { get; set; }

        public string Role { get; set; }

    }
}
