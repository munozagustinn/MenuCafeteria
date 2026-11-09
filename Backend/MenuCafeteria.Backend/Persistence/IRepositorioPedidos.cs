using System.Collections.Generic;
using MenuCafeteria.Backend.Models;

namespace MenuCafeteria.Backend.Persistence
{
    public interface IRepositorioPedidos
    {
        IList<Pedido> ObtenerTodos();
        void GuardarTodos(IList<Pedido> pedidos);
    }
}
