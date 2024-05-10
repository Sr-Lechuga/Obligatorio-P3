﻿using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using LogicaNegocio.Excepciones.Generales;
using LogicaNegocio.Excepciones.Pedidos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class RepositorioPedidos : IRepositorioPedidos
    {
        private readonly PapeleriaContext _papeleriaContext;

        public RepositorioPedidos()
        {
            _papeleriaContext = new PapeleriaContext();
        }

        #region CRUD Operations
        public void Add(Pedido pedidoNuevo)
        {
            try
            {
                _papeleriaContext.Pedidos.Add(pedidoNuevo);
                _papeleriaContext.SaveChanges();
            }
            catch (PedidoNoValidoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }
        }

        public Pedido GetById(int id)
        {
            try
            {
                Pedido? pedidoEncontrado = _papeleriaContext.Pedidos.AsNoTracking().FirstOrDefault(pedido => pedido.Id == id);
                return pedidoEncontrado ?? throw new PedidoNoEncontradoException($"No se encontro el pedido de ID: {id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }
        }

        public Pedido RetrieveById(int id)
        {
            try
            {
                Pedido? pedidoEncontrado = _papeleriaContext.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
                return pedidoEncontrado ?? throw new PedidoNoEncontradoException($"No se encontro el pedido de ID: {id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _papeleriaContext.Pedidos.ToList();
        }

        public void Update(int id, Pedido pedidoEditado)
        {
            /*try
            {
                _papeleriaContext.Pedidos.Update(pedidoEditado);
                _papeleriaContext.SaveChanges();
            }
            catch (PedidoNoValidoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }*/
            
        }

        public void Remove(int id)
        {
            Pedido? pedidoEncontrado = GetById(id);
            
            try
            {
                //Debe hacer una baja logica en lugar de una fisica
                pedidoEncontrado.Estado = EEstado.ANULADO;
                _papeleriaContext.Pedidos.Update(pedidoEncontrado);
                _papeleriaContext.SaveChanges();
            }
            catch (PedidoNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message}");
            }
            
        }
        #endregion
    }
}
