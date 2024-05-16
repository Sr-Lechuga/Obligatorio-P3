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
        private ICasoUsoListarPedido _listarPedidos;
        private ICasoUsoListarClientes _listarClientes;
        private ICasoUsoListarArticulos _listarArticulos;

        private static List<LineaPedidoDTO>? tempLineas;

        public PedidosController(ICasoUsoAltaPedido altaPedido,
            ICasoUsoBajaPedido bajaPedido,
            ICasoUsoBuscarArticulo buscarArticulo,
            ICasoUsoListarPedido listarPedidos,
            ICasoUsoListarClientes listarClientes,
            ICasoUsoListarArticulos listarArticulos)
        {
            _altaPedido = altaPedido;
            _bajaPedido = bajaPedido;
            _buscarArticulo = buscarArticulo;
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

        // GET: PedidosController/Create
        public ActionResult Create()
        {
            ViewBag.Clientes = _listarClientes.ListarClientes();

            if (tempLineas != null)
            {
                ViewBag.Lineas = tempLineas;
            }
            return View();
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

                nuevoPedido.FechaCreado = DateTime.Now;
                //TODO: Agregar el parametro de settings
                nuevoPedido.FechaPrometida = DateTime.Now.AddDays(5);
                //TODO: Agregar el parametro de settings
                nuevoPedido.IVAAplicado = 22;
                nuevoPedido.Estado = EEstado.NUEVO;
                nuevoPedido.Total = 12.3M;

                _altaPedido.AltaPedido(nuevoPedido);

                tempLineas = null;
                return RedirectToAction(nameof(Index));
            }
            //TODO Hacer los catch
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }

        public ActionResult AddLineas(int articuloId, int cantidadArticulo)
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
                return RedirectToAction(nameof(Create));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.StackTrace + ex.Message;
                return View();
            }
        }

        public ActionResult AnularPedido(int id)
        {
            //Hacer la logica de anularPedido
            return View();
        }

        public ActionResult BorrarLineas()
        {
            if (tempLineas != null)
            {
                tempLineas = null;
                ViewBag.LineasAgregadas = tempLineas;
            }

            return RedirectToAction(nameof(AddLines));
        }
    }
}
