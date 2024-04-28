using LogicaNegocio.Excepciones.Clientes;
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
    public class RUT : IValidable<RUT>
    {
        public string NroRut { get; init; }

        #region Constructors
        public RUT(string nroRut)
        {
            NroRut = nroRut;
            EsValido();
        }

        //Used for EntityFramework
        private RUT(){}
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarRut();
        }

        public void ValidarRut()
        {
            string patronValido = @"\d{12}";

            if (string.IsNullOrEmpty(NroRut) || !Regex.IsMatch(NroRut, patronValido))
                throw new ClienteNoValidoException($"El RUT ingresado {NroRut} no es valido.");
        }
        #endregion
    }
}
