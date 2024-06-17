using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Implementaciones
{
    public class CasoUsoGetMovimientos : ICasoUsoGetMovimientos
    {
        public IRepositorioMovimientoDeStock RepositorioMovimientoStock { get; init; }

        public CasoUsoGetMovimientos(
            IRepositorioMovimientoDeStock repositorioMovimientoDeStock)
        {
            // Inyeccion de dependencia
            RepositorioMovimientoStock = repositorioMovimientoDeStock;
        }
        public IEnumerable<MovimientoDeStockDTO> GetMovimientos(int articuloId, int tipoMovimientoId)
        {
            //TODO: Traer las settings
            IEnumerable<MovimientoStock> movimientos = RepositorioMovimientoStock.GetMovimientos(articuloId,  tipoMovimientoId,1,20);
            return MapperMovimientoStock.ToDTOList(movimientos);
        }
    }
}
