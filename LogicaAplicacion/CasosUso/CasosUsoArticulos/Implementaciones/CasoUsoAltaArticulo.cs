using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoArticulos.Implementaciones
{
    public class CasoUsoAltaArticulo(IRepositorioArticulos repositorioArticulos) : ICasoUsoAltaArticulo
    {
        public IRepositorioArticulos RepositorioArticulos { get; set; } = repositorioArticulos;

        public void AltaArticulo(ArticulosDTO articuloNuevoDTO)
        {
            if (articuloNuevoDTO == null)
            {
                throw new ArgumentNullException(nameof(articuloNuevoDTO));
            }
            Articulo srticuloNuevo = MapperArticulo.FromDTO(articuloNuevoDTO);
            RepositorioArticulos.Add(srticuloNuevo);
        }
    }
}
