using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;

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
            //builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
            //builder.Services.AddScoped<IRepositorioClientes, RepositorioClientes>();
            //builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
            //builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            #endregion

            //Sesion
            builder.Services.AddDistributedMemoryCache();
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
