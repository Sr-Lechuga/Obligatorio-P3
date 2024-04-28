using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperArticulo
    {
        public static Articulo FromDTO(ArticulosDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            return new Articulo(dto.Nombre, dto.Descripcion, dto.Codigo, dto.PrecioVenta, dto.Stock);
        }

        public static ArticulosListadoDTO ToDTO(Articulo art)
        {
            return new ArticulosListadoDTO()
            {
                Nombre = art.Nombre,
                Descripcion = art.Descripcion,
                Codigo = art.Codigo,
                PrecioVenta = art.PrecioVenta,
                Stock = art.Stock
            };
        }

        public static IEnumerable<ArticulosListadoDTO> FromList(IEnumerable<Articulo> arts)
        {
            return arts.Select(x => ToDTO(x));
        }
    }
}
