using AccesoDatos.Interfaces;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Generales;
using LogicaNegocio.Excepciones.Pedidos;
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
                /*_papeleriaContext.Pedidos.Add(pedidoNuevo);
                _papeleriaContext.SaveChanges();*/
            }
            catch (PedidoNoValidoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }
        }

        public Pedido GetById(int id)
        {
            /*try
            {
                Pedido? pedidoEncontrado = _papeleriaContext.Pedidos.AsNoTracking().FirstOrDefault(pedido => pedido.Id == id);
                return pedidoEncontrado ?? throw new PedidoNoEncontradoException($"No se encontro el pedido de ID: {id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }*/
            return null;
        }

        public Pedido RetrieveById(int id)
        {
            /*try
            {
                Pedido? pedidoEncontrado = _papeleriaContext.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
                return pedidoEncontrado ?? throw new PedidoNoEncontradoException($"No se encontro el pedido de ID: {id}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            }*/
            return null;
        }

        public IEnumerable<Pedido> GetAll()
        {
            /*
            return _papeleriaContext.Pedidos.ToList();*/
            return null;
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
            /*try
            {
                _papeleriaContext.Pedidos.Remove(pedidoEncontrado);
                _papeleriaContext.SaveChanges();
            }
            catch (PedidoNoEncontradoException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error desconocido: {ex.Message} (Trace: {ex.StackTrace})");
            */
        }
        #endregion
    }
}
