using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones
{
    public class RepositorioMovimientoDeStock : IRepositorioMovimientoDeStock
    {
        public void Add(MovimientoStock obj)
        {
            throw new NotImplementedException();
        }

        #region Not Needed
        public IEnumerable<MovimientoStock> GetAll()
        {
            throw new NotImplementedException();
        }

        public MovimientoStock GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public MovimientoStock RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, MovimientoStock obj)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
