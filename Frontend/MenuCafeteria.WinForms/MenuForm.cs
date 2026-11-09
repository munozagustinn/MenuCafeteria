using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MenuCafeteria.Backend.Models;
using MenuCafeteria.Backend.Services;

namespace MenuCafeteria.WinForms
{
    public class MenuForm : Form
    {
        private readonly ServicioCafeteria servicio;
        private readonly ComboBox comboBebida;
        private readonly ComboBox comboAcompanamiento;
        private readonly ListBox listaCarrito;
        private readonly Label etiquetaTotal;

        public MenuForm(ServicioCafeteria servicio)
        {
            this.servicio = servicio;
            Text = "Menú Cafetería";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(800, 600);
            Size = new Size(980, 700);
            BackColor = Color.FromArgb(246, 248, 251);
            Font = new Font("Segoe UI", 9F);

            Label titulo = new Label
            {
                Text = "Cafetería",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(49, 43, 37),
                AutoSize = true,
                Location = new Point(24, 18)
            };
            Label subtitulo = new Label
            {
                Text = "Elegí una bebida y algo rico para acompañar.",
                ForeColor = Color.FromArgb(110, 103, 97),
                AutoSize = true,
                Location = new Point(28, 61)
            };
            Controls.Add(titulo);
            Controls.Add(subtitulo);

            Panel seleccion = new Panel
            {
                Location = new Point(24, 98),
                Size = new Size(916, 112),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.White
            };
            Controls.Add(seleccion);

            seleccion.Controls.Add(CrearEtiqueta("Bebida", 18, 12));
            comboBebida = CrearCombo(18, 38, 255);
            comboBebida.DataSource = servicio.ObtenerBebidas().ToList();
            comboBebida.DisplayMember = "Etiqueta";
            comboBebida.ValueMember = "Id";
            comboBebida.SelectedIndex = -1;
            seleccion.Controls.Add(comboBebida);

            seleccion.Controls.Add(CrearEtiqueta("Acompañamiento", 294, 12));
            comboAcompanamiento = CrearCombo(294, 38, 290);
            comboAcompanamiento.DataSource = servicio.ObtenerAcompanamientos().ToList();
            comboAcompanamiento.DisplayMember = "Etiqueta";
            comboAcompanamiento.ValueMember = "Id";
            comboAcompanamiento.SelectedIndex = -1;
            seleccion.Controls.Add(comboAcompanamiento);

            Button agregar = CrearBoton("Agregar al carrito", Color.FromArgb(47, 112, 77), 608, 36, 176);
            agregar.Click += AgregarAlCarrito;
            seleccion.Controls.Add(agregar);

            Button limpiar = CrearBoton("Limpiar selección", Color.FromArgb(105, 111, 119), 796, 36, 104);
            limpiar.Click += delegate
            {
                comboBebida.SelectedIndex = -1;
                comboAcompanamiento.SelectedIndex = -1;
            };
            seleccion.Controls.Add(limpiar);

            Label etiquetaCarrito = new Label
            {
                Text = "Tu pedido",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(49, 43, 37),
                AutoSize = true,
                Location = new Point(24, 226)
            };
            Controls.Add(etiquetaCarrito);

            listaCarrito = new ListBox
            {
                Location = new Point(24, 255),
                Size = new Size(916, 295),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                IntegralHeight = false,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10F)
            };
            Controls.Add(listaCarrito);

            etiquetaTotal = new Label
            {
                Location = new Point(24, 566),
                Size = new Size(440, 34),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(49, 43, 37)
            };
            Controls.Add(etiquetaTotal);

            Button eliminar = CrearBoton("Quitar seleccionado", Color.FromArgb(155, 79, 62), 433, 564, 155);
            eliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            eliminar.Click += EliminarDelCarrito;
            Controls.Add(eliminar);

            Button historial = CrearBoton("Historial", Color.FromArgb(78, 92, 115), 600, 564, 115);
            historial.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            historial.Click += delegate { new HistorialForm(servicio).ShowDialog(this); };
            Controls.Add(historial);

            Button finalizar = CrearBoton("Finalizar pedido", Color.FromArgb(47, 112, 77), 727, 564, 213);
            finalizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            finalizar.Click += FinalizarPedido;
            Controls.Add(finalizar);

            ActualizarCarrito();
        }

        private static Label CrearEtiqueta(string texto, int x, int y)
        {
            return new Label
            {
                Text = texto,
                Location = new Point(x, y),
                AutoSize = true,
                ForeColor = Color.FromArgb(77, 72, 66)
            };
        }

        private static ComboBox CrearCombo(int x, int y, int ancho)
        {
            return new ComboBox
            {
                Location = new Point(x, y),
                Width = ancho,
                DropDownStyle = ComboBoxStyle.DropDownList,
                IntegralHeight = false,
                MaxDropDownItems = 12
            };
        }

        private static Button CrearBoton(string texto, Color color, int x, int y, int ancho)
        {
            return new Button
            {
                Text = texto,
                Location = new Point(x, y),
                Size = new Size(ancho, 36),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
        }

        private void AgregarAlCarrito(object sender, EventArgs e)
        {
            Producto bebida = comboBebida.SelectedItem as Producto;
            Producto acompanamiento = comboAcompanamiento.SelectedItem as Producto;

            try
            {
                servicio.AgregarAlCarrito(
                    bebida == null ? null : bebida.Id,
                    acompanamiento == null ? null : acompanamiento.Id);
                comboBebida.SelectedIndex = -1;
                comboAcompanamiento.SelectedIndex = -1;
                ActualizarCarrito();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Selección incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EliminarDelCarrito(object sender, EventArgs e)
        {
            ItemPedido seleccionado = listaCarrito.SelectedItem as ItemPedido;
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccioná una línea del pedido.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            servicio.EliminarDelCarrito(seleccionado.Id);
            ActualizarCarrito();
        }

        private void FinalizarPedido(object sender, EventArgs e)
        {
            decimal total = servicio.CalcularTotalCarrito();
            if (total <= 0)
            {
                MessageBox.Show("El carrito está vacío. Agregá productos antes de finalizar.", "Pedido vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "Total a abonar: " + total.ToString("C0", CultureInfo.GetCultureInfo("es-AR")) + "\n\n¿Confirmás el pedido?",
                "Confirmar pedido",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                Pedido pedido = servicio.RegistrarPedido();
                ActualizarCarrito();
                MessageBox.Show(
                    "¡Gracias por tu compra!\nTotal: " + pedido.TotalFormateado,
                    "Pedido guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el pedido.\n\n" + ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarCarrito()
        {
            listaCarrito.DataSource = null;
            listaCarrito.DataSource = servicio.ObtenerCarrito().ToList();
            listaCarrito.DisplayMember = "Etiqueta";
            etiquetaTotal.Text = "Total: " + servicio.CalcularTotalCarrito().ToString("C0", CultureInfo.GetCultureInfo("es-AR"));
        }
    }
}
