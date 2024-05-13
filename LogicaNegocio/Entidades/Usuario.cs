using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Usuario 
    {
        #region Properties
        public int Id { get; set; }
        public Email Email { get; set; }
        public NombreCompleto NombreCompleto { get; set; }
        [Range(6, int.MinValue, ErrorMessage = "La contraseña debe tener minimo 6 caracteres")]
        public Contrasenia Contrasenia { get; set; }
        public ContraseniaEncriptada ContraseniaEncriptada { get; set; }
        public Rol Rol { get; set; }
        #endregion

        #region Constructor
        public Usuario(string email, string nombre, string apellido, string password, ERol rol)
        {
            Email = new Email(email);
            NombreCompleto = new NombreCompleto(nombre, apellido);
            Contrasenia = new Contrasenia(password);
            ContraseniaEncriptada = new ContraseniaEncriptada(password);
            Rol = new Rol(rol);
        }

        public Usuario(int id, string email, string nombre, string apellido, string password, ERol rol)
        {
            Id = id;
            Email = new Email(email);
            NombreCompleto = new NombreCompleto(nombre, apellido);
            Contrasenia = new Contrasenia(password);
            ContraseniaEncriptada = new ContraseniaEncriptada(password);
            Rol = new Rol(rol);
        }
        public Usuario() { }
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
