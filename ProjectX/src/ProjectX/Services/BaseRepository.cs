using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace ProjectX.Services
{
    public class BaseRepository<T>: IRepository<T> where T : class
    {
        private MyDBContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository()
        {
            _context = new MyDBContext();
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
    }
}
