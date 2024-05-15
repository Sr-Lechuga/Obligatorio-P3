﻿using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.Clientes;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public abstract class Pedido : IValidable<Pedido>
    {
        #region Properties
        //TODO: Pasar esto a archivo de configuracion
        public static double s_IVA = 22;

        public int Id {  get; set; }

        [Display(Name = "Fecha prometida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPrometida { get; set; }

        [Display(Name = "Fecha creado")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreado { get; set; }

        public Cliente Cliente { get; set; }

        public decimal Total { get; set; }
        [Display(Name = "IVA aplicado")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double IVAAplicado { get; set; }

        public List<LineaPedido> Lineas { get; set; }
        [Display(Name = "Fecha de entrega")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregado { get; set; }

        public EEstado Estado { get; set; }

        #endregion

        protected Pedido(DateTime fechaPrometida, Cliente cliente)
        {
            FechaPrometida = fechaPrometida;
            FechaCreado = DateTime.Now;
            Cliente = cliente;
            Total = 0;
            IVAAplicado = s_IVA;
            Lineas = [];
            FechaEntregado = null;
            Estado = EEstado.NUEVO;
            EsValido();
        }
        public Pedido() 
        {

        }

        #region Methods definitions
        public abstract double CalcularTotal();
        

        #endregion
        public void EsValido()
        {
            ValidarCliente();
        }

        public void ValidarCliente() 
        {
            if(Cliente == null ) throw new ClienteNoValidoException("Cliente no valido");
            
        }
    }
}
