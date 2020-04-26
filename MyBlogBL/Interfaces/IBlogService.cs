using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogBL.Interfaces
{
    public interface IBlogService<T> where T : class
    {
        void Create(T item);
        void Update(T item);
        IEnumerable<T> GetAll();
        void Delete(int id);
        T GetById(int id);
    }
}
