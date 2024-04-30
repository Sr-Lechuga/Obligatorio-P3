using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [ComplexType]
    public class Rol : IValidable<Rol>
    {
        #region Properties
        public ERol RolValor {  get; init; }
        #endregion

        #region Constructor
        public Rol(ERol rol)
        {
            RolValor = rol;
            EsValido();
        }

        public Rol() { }
        #endregion


        public void EsValido()
        {
            ValidarRol();
        }

        private void ValidarRol()
        {
            if (RolValor != ERol.ADMINISTRADOR || RolValor != ERol.USUARIO)
                throw new UsuarioNoValidoException("Ingrese un rol valido");
        }
    }
}
