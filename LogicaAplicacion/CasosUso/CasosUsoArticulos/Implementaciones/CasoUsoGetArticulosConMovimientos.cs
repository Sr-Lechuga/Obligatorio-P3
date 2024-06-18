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
        private IRepositorioArticulos _repositorioArticulos { get; set; }
        private IRepositorioSettings _settings { get; set; }

        public CasoUsoGetArticulosConMovimientos(
            IRepositorioArticulos repositorioArticulos, 
            IRepositorioSettings repositorioSettings)
        {
            _repositorioArticulos = repositorioArticulos;
            _settings = repositorioSettings;
        }
        
        public IEnumerable<ArticulosListadoDTO> GetArticulosConMovimientos(DateTime fecha1, DateTime fecha2, int pageNumber)
        {
            int size = int.Parse(_settings.GetValueByName("PageSize") + "");
            return _repositorioArticulos.GetArticulosConMovimientos(fecha1, fecha2, pageNumber, size)
                                        .Select(a => MapperArticulo.ToDTO(a));
        }
    }
}
