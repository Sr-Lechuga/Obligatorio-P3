using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces
{
    public interface ICasoUsoGetMovimientos
    {
        public IEnumerable<MovimientoDeStockDTO> GetMovimientos(int articuloId, int tipoMovimientoId, int pageNumber);
    }
}
