using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using MenuCafeteria.Backend.Models;

namespace MenuCafeteria.Backend.Persistence
{
    public class RepositorioPedidosJson : IRepositorioPedidos
    {
        private readonly string rutaArchivo;

        public RepositorioPedidosJson(string rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
        }

        public IList<Pedido> ObtenerTodos()
        {
            if (!File.Exists(rutaArchivo))
                return new List<Pedido>();

            using (FileStream stream = File.OpenRead(rutaArchivo))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Pedido>));
                return (List<Pedido>)serializer.ReadObject(stream);
            }
        }

        public void GuardarTodos(IList<Pedido> pedidos)
        {
            string directorio = Path.GetDirectoryName(rutaArchivo);
            if (!string.IsNullOrEmpty(directorio))
                Directory.CreateDirectory(directorio);

            string archivoTemporal = rutaArchivo + ".tmp";
            using (FileStream stream = File.Create(archivoTemporal))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Pedido>));
                serializer.WriteObject(stream, new List<Pedido>(pedidos));
            }

            if (File.Exists(rutaArchivo))
                File.Replace(archivoTemporal, rutaArchivo, null);
            else
                File.Move(archivoTemporal, rutaArchivo);
        }
    }
}
