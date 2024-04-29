using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IValidable<Usuario>
    {
        #region Properties
        public int Id { get; set; }
        public Email Email { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        public Contrasenia Contrasenia { get; set; }
        public ContraseniaEncriptada ContraseniaEncriptada { get; set; }
        public Rol Rol { get; set; }
        #endregion

        #region Constructor
        public Usuario(string email, string nombre, string apellido, string password, Rol rol)
        {
            Email = new Email(email);
            NombreCompleto = new NombreCompleto(nombre, apellido);
            Contrasenia = new Contrasenia(password);
            ContraseniaEncriptada = new ContraseniaEncriptada(password);
            Rol = rol;
        }

        public Usuario(int id, string email, string nombre, string apellido, string password, Rol rol)
        {
            Id = id;
            Email = new Email(email);
            NombreCompleto = new NombreCompleto(nombre, apellido);
            Contrasenia = new Contrasenia(password);
            ContraseniaEncriptada = new ContraseniaEncriptada(password);
            Rol = rol;
            EsValido();
        }
        public Usuario() { }
        #endregion

        #region Validations
        public void EsValido()
        {
            //TODO: Esto no va aca
            if (Rol != Rol.ADMINISTRADOR) throw new RolNoValidoException("Rol inexistente");

        }
        #endregion

        #region Methods
        public void ModificarUsuario(Usuario obj)
        {
            Email = obj.Email;
            Contrasenia = obj.Contrasenia;
            Rol = obj.Rol;
            NombreCompleto = obj.NombreCompleto;
        }
        #endregion
    }
}
