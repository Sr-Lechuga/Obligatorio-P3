using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.Entidades
{
    public class Usuario : IValidable<Usuario>
    {
        #region Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        //[Range(6, int.MinValue, ErrorMessage = "La contraseña debe tener minimo 6 caracteres")]
        public string Contrasenia { get; set; }
        public string ContraseniaEncriptada { get; set; }
        public ERol Rol { get; set; }
        #endregion

        #region Constructor
        public Usuario(string email, string nombre, string apellido, string password, ERol rol)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = password;
            ContraseniaEncriptada = Encriptar(password);
            Rol = rol;
        }

        public Usuario(int id, string email, string nombre, string apellido, string password, ERol rol)
        {
            Id = id;
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = password;
            ContraseniaEncriptada = Encriptar(password);
            Rol = rol;
        }
        public Usuario() { }
        #endregion

        #region Methods
        public static string Encriptar(string contrasenia)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertimos la contraseña en una secuencia de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));

                // Convertimos los bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public void ModificarUsuario(Usuario obj)
        {
            Email = obj.Email;
            Contrasenia = obj.Contrasenia;
            Rol = obj.Rol;
            Nombre = obj.Nombre;
            Apellido = obj.Apellido;
        }

        public void EsValido()
        {
            ValidarDireccionEmail();
            ValidarNombre();
            ValidarApellido();
            ValidarContrasenia();
            ValidarRol();
        }
        private void ValidarDireccionEmail()
        {
            string patronValido = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(Email))
                throw new MailNoValidoException("El email no puede ser vacio.");
            else if (!Regex.IsMatch(Email, patronValido))
                throw new MailNoValidoException("Ingrese un email valido");
        }

        public void ValidarNombre()
        {
            string patronValido = @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+(?:[' -][a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+)*$";

            if (string.IsNullOrEmpty(Nombre))
                throw new NombreNoValidoException("Nombre no puede ser vacío");
            else if (!Regex.IsMatch(Nombre, patronValido))
                throw new NombreNoValidoException("El nombre solo puede contener letras, espacios, apostrofes o guiones. Los caracteres especiales no pueden estar al principio ni al final.");
        }

        public void ValidarApellido()
        {
            string patronValido = @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+(?:[' -][a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+)*$";

            if (string.IsNullOrEmpty(Apellido))
                throw new NombreNoValidoException("Apellido no puede ser vacío");
            else if (!Regex.IsMatch(Apellido, patronValido))
                throw new NombreNoValidoException("El apellido solo puede contener letras, espacios, apostrofes o guiones. Los caracteres especiales no pueden estar al principio ni al final.");
        }

        private void ValidarContrasenia()
        {
            string patronValido = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[.,;!]).{6,}$";
            if (!Regex.IsMatch(Contrasenia, patronValido))
                throw new ContraseñaNoValidaException("La contraseña debe tener al menos largo 6. Largo mínimo de 6 caracteres, al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación (.,;!)");
        }
        private void ValidarRol()
        {
            if (Rol != ERol.ADMINISTRADOR && Rol != ERol.USUARIO && Rol != ERol.ENCARGADO)
                throw new UsuarioNoValidoException("Ingrese un rol valido");
        }
        #endregion
    }
}
