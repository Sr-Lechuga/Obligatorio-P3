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
    public class RepositorioTipoMovimiento : IRepositorioTipoMovimiento
    {
        private readonly PapeleriaContext _papeleriaContext;

        public RepositorioTipoMovimiento()
        {
            _papeleriaContext = new PapeleriaContext();
        }
        #region CRUD
        public TipoMovimiento GetById(int id)
        {
            try
            {
                TipoMovimiento? tipoEncontrado = _papeleriaContext.TipoMovimientos
                    .AsNoTracking()
                    .FirstOrDefault(t => t.Id == id);
                return tipoEncontrado ?? throw new Exception($"No se encontro el tipo movimiento de ID: {id}");

            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }
        }
        public void Add(TipoMovimiento nuevoTipoMovimiento)
        {
            try
            {
                nuevoTipoMovimiento.EsValido();
                _papeleriaContext.TipoMovimientos.Add(nuevoTipoMovimiento);
                _papeleriaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }

        }

        public void Update(int id, TipoMovimiento tipoMovimientoEditado)
        {
            try
            {
                //TODO preguntarle al profe si esta bien settearlo aca
                tipoMovimientoEditado.Id = id;
                tipoMovimientoEditado.EsValido();
                _papeleriaContext.TipoMovimientos.Update(tipoMovimientoEditado);
                _papeleriaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }

        }

        public void Remove(int id)
        {
            try
            {
                TipoMovimiento tipoABorrar = GetById(id);
                _papeleriaContext.TipoMovimientos.Remove(tipoABorrar);
                _papeleriaContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }
        }
        #endregion

        #region Methods
        public IEnumerable<TipoMovimiento> GetAll()
        {
            return _papeleriaContext.TipoMovimientos.ToList();
        }

        public IEnumerable<TipoMovimiento> GetByTipoMovimiento(string tipoMovimiento)
        {
           IEnumerable<TipoMovimiento> tipoMovimientos = _papeleriaContext.TipoMovimientos
                .Where(t => t.Nombre == tipoMovimiento)
                .ToList();
           return tipoMovimientos;
        }
        


        #endregion

        #region Not needed

        public TipoMovimiento RetrieveById(int id)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
