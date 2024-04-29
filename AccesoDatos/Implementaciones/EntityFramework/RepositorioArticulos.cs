using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Articulos;
using LogicaNegocio.Excepciones.Generales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class RepositorioArticulos : IRepositorioArticulos
    {
        private readonly PapeleriaContext _papeleriaContext;

        public RepositorioArticulos(PapeleriaContext context)
        {
            _papeleriaContext = context;
        }

        #region CRUD Operations
        public void Add(Articulo articuloNuevo)
        {
            try
            {
                articuloNuevo.EsValido();
                _papeleriaContext.Articulos.Add(articuloNuevo);
                _papeleriaContext.SaveChanges();
            }
            catch (ArticuloNoEncontradoException)
            {
                throw;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public Articulo GetById(int id)
        {
            if (!_papeleriaContext.Articulos.Any())
                throw new DataBaseSetException("La tabla Articulos esta vacia");

            try
            {
                Articulo? articuloEncontrado = _papeleriaContext.Articulos.AsNoTracking().FirstOrDefault(articulo => articulo.Id == id);
                return articuloEncontrado ?? throw new ArticuloNoEncontradoException($"No se encontro el articulo de Id: {id}");
            }
            catch (ArticuloNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public Articulo RetrieveById(int id)
        {
            if (!_papeleriaContext.Articulos.Any())
                throw new DataBaseSetException("La tabla Articulos esta vacia");

            try
            {
                Articulo? articuloEncontrado = _papeleriaContext.Articulos.FirstOrDefault(articulo => articulo.Id == id);
                return articuloEncontrado ?? throw new ArticuloNoEncontradoException($"No se encontro el articulo de Id: {id}");
            }
            catch (ArticuloNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public IEnumerable<Articulo> GetAll()
        {
            return _papeleriaContext.Articulos.ToList();
        }

        public void Update(int id, Articulo articuloEditado)
        {
            try
            {
                //TODO: Revisar
                //articuloEditado.EsValido();
                _papeleriaContext.Articulos.Update(articuloEditado);
                _papeleriaContext.SaveChanges();
            }
            catch (ArticuloNoValidoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public void Remove(int id)
        {
            try
            {
                //TODO: Revisar la implementacion con Find, no es necesaria
                Articulo articuloParaBorrar = this.GetById(id);
                _papeleriaContext.Articulos.Remove(articuloParaBorrar);
                _papeleriaContext.SaveChanges();
            }
            catch (ArticuloNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }
        #endregion
    }
}
