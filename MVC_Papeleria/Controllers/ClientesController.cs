using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Papeleria.Controllers
{
    public class ClientesController : Controller
    {
        //repositorios
        private IRepositorioClientes _repositorioClientes = new RepositorioClientes(new PapeleriaContext());
        //casos de uso
        private ICasoUsoBuscarCliente _filtrarTexto;
        private ICasoUsoBuscarCliente _filtrarMonto;
        private ICasoUsoListarClientes _getAllClientes;

        public ClientesController()
        {
            _filtrarTexto = new CasoUsoBuscarCliente(_repositorioClientes);
            _filtrarMonto = new CasoUsoBuscarCliente(_repositorioClientes);
            _getAllClientes = new CasoUsoListarClientes(_repositorioClientes);

        }

        // GET: ClientesController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                return View(_getAllClientes.ListarClientes());
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Index(string textoAFiltrar, string montoAFiltrar)
        {
            IEnumerable<ClienteDTO> filtrados = null;
            if (textoAFiltrar != null && montoAFiltrar != null)
            {
                ViewBag.Error = "Solo filtrar por un campo";
                return View(_getAllClientes.ListarClientes());
            }
            if (textoAFiltrar == null && montoAFiltrar == null)
            {
                ViewBag.Error = "Solo filtrar por al menos un campo";
                return View(_getAllClientes.ListarClientes());
            }
            if (textoAFiltrar != null)
            {
                filtrados = _filtrarTexto.BuscarClientePorTexto(textoAFiltrar);
            }
            if (montoAFiltrar != null)
            {
                decimal monto = decimal.Parse(montoAFiltrar);
            }
            if (filtrados == null || filtrados.Count() == 0)
            {
                ViewBag.Message = "Lista vacia";
                return View();
            }
            return View(filtrados);

        }


        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
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
