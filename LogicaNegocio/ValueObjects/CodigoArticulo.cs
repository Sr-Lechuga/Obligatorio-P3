using LogicaNegocio.Excepciones.Articulos;
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
    public class CodigoArticulo : IValidable<CodigoArticulo>
    {
        #region Properties
        public string CodigoArticuloValor { get; init; }
        #endregion

        #region Constructors
        public CodigoArticulo(string codigoArticuloValor)
        {
            CodigoArticuloValor = codigoArticuloValor;
            EsValido();
        }

        //Used for EntityFramework
        private CodigoArticulo(){}
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarCodigo();
        }

        private void ValidarCodigo()
        {
            string patronValido = @"\d{13+}";

            if (!Regex.IsMatch(CodigoArticuloValor, patronValido))
                throw new ArticuloNoValidoException("El código del artículo debe tener 13 carácteres");
        }
        #endregion
    }
}
