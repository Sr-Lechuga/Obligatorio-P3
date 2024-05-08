using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Articulo")]
    public class ArticuloController : Controller
    {
        private ICasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo _listarArticulos;

        public ArticuloController(ICasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo listarArticulos)
        {
            _listarArticulos = listarArticulos;
        }

        [HttpGet(Name = "ListarArticulos")]
        public ActionResult<IEnumerable<ArticulosListadoDTO>> Get()
        {
            //TODO: Probar esto
            return Ok(_listarArticulos.ListarArticulosOrdenadoAlfabeticamenteAscendente());
        }

    }
}
