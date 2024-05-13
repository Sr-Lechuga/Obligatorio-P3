using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoLogin.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoLogin.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;

namespace MVC_Papeleria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Repositorios
            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
            builder.Services.AddScoped<IRepositorioClientes, RepositorioClientes>();
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            #endregion

            #region CasosUso
            //Usuario
            builder.Services.AddScoped<ICasoUsoLoginUsuario, CasoUsoLoginUsuario>();
            builder.Services.AddScoped<ICasoUsoAltaUsuario, CasoUsoAltaUsuario>();
            builder.Services.AddScoped<ICasoUsoListarUsuario, CasoUsoListarUsuario>();
            builder.Services.AddScoped<ICasoUsoEditarUsuario, CasoUsoEditarUsuario>();
            builder.Services.AddScoped<ICasoUsoBajaUsuario, CasoUsoBajaUsuario>();
            builder.Services.AddScoped<ICasoUsoBuscarUsuario, CasoUsoBuscarUsuario>();
            //Articulos
            builder.Services.AddScoped<ICasoUsoAltaArticulo, CasoUsoAltaArticulo>();
            builder.Services.AddScoped<ICasoUsoListarArticulos, CasoUsoListarArticulos>();
            builder.Services.AddScoped<ICasoUsoBuscarArticulo, CasoUsoBuscarArticulo>();
            //Clientes
            builder.Services.AddScoped<ICasoUsoBuscarCliente, CasoUsoBuscarCliente>();
            builder.Services.AddScoped<ICasoUsoListarClientes, CasoUsoListarClientes>();
            //Pedidos
            builder.Services.AddScoped<ICasoUsoAltaPedido, CasoUsoAltaPedido>();
            builder.Services.AddScoped<ICasoUsoListarPedido, CasoUsoListarPedido>();
            builder.Services.AddScoped<ICasoUsoEditarPedido, CasoUsoEditarPedido>();
            builder.Services.AddScoped<ICasoUsoBajaPedido, CasoUsoBajaPedido>();
            builder.Services.AddScoped<ICasoUsoBuscarPedido, CasoUsoBuscarPedido>();
            #endregion

            builder.Services.AddDistributedMemoryCache();
            //Sesion
            
            builder.Services.AddSession(options =>
            {
                //15 minutos por sesion
                options.IdleTimeout = TimeSpan.FromSeconds(900);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); //NECESARIO

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
