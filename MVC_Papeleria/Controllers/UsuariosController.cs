using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Papeleria.Controllers
{
    public class UsuariosController : Controller
    {   //repositorios
        private IRepositorioUsuarios _repositorioUsuarios = new RepositorioUsuarios(new PapeleriaContext());
        //casos de uso
        private ILoginUsuario _loginUsuario;
        private IAltaUsuario _altaUsuario;
        private IGetAllUsuarios _getAllUsuarios;
        private IModificarUsuario _modificarUsuario;
        private IBorrarUsuario _borrarUsuario;
        private IGetUsuario _getUsuario;


        public UsuariosController()
        {
            _loginUsuario = new LoginUsuario(_repositorioUsuarios);
            _altaUsuario = new AltaUsuario(_repositorioUsuarios);
            _getAllUsuarios = new GetAllUsuarios(_repositorioUsuarios);
            _modificarUsuario = new ModificarUsuario(_repositorioUsuarios);
            _borrarUsuario = new BorrarUsuario(_repositorioUsuarios);
            _getUsuario = new GetUsuario(_repositorioUsuarios);
        }



        // GET: UsuariosController
        public ActionResult Index()
        {
            return View(_getAllUsuarios.Ejecutar());
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
        public ActionResult Create(AltaUsuarioDTO user)
        {
            try
            {
                _altaUsuario.Ejecutar(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Error = "Se requiere el id del usuario";
                return View();
            }
            try
            {
                UsuarioListadoDTO dto = _getUsuario.GetById(id.GetValueOrDefault());
                UsuarioModificacionDTO mod = new UsuarioModificacionDTO()
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    Email = dto.Email,
                    Password = dto.Password,
                    Rol = dto.Rol

                };

                if (dto != null)
                {
                    return View(mod);

                }
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioModificacionDTO usuarioDto)
        {
            try
            {
                _modificarUsuario.Ejecutar(id, usuarioDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                UsuarioListadoDTO user = _getUsuario.GetById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
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
                _borrarUsuario.borrarUsuario(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
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


            }
            return RedirectToAction("Index", "Usuarios");

        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("Login");
        }
    }
}
