﻿using LogicaAplicacion.DataTransferObjects.Models.TipoMovimientos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoTipoMovimiento.Interfaces
{
    public interface ICasoUsoListarTipoMovimiento
    {
        public IEnumerable<TipoMovimientoDTO> GetAll(); 
    }
}
