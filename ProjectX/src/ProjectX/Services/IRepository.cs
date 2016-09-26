using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Services
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
