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
    public class DescripcionArticulo : IValidable<DescripcionArticulo>
    {
        #region Properties
        public string DescripcionArticuloValor { get; init; }
        #endregion

        #region Constructors
        public DescripcionArticulo(string descripcionArticulovalor)
        {
            DescripcionArticuloValor = descripcionArticulovalor;
            EsValido();
        }

        //Used for EntityFramework
        private DescripcionArticulo() { }
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarDescripcion();
        }

        private void ValidarDescripcion()
        {
            if (DescripcionArticuloValor.Length < 5)
                throw new ArticuloNoValidoException("La descripción del artículo debe contener al menso 5 caracteres");
        }
        #endregion
    }
}
