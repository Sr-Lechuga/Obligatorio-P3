using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using Azure;
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
                _papeleriaContext.Entry(nuevoMovimientoStock.Articulo).State = EntityState.Unchanged;
                _papeleriaContext.Entry(nuevoMovimientoStock.Usuario).State = EntityState.Unchanged;
                _papeleriaContext.Entry(nuevoMovimientoStock.TipoMovimiento).State = EntityState.Unchanged;
                _papeleriaContext.MovimientoStock.Add(nuevoMovimientoStock);
                _papeleriaContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MovimientoStock> GetAll()
        {
            return _papeleriaContext.MovimientoStock.ToList();
        }

        ///Consulta A con paginación
        public IEnumerable<MovimientoStock> GetMovimientos(int articuloId, int tipoMovimientoId, int pageNumber, int pageSize)
        {
            IEnumerable<MovimientoStock> lista = _papeleriaContext.MovimientoStock
                                   .Include(m => m.Articulo)
                                   .Include(m => m.Usuario)
                                   .Include(m => m.TipoMovimiento)
                                   .Where(m => m.Articulo.Id == articuloId && m.TipoMovimiento.Id == tipoMovimientoId)
                                   .OrderByDescending(m => m.Fecha)
                                   .ThenBy(m => m.Cantidad)
                                   .Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();
            return lista;

        }

        public IEnumerable<Object> GetResumenMovimientos()
        {
            var lista = _papeleriaContext.MovimientoStock
                                                .GroupBy(m => m.Fecha.Year)
                                                .Select(group => new
                                                {
                                                    Anio = group.Key,
                                                    TipoMovimiento = group.GroupBy(tm => tm.TipoMovimiento)
                                                    .Select(tm => new
                                                    {
                                                        NombreTipo = tm.Key,
                                                        Cantidad = tm.Sum(movimiento => movimiento.Cantidad)
                                                    }),
                                                    TotalAnio = group.Sum(m => m.Cantidad)
                                                })
                                                .OrderBy(group => group.Anio)
                                                .ToList();


            return lista;
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
