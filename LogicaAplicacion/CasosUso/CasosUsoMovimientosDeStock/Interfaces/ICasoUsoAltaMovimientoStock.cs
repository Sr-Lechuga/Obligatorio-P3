using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using LogicaAplicacion.DataTransferObjects.Models.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces
{
    public interface ICasoUsoAltaMovimientoStock
    {
        public void AltaMovimientoStock(MovimientoDeStockDTO movimientosDeStockDTO);
    }
}
