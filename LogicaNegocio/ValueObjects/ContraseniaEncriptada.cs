using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [ComplexType]
    public class ContraseniaEncriptada : IValidable<ContraseniaEncriptada>
    {
        #region Properties
        public string ValorContrasenia { get; init; }
        #endregion

        #region Constructors
        public ContraseniaEncriptada(string contrasenia)
        {
            ValorContrasenia = contrasenia;
            EsValido();
            ValorContrasenia = Encriptar(contrasenia);
        }

        //Used for EntityFramework
        private ContraseniaEncriptada() { }
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarContrasenia();
        }

        private void ValidarContrasenia()
        {
            string patronValido = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[.,;!]).{6,}$";
            
            if (!Regex.IsMatch(ValorContrasenia, patronValido))
                throw new ContraseñaNoValidaException("La contraseña debe tener al menos largo 6. Largo mínimo de 6 caracteres, al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación (.,;!)");
        }
        #endregion
        
        private string Encriptar(string contrasenia)
        {
            //TODO: Metodo de encriptacion
            return contrasenia;
        }

    }
}
