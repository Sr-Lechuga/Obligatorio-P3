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
    public class CasoUsoListarArticulos : ICasoUsoListarArticulos
    {
        public IRepositorioArticulos RepositorioArticulos { get; set; }

        public CasoUsoListarArticulos(IRepositorioArticulos repositorioArticulos)
        {
            RepositorioArticulos = repositorioArticulos;
        }

        public IEnumerable<ArticulosListadoDTO> LsitarArticulos()
        {
            return MapperArticulo.FromList(RepositorioArticulos.GetAll());
        }
    }
}
