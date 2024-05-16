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
        private PapeleriaContext _papeleriaContext;

        public RepositorioUsuarios()
        {
            //Inyeccion de dependencia
            _papeleriaContext = new PapeleriaContext();
        }

        #region CRUD Operations
        public Usuario GetById(int id)
        {
            Usuario? usuarioEncontrado = _papeleriaContext.Usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.Id == id);

            return usuarioEncontrado ?? throw new UsuarioNoEncontradoException($"No se pudo encontrar el usuario de ID: {id}");
        }

        public Usuario RetrieveById(int id)
        {

            Usuario? usuarioEncontrado = _papeleriaContext.Usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.Id == id);
            
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
            Usuario? usuarioEncontrado = _papeleriaContext.Usuarios.FirstOrDefault(usuario => usuario.Email.DireccionEmail == email);
            return usuarioEncontrado ?? throw new UsuarioNoEncontradoException("Credenciales incorrectas. Revise el mail y/o la contraseña");
        }
        #endregion
    }
}
