using LogicaNegocio.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class TipoMovimiento
    {
        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        //En caso que sea reduccion positivo, es un movimiento que reduce el stock
        public bool Reduccion { get; set; }
        #endregion

        #region Constructor
        public TipoMovimiento() {}
        public TipoMovimiento(int id, string nombre, bool reduccion) 
        { 
            Nombre = nombre;
            Reduccion = reduccion;
            EsValido();
        }


        #endregion

        #region Methods
        public void EsValido()
        {
            if (Nombre.IsNullOrEmpty())
            {
                throw new Exception("El nombre no puede ser nulo o vacio");
            }
        }
        #endregion
    }
}
