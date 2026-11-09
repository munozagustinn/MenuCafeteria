using System.Globalization;

namespace MenuCafeteria.Backend.Models
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }

        public string Etiqueta
        {
            get { return Nombre + " — " + Precio.ToString("C0", CultureInfo.GetCultureInfo("es-AR")); }
        }
    }
}
