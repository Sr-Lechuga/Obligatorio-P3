using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Papeleria.Controllers
{
    public class ClientesController : Controller
    {
        //repositorios
        private IRepositorioClientes _repositorioClientes = new RepositorioClientes(new PapeleriaContext());
        //casos de uso
        private IFiltrarTexto _filtrarTexto;
        private IFiltrarMonto _filtrarMonto;
        private IGetAllClientes _getAllClientes;

        public ClientesController()
        {
            _filtrarTexto = new FiltrarTexto(_repositorioClientes);
            _filtrarMonto = new FiltrarMonto(_repositorioClientes);
            _getAllClientes = new GetAllClientes(_repositorioClientes);

        }

        // GET: ClientesController
        public ActionResult Index()
        {
            return View(_getAllClientes.Ejecutar());
        }


        [HttpPost]
        public ActionResult Index(string textoAFiltrar, string montoAFiltrar)
        {
            IEnumerable<ClienteDTO> filtrados = null;
            if (textoAFiltrar != null && montoAFiltrar != null)
            {
                ViewBag.Error = "Solo filtrar por un campo";
                return View(_getAllClientes.Ejecutar());
            }
            if (textoAFiltrar == null && montoAFiltrar == null)
            {
                ViewBag.Error = "Solo filtrar por al menos un campo";
                return View(_getAllClientes.Ejecutar());
            }
            if (textoAFiltrar != null)
            {
                filtrados = _filtrarTexto.Ejecutar(textoAFiltrar);
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
