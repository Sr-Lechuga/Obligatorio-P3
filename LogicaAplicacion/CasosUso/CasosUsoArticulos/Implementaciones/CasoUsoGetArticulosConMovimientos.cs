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
        private IRepositorioArticulos RepositorioArticulos { get; init; }
        private IRepositorioSettings RepositorioSettings { get; init; }

        public CasoUsoGetArticulosConMovimientos(
            IRepositorioArticulos repositorioArticulos, 
            IRepositorioSettings repositorioSettings)
        {
            RepositorioArticulos = repositorioArticulos;
            RepositorioSettings = repositorioSettings;
        }
        
        public IEnumerable<ArticulosListadoDTO> GetArticulosConMovimientos(DateTime fecha1, DateTime fecha2, int pageNumber)
        {
            int size = int.Parse(RepositorioSettings.GetValueByName("PageSize") + "");
            return RepositorioArticulos.GetArticulosConMovimientos(fecha1, fecha2, pageNumber, size)
                                        .Select(a => MapperArticulo.ToDTO(a));
        }
    }
}
