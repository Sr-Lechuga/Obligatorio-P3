using LogicaNegocio.Excepciones.Articulos;
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
    public class NombreArticulo : IValidable<NombreArticulo>
    {
        #region Properties
        public string NombreArticuloValor { get; init; }
        #endregion

        #region Constructors
        public NombreArticulo(string nombreArticulo)
        {
            NombreArticuloValor = nombreArticulo;
            EsValido();
        }

        //Used for EntityFramework
        private NombreArticulo(){}
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarNombre();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(NombreArticuloValor))
                throw new ArticuloNoValidoException("Debe ingresar un nombre para el articulo");
            else if (NombreArticuloValor.Length < 10 || NombreArticuloValor.Length > 200)
                throw new ArticuloNoValidoException("El nombre del artículo debetener entre 10 y 200 carácteres");
        }
        #endregion
    }
}