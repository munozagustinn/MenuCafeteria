using System;
using System.IO;
using System.Windows.Forms;
using MenuCafeteria.Backend.Persistence;
using MenuCafeteria.Backend.Services;

namespace MenuCafeteria.WinForms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string carpetaDatos = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MenuCafeteria");
            string archivoDatos = Path.Combine(carpetaDatos, "pedidos.json");

            try
            {
                ServicioCafeteria servicio = new ServicioCafeteria(new RepositorioPedidosJson(archivoDatos));
                Application.Run(new MenuForm(servicio));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo iniciar la aplicación.\n\n" + ex.Message,
                    "Menú Cafetería",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
