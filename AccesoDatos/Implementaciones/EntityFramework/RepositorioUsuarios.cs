using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Generales;
using LogicaNegocio.Excepciones.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly PapeleriaContext _papeleriaContext;

        public RepositorioUsuarios(PapeleriaContext context)
        {
            //Inyeccion de dependencia
            _papeleriaContext = context;
        }

        #region CRUD Operations
        public Usuario GetById(int id)
        {
            if (!_papeleriaContext.Usuarios.Any())
                throw new DataBaseSetException("No hay usuarios resgistrados, ingrese uno primero");

            Usuario? usuarioEncontrado = _papeleriaContext.Usuarios.FirstOrDefault(usuario => usuario.Id == id);
            return usuarioEncontrado ?? throw new UsuarioNoEncontradoException($"No se pudo encontrar el usuario de ID: {id}");
        }
        
        public IEnumerable<Usuario> GetAll()
        {
            return _papeleriaContext.Usuarios.ToList();
        }

        public void Add(Usuario usuarioNuevo)
        {
            try
            {
                _papeleriaContext.Usuarios.Add(usuarioNuevo);
                _papeleriaContext.SaveChanges();
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

        public void Update(int id, Usuario usuarioEditado)
        {
            try
            {
                //TODO: Revisar
                //usuarioEditado.EsValido();
                _papeleriaContext.Usuarios.Update(usuarioEditado);
                _papeleriaContext.SaveChanges();
            }
            catch (UsuarioNoValidoException)
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
                Usuario aBorrar = GetById(id);
                _papeleriaContext.Usuarios.Remove(aBorrar);
                _papeleriaContext.SaveChanges();
            }
            catch (UsuarioNoEncontradoException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region DML Methods
        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            if (!_papeleriaContext.Usuarios.Any())
                throw new DataBaseSetException("No hay usuarios resgistrados, ingrese uno primero");

            Usuario? usuarioEncontrado = _papeleriaContext.Usuarios.FirstOrDefault(usuario => usuario.Email.DireccionEmail == email);
            return usuarioEncontrado ?? throw new UsuarioNoEncontradoException($"No se pudo encontrar el usuario de email: {email}");
        }
        #endregion
    }
}
