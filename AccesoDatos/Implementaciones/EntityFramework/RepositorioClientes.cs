﻿using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Clientes;
using LogicaNegocio.Excepciones.Generales;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly PapeleriaContext _papeleriaContext;

        public RepositorioClientes(PapeleriaContext context)
        {
            _papeleriaContext = context;
        }

        public void Add(Cliente clienteNuevo)
        {
            try
            {
                //TODO: Revisar validacion
                //clienteNuevo.EsValido();
                _papeleriaContext.Clientes.Add(clienteNuevo);
                _papeleriaContext.SaveChanges();
            }
            catch (ClienteNoValidoException)
            {
                throw;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public Cliente GetById(int id)
        {
            if (!_papeleriaContext.Clientes.Any())
                throw new DataBaseSetException("No hay clientes para mostrar, ingrese uno primero");

            try
            {
                Cliente? clienteEncontrado = _papeleriaContext.Clientes.FirstOrDefault(cliente => cliente.Id == id);
                return clienteEncontrado ?? throw new ClienteNoEncontradoException($"No se encontro el cliente de ID: {id}");
            }
            catch (ClienteNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            if (!_papeleriaContext.Clientes.Any())
                throw new DataBaseSetException("No hay clientes para mostrar, ingrese uno primero");

            return _papeleriaContext.Clientes.ToList();
        }

        public void Update(int id, Cliente clienteEditado)
        {
            try
            {
                //TODO: Revisar metodo de validacion
                //clienteEditado.EsValido();
                _papeleriaContext.Clientes.Update(clienteEditado);
                _papeleriaContext.SaveChanges();
            }
            catch (ClienteNoValidoException)
            {
                throw;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public void Remove(int id)
        {
            try
            {
                //TODO: No recomendado
                Cliente clienteParaBorrar = GetById(id);
                _papeleriaContext.Clientes.Remove(clienteParaBorrar);
                _papeleriaContext.SaveChanges(true);
            }
            catch (ClienteNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        #region DML Methods

        public IEnumerable<Cliente> GetByText(string texto)
        {
            if (!_papeleriaContext.Clientes.Any())
                throw new DataBaseSetException("No hay clientes para mostrar, ingrese uno primero");

            IEnumerable<Cliente> clientes = _papeleriaContext.Clientes
                .Where(cli => cli.NombreCompleto.Nombre.Contains(texto) || cli.NombreCompleto.Apellido.Contains(texto))
                .ToList();

            return clientes.Any() ? clientes : throw new ClienteNoEncontradoException($"No se pudo encontrar ningun cliente que contenga {texto} en su nombre o apellido");
        }

        public Cliente BuscarClientePorRut(string rut)
        {
            if (!_papeleriaContext.Clientes.Any())
                throw new DataBaseSetException("No hay clientes para mostrar, ingrese uno primero");

            try
            {
                Cliente? clienteEncontrado = _papeleriaContext.Clientes.FirstOrDefault(cliente => cliente.RUT.NroRut == rut);
                return clienteEncontrado ?? throw new ClienteNoEncontradoException($"No se pudo encontrar al cliente de RUT {rut}");
            }
            catch (ClienteNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }

        }

        public IEnumerable<Cliente> GetByMonto(decimal monto)
        {
            IEnumerable<Cliente> clientes = _papeleriaContext.Pedidos.Include(pedido => pedido.Cliente)
                .Where(pedido => pedido.Total > monto)
                .Select(pedido => pedido.Cliente)
                .ToList();

            return clientes.Any() ? clientes : throw new ClienteNoEncontradoException($"No se pudo encontrar ningun cliente que con un total de pedidos superior a ${monto}");
        }
        #endregion
    }
}