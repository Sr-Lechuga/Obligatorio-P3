using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Papeleria.Controllers
{
    public class ArticulosController : Controller
    {

        //repositorios 
        private IRepositorioArticulos _repositorioArticulos = new RepositorioArticulos(new PapeleriaContext());
        //casos de uso
        private ICasoUsoAltaArticulo _altaArticulos;
        private ICasoUsoListarArticulos _getAllArticulos;

        public ArticulosController()
        {
            _altaArticulos = new CasoUsoAltaArticulo(_repositorioArticulos);
            _getAllArticulos = new CasoUsoListarArticulos(_repositorioArticulos);
        }


        // GET: ArticulosController
        public ActionResult Index()
        {
            return View(_getAllArticulos.LsitarArticulos());
        }

        // GET: ArticulosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticulosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticulosDTO art)
        {
            try
            {
                _altaArticulos.AltaArticulo(art);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticulosController/Edit/5
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

        // GET: ArticulosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticulosController/Delete/5
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
