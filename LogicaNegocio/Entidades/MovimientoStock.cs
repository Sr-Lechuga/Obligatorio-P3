﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class MovimientoStock
    {
        #region Properties
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public Usuario Usuario { get; set; }
        #endregion

        //TODO aplicar setting en el tope
        public static int _tope = 20;

        #region Constructores
        public MovimientoStock() {}

        public MovimientoStock(DateTime fecha, Articulo articulo, int cantidad, 
            TipoMovimiento tipoMovimiento, Usuario user) 
        {
            Fecha = fecha;
            Articulo = articulo;
            Cantidad = cantidad;
            TipoMovimiento = tipoMovimiento;
            Usuario = user;
            EsValido();
        }


        #endregion

        #region Methods
        public void EsValido()
        {
            if (Fecha > DateTime.Now)
            {
                throw new Exception("La fecha debe ser el dia de hoy o anterior");
            }
            if (Cantidad < 0)
            {
                throw new Exception("La cantidad no puede ser negativo");
            }
            if (Cantidad > _tope) 
            {
                throw new Exception("La cantidad no puede superar el tope");
            }
            
        }
        #endregion
    }
}
