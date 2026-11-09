using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MenuCafeteria.Backend.Services;

namespace MenuCafeteria.WinForms
{
    public class HistorialForm : Form
    {
        public HistorialForm(ServicioCafeteria servicio)
        {
            Text = "Historial de pedidos";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(700, 400);
            Size = new Size(850, 500);
            BackColor = Color.FromArgb(246, 248, 251);
            Font = new Font("Segoe UI", 9F);

            Label titulo = new Label
            {
                Text = "Pedidos confirmados",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(49, 43, 37),
                AutoSize = true,
                Location = new Point(22, 18)
            };
            Controls.Add(titulo);

            DataGridView grilla = new DataGridView
            {
                Location = new Point(22, 66),
                Size = new Size(790, 360),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            grilla.EnableHeadersVisualStyles = false;
            grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(233, 238, 244);
            grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grilla.RowTemplate.Height = 34;
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" },
                FillWeight = 25
            });
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Resumen",
                HeaderText = "Detalle",
                FillWeight = 55
            });
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Total",
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                FillWeight = 20
            });

            grilla.DataSource = servicio.ObtenerHistorial().ToList();
            Controls.Add(grilla);

            if (grilla.Rows.Count == 0)
            {
                Label vacio = new Label
                {
                    Text = "Todavía no hay pedidos guardados.",
                    ForeColor = Color.FromArgb(110, 103, 97),
                    AutoSize = true,
                    Location = new Point(25, 78)
                };
                Controls.Add(vacio);
                vacio.BringToFront();
            }
        }
    }
}
