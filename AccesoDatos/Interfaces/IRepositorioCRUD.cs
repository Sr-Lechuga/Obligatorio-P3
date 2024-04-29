using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioCRUD<T> where T : class
    {
        void Add(T obj);
        T GetById(int id);
        T RetrieveById(int id);
        IEnumerable<T> GetAll();
        void Update(int id, T obj);
        void Remove(int id);
    }
}
