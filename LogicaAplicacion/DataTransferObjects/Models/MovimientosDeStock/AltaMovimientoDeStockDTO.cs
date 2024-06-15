using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock
{
    public class AltaMovimientoDeStockDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public int TipoMovimientoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
