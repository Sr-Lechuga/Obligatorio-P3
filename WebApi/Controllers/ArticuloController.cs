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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ArticulosListadoDTO>> Get()
        {
           try 
           {
                var articulos = _listarArticulos.ListarArticulosOrdenadoAlfabeticamenteAscendente();
                if(!articulos.Any())
                {
                    return NotFound();
                }
                return Ok(articulos);
           }
           catch (Exception ex) 
           {
                return StatusCode(500, ex.Message);
           }
           
        }
       
    }
}
