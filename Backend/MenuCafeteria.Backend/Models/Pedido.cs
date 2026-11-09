using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace MenuCafeteria.Backend.Models
{
    [DataContract]
    public class Pedido
    {
        public Pedido()
        {
            Items = new List<ItemPedido>();
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public List<ItemPedido> Items { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        public string Resumen
        {
            get { return string.Join(", ", Items.Select(item => item.Descripcion)); }
        }

        public string TotalFormateado
        {
            get { return Total.ToString("C0", CultureInfo.GetCultureInfo("es-AR")); }
        }
    }
}
