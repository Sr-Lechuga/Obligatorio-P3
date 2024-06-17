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
    public class CasoUsoGetArticulosConMovimientos : ICasoUsoGetArticulosConMovimientos
    {
        public IRepositorioArticulos RepositorioArticulos { get; set; }

        public CasoUsoGetArticulosConMovimientos(IRepositorioArticulos repositorioArticulos)
        {
            RepositorioArticulos = repositorioArticulos;
        }
        public IEnumerable<ArticulosListadoDTO> GetArticulosConMovimientos(DateTime fecha1, DateTime fecha2)
        {
            IEnumerable<Articulo> articulos = RepositorioArticulos.GetArticulosConMovimientos(fecha1, fecha2);
            return MapperArticulo.FromList(articulos);
        }
    }
}
