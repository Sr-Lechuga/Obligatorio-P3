using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class RepositorioTipoMovimiento : IRepositorioTipoMovimiento
    {
        private readonly PapeleriaContext _papeleriaContext;

        public RepositorioTipoMovimiento()
        {
            _papeleriaContext = new PapeleriaContext();
        }

        public IEnumerable<TipoMovimiento> GetAll()
        {
            return _papeleriaContext.TipoMovimientos.ToList();
        }

        public IEnumerable<TipoMovimiento> GetByTipoMovimiento(string tipoMovimiento)
        {
            throw new NotImplementedException();
        }

        public void Add(TipoMovimiento obj)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, TipoMovimiento obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        #region Not needed
        public TipoMovimiento GetById(int id)
        {
            throw new NotImplementedException();
        }
        public TipoMovimiento RetrieveById(int id)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
