using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperMovimientoStock
    {
        public static MovimientoStock FromDTO(MovimientoDeStockDTO movimientosDeStockDTO)
        {
            return new MovimientoStock
            {
                Id = movimientosDeStockDTO.Id,
                Articulo = movimientosDeStockDTO.Articulo,
                Cantidad = movimientosDeStockDTO.Cantidad,
                Fecha = movimientosDeStockDTO.Fecha,
                TipoMovimiento = MapperTipoMovimiento.FromDTO(movimientosDeStockDTO.TipoMovimiento),
                Usuario = movimientosDeStockDTO.Usuario
            };
        }

        public static MovimientoDeStockDTO ToDTO(MovimientoStock movimientoStock)
        {
            return new MovimientoDeStockDTO
            {
                Id = movimientoStock.Id,
                Articulo = movimientoStock.Articulo,
                Cantidad = movimientoStock.Cantidad,
                Fecha = movimientoStock.Fecha,
                TipoMovimiento = MapperTipoMovimiento.ToDTO(movimientoStock.TipoMovimiento),
                Usuario = movimientoStock.Usuario
            };
        }

        public static IEnumerable<MovimientoDeStockDTO> ToDTOList(IEnumerable<MovimientoStock> movimientosDeStockDTOs)
        {
            return movimientosDeStockDTOs.Select(movimientosDeStockDTO => ToDTO(movimientosDeStockDTO));
        }
    }
}
