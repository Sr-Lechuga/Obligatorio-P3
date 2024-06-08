using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            #region Repositorios
            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimiento>();
            builder.Services.AddScoped<IRepositorioMovimientoDeStock, RepositorioMovimientoDeStock>();
            #endregion

            #region Casos de uso
            //Articulos
            builder.Services.AddScoped<ICasoUsoListarArticulos, CasoUsoListarArticulos>();
            builder.Services.AddScoped<ICasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo, CasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo>();
            builder.Services.AddScoped<ICasoUsoListarOrdenadoDescendentementePorFechaPedido, CasoUsoListarOrdenadoDescendentementePorFechaPedido>();
            //Tipo Movimiento
            builder.Services.AddScoped<ICasoUsoAltaTipoMovimiento, CasoUsoAltaTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoBajaTipoMovimiento, CasoUsoBajaTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoEditTipoMovimiento, CasoUsoEditTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoListarTipoMovimiento, CasoUsoListarTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoObtenerPorTipoMovimiento, CasoUsoObtenerPorTipoMovimiento>();
            //Movimientos de stock
            builder.Services.AddScoped<ICasoUsoAltaMovimientoStock, CasoUsoAltaMovimientoStock>();
            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
