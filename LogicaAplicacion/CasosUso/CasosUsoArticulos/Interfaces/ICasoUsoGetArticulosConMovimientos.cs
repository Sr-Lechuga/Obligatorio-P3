﻿using LogicaAplicacion.DataTransferObjects.Models.Articulos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoArticulos.Interfaces
{
    public interface ICasoUsoGetArticulosConMovimientos
    {
        public IEnumerable<ArticulosListadoDTO> GetArticulosConMovimientos(DateTime fecha1, DateTime fecha2, int pageNumber);
    }
}
