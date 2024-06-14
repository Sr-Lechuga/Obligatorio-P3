using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Papeleria.Controllers
{
    public class PedidosController : Controller
    {
        //Casos de uso
        private ICasoUsoAltaPedido _altaPedido;
        private ICasoUsoBajaPedido _bajaPedido;
        private ICasoUsoBuscarArticulo _buscarArticulo;
        private ICasoUsoBuscarCliente _buscarCliente;
        private ICasoUsoBuscarPedido _buscarPedido;
        private ICasoUsoListarPedido _listarPedidos;
        private ICasoUsoListarClientes _listarClientes;
        private ICasoUsoListarArticulos _listarArticulos;

        private static List<LineaPedidoDTO>? tempLineas;

        public PedidosController(ICasoUsoAltaPedido altaPedido,
            ICasoUsoBajaPedido bajaPedido,
            ICasoUsoBuscarArticulo buscarArticulo,
            ICasoUsoBuscarCliente buscarCliente,
            ICasoUsoBuscarPedido buscarPedido,
            ICasoUsoListarPedido listarPedidos,
            ICasoUsoListarClientes listarClientes,
            ICasoUsoListarArticulos listarArticulos)
        {
            _altaPedido = altaPedido;
            _bajaPedido = bajaPedido;
            _buscarArticulo = buscarArticulo;
            _buscarCliente = buscarCliente;
            _buscarPedido = buscarPedido;
            _listarPedidos = listarPedidos;
            _listarClientes = listarClientes;
            _listarArticulos = listarArticulos;
        }


        // GET: PedidosController
        public ActionResult Index()
        {
            return View(MapperPedido.ToListAll(_listarPedidos.ListarPedidos()));
        }


        // GET: PedidosController/AddLines
        public ActionResult AddLines()
        {
            try
            {
                IEnumerable<ArticulosListadoDTO> articulos = _listarArticulos.ListarArticulos();
                ViewBag.Articulos = articulos;

                if (tempLineas != null)
                    ViewBag.LineasAgregadas = tempLineas;

                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }

        }

        // POST: PedidosController/AddLines
        [HttpPost]
        public ActionResult AddLines(int articuloId, int cantidadArticulo)
        {
            try
            {
                Articulo articulo = _buscarArticulo.BuscarArticulo(articuloId);

                LineaPedidoDTO lineaPedido = new LineaPedidoDTO
                {
                    Articulo = articulo,
                    CantidadArticulo = cantidadArticulo,
                    PrecioUnitario = articulo.PrecioVenta
                };

                if (tempLineas == null)
                    tempLineas = new List<LineaPedidoDTO>();

                tempLineas.Add(lineaPedido);

                return RedirectToAction(nameof(AddLines));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: PedidosController/BorrarLineas
        public ActionResult BorrarLineas()
        {
            if (tempLineas != null)
            {
                tempLineas = null;
                ViewBag.LineasAgregadas = null;
            }

            return RedirectToAction(nameof(AddLines));
        }

        // GET: PedidosController/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = _listarClientes.ListarClientes();

            if (tempLineas != null)
                ViewBag.Lineas = tempLineas;

            PedidoDTO pedidoDTO = new PedidoDTO();
            pedidoDTO.Lineas = tempLineas;
            pedidoDTO.FechaCreado = DateTime.Now.Date;
            pedidoDTO.FechaPrometida = DateTime.Now.AddDays(5).Date;
            pedidoDTO.FechaEntregado = DateTime.Now.Date;
            pedidoDTO.IVAAplicado = 22;
            pedidoDTO.Estado = EEstado.NUEVO;
            pedidoDTO.Total = MapperPedido.FromDTO(pedidoDTO).CalcularCostoBase();

            return View(pedidoDTO);
        }

        // POST: PedidosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO nuevoPedido)
        {
            try
            {
                if (tempLineas != null && tempLineas.Count > 0)
                    nuevoPedido.Lineas = tempLineas;
                nuevoPedido.Id = nuevoPedido.Id;
                nuevoPedido.FechaCreado = DateTime.Now;
                nuevoPedido.FechaPrometida = DateTime.Now.AddDays(5);
                nuevoPedido.IVAAplicado = 22;
                nuevoPedido.Estado = EEstado.NUEVO;
                nuevoPedido.Total = nuevoPedido.Total;
                //nuevoPedido.Cliente = new Cliente { Id = nuevoPedido.ClienteId };
                nuevoPedido.Cliente = _buscarCliente.BuscarClientePorId(nuevoPedido.ClienteId);

                _altaPedido.AltaPedido(nuevoPedido);

                tempLineas = null;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }

        public ActionResult AnularPedido(int id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Se requiere el id para el pedido";
                return View();
            }
            try
            {
                PedidoDTO pedidoDTO = _buscarPedido.BuscarPedido(id);
                
                if(pedidoDTO != null)
                    return View(pedidoDTO);
                else
                    return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnularPedido(int id, PedidoDTO pedidoDTO)
        {
            try
            {
                _bajaPedido.BajaPedido(pedidoDTO.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

    }
}
