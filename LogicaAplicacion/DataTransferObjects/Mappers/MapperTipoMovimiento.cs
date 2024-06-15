using LogicaAplicacion.DataTransferObjects.Models.TipoMovimientos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperTipoMovimiento
    {
        public static TipoMovimiento FromDTO(TipoMovimientoDTO tipoMovimientoDTO)
        {
            return new TipoMovimiento
            {
                Id = tipoMovimientoDTO.Id,
                Nombre = tipoMovimientoDTO.Nombre,
                Reduccion = tipoMovimientoDTO.Reduccion
            };
        }

        public static TipoMovimientoDTO ToDTO(TipoMovimiento tipoMovimiento)
        {
            return new TipoMovimientoDTO
            {
                Id = tipoMovimiento.Id,
                Nombre = tipoMovimiento.Nombre,
                Reduccion = tipoMovimiento.Reduccion
            };
        }

        public static IEnumerable<TipoMovimientoDTO> ToDTOList(IEnumerable<TipoMovimiento> tiposMovimiento)
        {
            return tiposMovimiento.Select(tipoMovimiento => ToDTO(tipoMovimiento));
        }
    }
}
