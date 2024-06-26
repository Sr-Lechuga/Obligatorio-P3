﻿using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.MovimientosDeStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoMovimientosDeStock.Implementaciones
{
    public class CasoUsoGetResumenMovimientos : ICasoUsoGetResumenMovimientos
    {
        public IRepositorioMovimientoDeStock RepositorioMovimientoStock { get; init; }

        public CasoUsoGetResumenMovimientos(
            IRepositorioMovimientoDeStock repositorioMovimientoDeStock
        )

        {
            // Inyeccion de dependencia
            RepositorioMovimientoStock = repositorioMovimientoDeStock;
        }

        public IEnumerable<Object> GetResumenMovimientos()
        {
            return RepositorioMovimientoStock.GetResumenMovimientos();
        }
    }
}
