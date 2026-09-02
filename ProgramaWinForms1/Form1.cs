namespace MenuCafeteria
{
    public partial class Form1 : Form
    {
        string[] infusiones = { "Café - $3000", "Café con leche - $3000", "Licuado - $4000", "Jugo de naranja - $2600", "Yogurt con granola - $4200", "Gaseosa - $2500", "Agua mineral - $1500" };
        decimal[] preciosInfusiones = { 3000, 3000, 4000, 2600, 4200, 2000, 1500 };

        string[] acompañamientos = { "Medialuna - $1200", "Mafalda - $1600", "Criollo - $500 c/u", "Tostado JyQ - $4000", "Porción de torta a elección - $4200" };
        decimal[] preciosAcompañamientos = { 1200, 1600, 500, 4000, 4200 };

        string[] carritoItems = new string[25];
        decimal[] carritoPrecios = new decimal[25];
        int cantidadItems = 0;


        public Form1()
        {
            InitializeComponent();

            comboBoxInfusion.Items.AddRange(infusiones);
            comboBoxAcompañamiento.Items.AddRange(acompañamientos);
          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (cantidadItems >= carritoItems.Length)
            {
                MessageBox.Show("El carrito está lleno.");
                return;
            }

            string item = " ";
            decimal precio = 0;

            bool hayInfusion = comboBoxInfusion.SelectedItem != null;
            bool hayAcompañamiento = comboBoxAcompañamiento.SelectedItem != null;

            if (!hayInfusion && !hayAcompañamiento)
            {
                MessageBox.Show("Elije al menos una opción para continuar");
                return;
            }

            if (hayInfusion && hayAcompañamiento)
            {
                item = comboBoxInfusion.SelectedItem.ToString() + " + " + comboBoxAcompañamiento.SelectedItem.ToString();

                precio = preciosInfusiones[comboBoxInfusion.SelectedIndex] + preciosAcompañamientos[comboBoxAcompañamiento.SelectedIndex];
            }
            else if (hayInfusion)
            {
                item = comboBoxInfusion.SelectedItem.ToString();
                precio = preciosInfusiones[comboBoxInfusion.SelectedIndex];
            }
            else
            {
                item = comboBoxAcompañamiento.SelectedItem.ToString();
                precio = preciosAcompañamientos[comboBoxAcompañamiento.SelectedIndex];
            }


            carritoItems[cantidadItems] = item + " Total: $" + precio;
            carritoPrecios[cantidadItems] = precio;
            cantidadItems++;

            listBoxCarrito.Items.Clear();
            for (int i = 0; i < cantidadItems; i++)

                listBoxCarrito.Items.Add(carritoItems[i]);


            comboBoxInfusion.SelectedIndex = -1;
            comboBoxAcompañamiento.SelectedIndex = -1;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (cantidadItems == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregá algo antes de finalizar.");
                return;
            }

          
            decimal total = 0;
            for (int i = 0; i < cantidadItems; i++)
            {
                total += carritoPrecios[i];
            }

            DialogResult respuesta = MessageBox.Show($"Total a abonar: ${total} \n¿Querés agregar algo más antes de pagar?",
                "Confirmar pedido",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                
                return;
            }

         
            MessageBox.Show($"¡Gracias por tu compra! Total a pagar: ${total}");

            cantidadItems = 0;
            listBoxCarrito.Items.Clear();
            comboBoxInfusion.SelectedIndex = -1;
            comboBoxAcompañamiento.SelectedIndex = -1;
        }
    }
}

