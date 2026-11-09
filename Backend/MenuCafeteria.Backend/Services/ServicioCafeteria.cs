using System;
using System.Collections.Generic;
using System.Linq;
using MenuCafeteria.Backend.Models;
using MenuCafeteria.Backend.Persistence;

namespace MenuCafeteria.Backend.Services
{
    public class ServicioCafeteria
    {
        private readonly IRepositorioPedidos repositorio;
        private readonly List<Producto> bebidas;
        private readonly List<Producto> acompanamientos;
        private readonly List<ItemPedido> carrito;

        public ServicioCafeteria(IRepositorioPedidos repositorio)
        {
            this.repositorio = repositorio;
            carrito = new List<ItemPedido>();
            bebidas = new List<Producto>
            {
                CrearProducto("cafe", "Café", "Bebida", 3000m),
                CrearProducto("cafe-leche", "Café con leche", "Bebida", 3000m),
                CrearProducto("licuado", "Licuado", "Bebida", 4000m),
                CrearProducto("jugo-naranja", "Jugo de naranja", "Bebida", 2600m),
                CrearProducto("yogurt-granola", "Yogurt con granola", "Bebida", 4200m),
                CrearProducto("gaseosa", "Gaseosa", "Bebida", 2500m),
                CrearProducto("agua-mineral", "Agua mineral", "Bebida", 1500m)
            };
            acompanamientos = new List<Producto>
            {
                CrearProducto("medialuna", "Medialuna", "Acompañamiento", 1200m),
                CrearProducto("mafalda", "Mafalda", "Acompañamiento", 1600m),
                CrearProducto("criollo", "Criollo (unidad)", "Acompañamiento", 500m),
                CrearProducto("tostado-jyq", "Tostado de jamón y queso", "Acompañamiento", 4000m),
                CrearProducto("porcion-torta", "Porción de torta", "Acompañamiento", 4200m)
            };
        }

        private static Producto CrearProducto(string id, string nombre, string categoria, decimal precio)
        {
            return new Producto { Id = id, Nombre = nombre, Categoria = categoria, Precio = precio };
        }

        public IList<Producto> ObtenerBebidas()
        {
            return bebidas.ToList();
        }

        public IList<Producto> ObtenerAcompanamientos()
        {
            return acompanamientos.ToList();
        }

        public IList<ItemPedido> ObtenerCarrito()
        {
            return carrito.ToList();
        }

        public void AgregarAlCarrito(string bebidaId, string acompanamientoId)
        {
            Producto bebida = bebidas.FirstOrDefault(producto => producto.Id == bebidaId);
            Producto acompanamiento = acompanamientos.FirstOrDefault(producto => producto.Id == acompanamientoId);

            if (bebida == null && acompanamiento == null)
                throw new ArgumentException("Elegí una bebida, un acompañamiento o ambos.");

            List<Producto> seleccion = new List<Producto>();
            if (bebida != null)
                seleccion.Add(bebida);
            if (acompanamiento != null)
                seleccion.Add(acompanamiento);

            carrito.Add(new ItemPedido
            {
                Id = Guid.NewGuid(),
                Descripcion = string.Join(" + ", seleccion.Select(producto => producto.Nombre)),
                Importe = seleccion.Sum(producto => producto.Precio)
            });
        }

        public void EliminarDelCarrito(Guid itemId)
        {
            ItemPedido item = carrito.FirstOrDefault(actual => actual.Id == itemId);
            if (item == null)
                throw new InvalidOperationException("El producto seleccionado ya no está en el carrito.");

            carrito.Remove(item);
        }

        public decimal CalcularTotalCarrito()
        {
            return carrito.Sum(item => item.Importe);
        }

        public Pedido RegistrarPedido()
        {
            if (carrito.Count == 0)
                throw new InvalidOperationException("El carrito está vacío. Agregá productos antes de finalizar.");

            Pedido pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                Fecha = DateTime.Now,
                Items = carrito.Select(item => new ItemPedido
                {
                    Id = item.Id,
                    Descripcion = item.Descripcion,
                    Importe = item.Importe
                }).ToList(),
                Total = CalcularTotalCarrito()
            };

            IList<Pedido> pedidos = repositorio.ObtenerTodos();
            pedidos.Add(pedido);
            repositorio.GuardarTodos(pedidos);
            carrito.Clear();
            return pedido;
        }

        public IList<Pedido> ObtenerHistorial()
        {
            return repositorio.ObtenerTodos()
                .OrderByDescending(pedido => pedido.Fecha)
                .ToList();
        }
    }
}
