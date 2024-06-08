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
        public TipoMovimiento() { }

        public static void EsValido()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods

        #endregion
    }
}
