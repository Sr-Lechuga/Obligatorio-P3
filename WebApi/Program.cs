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
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Implementaciones;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

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
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioArticulos, RepositorioArticulos>();
            builder.Services.AddScoped<IRepositorioPedidos, RepositorioPedidos>();
            builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimiento>();
            builder.Services.AddScoped<IRepositorioMovimientoDeStock, RepositorioMovimientoDeStock>();
            builder.Services.AddScoped<IRepositorioSettings, RepositorioSettings>();
            #endregion

            #region Casos de uso
            //Usuarios
            builder.Services.AddScoped<ICasoUsoGetUsuarioByEmail, CasoUsoGetUsuarioByEmail>();
            builder.Services.AddScoped<ICasoUsoBuscarUsuario, CasoUsoBuscarUsuario>();
            //Articulos
            builder.Services.AddScoped<ICasoUsoListarArticulos, CasoUsoListarArticulos>();
            builder.Services.AddScoped<ICasoUsoBuscarArticulo, CasoUsoBuscarArticulo>();
            builder.Services.AddScoped<ICasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo, CasoUsoListarOrdenadoAlfabeticamenteAscendenteArticulo>();
            builder.Services.AddScoped<ICasoUsoListarOrdenadoDescendentementePorFechaPedido, CasoUsoListarOrdenadoDescendentementePorFechaPedido>();
            builder.Services.AddScoped<ICasoUsoGetArticulosConMovimientos, CasoUsoGetArticulosConMovimientos>();
            //Tipo Movimiento
            builder.Services.AddScoped<ICasoUsoAltaTipoMovimiento, CasoUsoAltaTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoBajaTipoMovimiento, CasoUsoBajaTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoEditTipoMovimiento, CasoUsoEditTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoListarTipoMovimiento, CasoUsoListarTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoBuscarTipoMovimiento, CasoUsoBuscarTipoMovimiento>();
            builder.Services.AddScoped<ICasoUsoObtenerPorTipoMovimiento, CasoUsoObtenerPorTipoMovimiento>();
            //Movimientos de stock
            builder.Services.AddScoped<ICasoUsoListarMovimientoStock, CasoUsoListarMovimientoStock>();
            builder.Services.AddScoped<ICasoUsoAltaMovimientoStock, CasoUsoAltaMovimientoStock>();
            builder.Services.AddScoped<ICasoUsoGetResumenMovimientos, CasoUsoGetResumenMovimientos>();
            builder.Services.AddScoped<ICasoUsoTipoMovimientoEnUso, CasoUsoTipoMovimientoEnUso>();
            //Reportes
            builder.Services.AddScoped<ICasoUsoGetMovimientos, CasoUsoGetMovimientos>();

            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var clave = "CharliXCX!NewAlbum-BRAT-isOUTNOW!STREAM!!!";
            builder.Services.AddAuthentication(
                aut =>
                {
                    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(opciones =>
                {
                    opciones.RequireHttpsMetadata = false;
                    opciones.SaveToken = true;
                    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(clave)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                }
            );
            var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApi.xml");
            builder.Services.AddSwaggerGen(
    opciones =>
    {
        opciones.IncludeXmlComments(rutaArchivo);
        opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
        {
            Description = "Autorización estándar mediante esquema Bearer",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        opciones.OperationFilter<SecurityRequirementsOperationFilter>();
        opciones.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Papeleria",
            Description = "Proyecto Obligatorio 2 N3D",
            Version = "v1"
        });
    }
);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
