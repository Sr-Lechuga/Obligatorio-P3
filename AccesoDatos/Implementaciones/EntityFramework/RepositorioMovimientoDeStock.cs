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

        //TODO probar consulta a.
        public IEnumerable<MovimientoStock> GetMovimientos(int articuloId, int tipoMovimientoId)
        {
            return _papeleriaContext.MovimientoStock.Where(m => m.Articulo.Id == articuloId
                                                    && m.TipoMovimiento.Id == tipoMovimientoId)
                                                    .OrderByDescending(m => m.Fecha)
                                                    .ThenBy(m => m.Cantidad)
                                                    .Select(m => new MovimientoStock
                                                    {
                                                        Fecha = m.Fecha,
                                                        Cantidad = m.Cantidad,
                                                        Articulo = new Articulo
                                                        {
                                                            Nombre= m.Articulo.Nombre,
                                                            Descripcion = m.Articulo.Descripcion,
                                                            Codigo = m.Articulo.Codigo
                                                        },
                                                        TipoMovimiento = new TipoMovimiento
                                                        {
                                                            Nombre = m.TipoMovimiento.Nombre
                                                        }

                                                    })
                                                    .ToList();
        }

        public IEnumerable<MovimientoStock> GetResumenMovimientos()
        {
            IEnumerable<MovimientoStock> lista = _papeleriaContext.MovimientoStock
                                                .GroupBy(m => m.Fecha.Year)
                                                .Select(group => new MovimientoStock
                                                {
                                                    Id = group.Key
                                                })
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
