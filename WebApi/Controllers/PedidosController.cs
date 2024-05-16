using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("api/Pedidos")]
    public class PedidosController : ControllerBase
    {
        private ICasoUsoListarOrdenadoDescendentementePorFechaPedido _listarPedidos;

        public PedidosController(ICasoUsoListarOrdenadoDescendentementePorFechaPedido listarPedidos)
        {
            _listarPedidos = listarPedidos;
        }

        [HttpGet(Name = "ListarPedidos")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PedidoDTO>> Get()
        {
            try
            {
                var pedidos = _listarPedidos.ListarPedidoOrdenadoDescendentementePorFecha();
                if (!pedidos.Any())
                {
                    return NotFound();
                }
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }





    }
}
