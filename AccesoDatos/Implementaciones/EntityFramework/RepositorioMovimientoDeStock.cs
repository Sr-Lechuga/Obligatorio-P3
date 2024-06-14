using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class RepositorioMovimientoDeStock : IRepositorioMovimientoDeStock
    {
        private readonly PapeleriaContext _papeleriaContext;

        public RepositorioMovimientoDeStock()
        {
            _papeleriaContext = new PapeleriaContext();
        }
        public void Add(MovimientoStock nuevoMovimientoStock)
        {
            try
            {
                nuevoMovimientoStock.EsValido();
                _papeleriaContext.MovimientoStock.Add(nuevoMovimientoStock);
                _papeleriaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }
        }

        public IEnumerable<MovimientoStock> GetAll()
        {
            return _papeleriaContext.MovimientoStock.ToList();
        }

        #region Not Needed
        public MovimientoStock GetById(int id)
        {
            return _papeleriaContext.MovimientoStock.Find(id);
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
