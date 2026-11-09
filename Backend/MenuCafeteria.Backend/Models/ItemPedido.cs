using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace MenuCafeteria.Backend.Models
{
    [DataContract]
    public class ItemPedido
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal Importe { get; set; }

        public string Etiqueta
        {
            get { return Descripcion + " — " + Importe.ToString("C0", CultureInfo.GetCultureInfo("es-AR")); }
        }
    }
}
