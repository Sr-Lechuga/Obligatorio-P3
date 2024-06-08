using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock
{
    public class MovimientosDeStockDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public TipoMovimientoDTO TipoMovimiento { get; set; }
        public Usuario Usuario { get; set; }
    }
}
