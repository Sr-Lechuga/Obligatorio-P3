using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoLogin.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoLogin.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Papeleria.Controllers
{
    public class UsuariosController : Controller
    {   
        //Casos de Uso
        private ICasoUsoLoginUsuario _loginUsuario;
        private ICasoUsoAltaUsuario _altaUsuario;
        private ICasoUsoListarUsuario _getAllUsuarios;
        private ICasoUsoEditarUsuario _modificarUsuario;
        private ICasoUsoBajaUsuario _borrarUsuario;
        private ICasoUsoBuscarUsuario _getUsuario;

        public UsuariosController(ICasoUsoLoginUsuario loginUsuario, ICasoUsoAltaUsuario altaUsuario, ICasoUsoListarUsuario getAllUsuarios, ICasoUsoEditarUsuario modificarUsuario, ICasoUsoBajaUsuario borrarUsuario, ICasoUsoBuscarUsuario getUsuario)
        {
            _loginUsuario = loginUsuario;
            _altaUsuario = altaUsuario;
            _getAllUsuarios = getAllUsuarios;
            _modificarUsuario = modificarUsuario;
            _borrarUsuario = borrarUsuario;
            _getUsuario = getUsuario;
        }



        // GET: UsuariosController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                return View(_getAllUsuarios.ListarUsuarios());
            }
            return RedirectToAction("Login");
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioAltaDTO user)
        {
            try
            {
                _altaUsuario.AltaUsuario(user);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.ErrorMessage = "Se requiere el id del usuario";
                return View();
            }
            try
            {
                UsuarioListadoDTO dto = _getUsuario.BuscarUsuario(id.GetValueOrDefault());
                UsuarioModificacionDTO mod = new UsuarioModificacionDTO()
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Password = dto.Password,
                    Rol = (LogicaNegocio.Enumerados.ERol)dto.Rol

                };

                if (dto != null)
                {
                    return View(mod);

                }
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioModificacionDTO usuarioDTO)
        {
            try
            {
                _modificarUsuario.EditarUsuario(id, usuarioDTO);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                UsuarioListadoDTO user = _getUsuario.BuscarUsuario(id);
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioListadoDTO dto)
        {
            try
            {
                _borrarUsuario.BajaUsuario(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string contraseña)
        {
            Usuario? logueado = _loginUsuario.Ejecutar(email, contraseña);
            if (logueado != null)
            {
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("rol", logueado.Rol.RolValor.ToString());
            }
            if (logueado.Rol.RolValor == ERol.ADMINISTRADOR)
                return RedirectToAction("Index", "Usuarios");
            else
                return RedirectToAction("Index", "Articulos");

        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("Login");
        }
    }
}
