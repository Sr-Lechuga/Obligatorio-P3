using LogicaNegocio.Excepciones.Clientes;
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
    public class Direccion : IValidable<Direccion>
    {
        #region Properties
        public string Calle { get; init; }
        public int Numero { get; init; }
        public string Ciudad { get; init; }
        public int Distancia { get; init; }
        #endregion

        #region Constructors
        public Direccion(string calle, int numero, string ciudad, int distancia)
        {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
            Distancia = distancia;
            EsValido();
        }

        //Used for EntityFramework
        private Direccion() { }
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarDistancia();
            ValidarCiudad();
            ValidarCalle();
            ValidarNumero();
        }

        private void ValidarDistancia()
        {
            if (Distancia == 0)
                throw new ClienteNoValidoException("La distancia debe ser mayor a 0");
        }

        private void ValidarCiudad()
        {
            if (string.IsNullOrEmpty(Ciudad))
                throw new ClienteNoValidoException("Debe ingresar una ciudad");
        }
        private void ValidarCalle()
        {
            if (string.IsNullOrEmpty(Calle))
                throw new ClienteNoValidoException("Debe ingresar una calle");
        }

        private void ValidarNumero()
        {
            if (Numero <= 0)
                throw new ClienteNoValidoException("Debe ingresar un numero de puerta valido");
        }

        #endregion
    }
}
