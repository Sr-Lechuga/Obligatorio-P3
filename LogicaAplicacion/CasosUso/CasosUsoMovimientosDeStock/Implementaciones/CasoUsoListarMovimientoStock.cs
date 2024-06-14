using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Implementaciones
{
    public class CasoUsoListarMovimientoStock : ICasoUsoListarMovimientoStock
    {
        public IRepositorioMovimientoDeStock RepositorioMovimientoDeStock { get; set; }

        public CasoUsoListarMovimientoStock(IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            RepositorioMovimientoDeStock = repositorioMovimientoDeStock;
        }

        public IEnumerable<MovimientoDeStockDTO> ListarMovimientosDeStock()
        {
            return MapperMovimientoStock.ToDTOList(RepositorioMovimientoDeStock.GetAll());
        }
    }
}
