using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
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
        //TODO: Hacer linea pedidoDTO
        private static List<LineaPedidoDTO> tempLineas;

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
            return View(_listarPedidos.ListarPedidos());
        }


        // GET: PedidosController/Create
        public ActionResult Create()
        {
            if(tempLineas != null)
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
                if(tempLineas != null && tempLineas.Count > 0)
                {
                    nuevoPedido.Lineas = tempLineas;
                }
                _altaPedido.AltaPedido(nuevoPedido);
                tempLineas = null;
                return RedirectToAction(nameof(Index));
            }
            //TODO Hacer los catch
            catch
            {
                return View();
            }
        }

        public ActionResult AddLineas(int articuloId, int cantidadArticulo) 
        {
            try
            {
                //TODO Seguir
                Articulo articulo = _buscarArticulo.BuscarArticulo(articuloId);

                LineaPedidoDTO lineaPedido = new LineaPedidoDTO
                { 
                    Articulo = articulo,
                    CantidadArticulo = cantidadArticulo,
                    PrecioUnitario = articulo.PrecioVenta
                };

                if(tempLineas == null)
                {
                    tempLineas = new List<LineaPedidoDTO>();
                }

                tempLineas.Add(lineaPedido);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
