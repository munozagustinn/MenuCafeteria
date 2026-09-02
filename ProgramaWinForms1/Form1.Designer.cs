namespace MenuCafeteria
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxInfusion = new ComboBox();
            comboBoxAcompañamiento = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnAgregar = new Button();
            listBoxCarrito = new ListBox();
            btnFinalizar = new Button();
            SuspendLayout();
            // 
            // comboBoxInfusion
            // 
            comboBoxInfusion.FormattingEnabled = true;
            comboBoxInfusion.Location = new Point(389, 126);
            comboBoxInfusion.Name = "comboBoxInfusion";
            comboBoxInfusion.Size = new Size(201, 23);
            comboBoxInfusion.TabIndex = 0;
            comboBoxInfusion.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBoxAcompañamiento
            // 
            comboBoxAcompañamiento.FormattingEnabled = true;
            comboBoxAcompañamiento.Location = new Point(389, 196);
            comboBoxAcompañamiento.Name = "comboBoxAcompañamiento";
            comboBoxAcompañamiento.Size = new Size(201, 23);
            comboBoxAcompañamiento.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(389, 108);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 2;
            label1.Text = "Elige tu infusión o bebida:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(389, 178);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 3;
            label2.Text = "Elige tu acompañamiento:";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(411, 242);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar al carrito";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // listBoxCarrito
            // 
            listBoxCarrito.FormattingEnabled = true;
            listBoxCarrito.Location = new Point(304, 298);
            listBoxCarrito.Name = "listBoxCarrito";
            listBoxCarrito.Size = new Size(502, 64);
            listBoxCarrito.TabIndex = 5;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(436, 376);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(75, 23);
            btnFinalizar.TabIndex = 6;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 482);
            Controls.Add(btnFinalizar);
            Controls.Add(listBoxCarrito);
            Controls.Add(btnAgregar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxAcompañamiento);
            Controls.Add(comboBoxInfusion);
            Name = "Form1";
            Text = "x";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxInfusion;
        private ComboBox comboBoxAcompañamiento;
        private Label label1;
        private Label label2;
        private Button btnAgregar;
        private ListBox listBoxCarrito;
        private Button btnFinalizar;
    }
}
