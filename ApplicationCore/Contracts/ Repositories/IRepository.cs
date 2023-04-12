using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts. Repositories
{
    public interface IRepository<T> where T : class
    {
         int Insert(T obj);
        int Update(T obj);
        int DeleteById(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}