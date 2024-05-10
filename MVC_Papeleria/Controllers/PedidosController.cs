using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Papeleria.Controllers
{
    public class PedidosController : Controller
    {
        //Casos de uso
        private ICasoUsoAltaPedido _altaPedido;
        private ICasoUsoBajaPedido _bajaPedido
        private ICasoUsoListarPedido _listarPedidos;
        private ICasoUsoListarClientes _listarClientes;
        private ICasoUsoListarArticulos _listarArticulos;

        public PedidosController(ICasoUsoAltaPedido altaPedido, 
            ICasoUsoBajaPedido bajaPedido, 
            ICasoUsoListarPedido listarPedidos,
            ICasoUsoListarClientes listarClientes, 
            ICasoUsoListarArticulos listarArticulos)
        {
            _altaPedido = altaPedido;
            _bajaPedido = bajaPedido;
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

            return View();
        }

        // POST: PedidosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO nuevoPedido)
        {
            try
            {
                _altaPedido.AltaPedido(nuevoPedido);
                return RedirectToAction(nameof(Index));
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
