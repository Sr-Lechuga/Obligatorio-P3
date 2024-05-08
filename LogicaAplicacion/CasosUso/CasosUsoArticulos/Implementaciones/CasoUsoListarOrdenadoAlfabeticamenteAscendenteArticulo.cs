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
    public class CasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo : ICasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo
    {
        public IRepositorioArticulos _repositorioArticulos;

        public CasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo(IRepositorioArticulos repositorioArticulos)
        {
            _repositorioArticulos = repositorioArticulos;
        }

        public IEnumerable<ArticulosListadoDTO> ListarArticulosOrdenadoAlfabeticamenteAscendente()
        {
            return MapperArticulo.FromList(_repositorioArticulos.ListadoAscendente());
        }
    }
}
