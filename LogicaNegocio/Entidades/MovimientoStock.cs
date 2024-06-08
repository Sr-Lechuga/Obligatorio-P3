using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class MovimientoStock
    {
        #region Properties
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public Usuario Usuario { get; set; }
        #endregion

        #region Constructores
        public MovimientoStock() {}
        #endregion

        #region Methods

        #endregion
    }
}
