namespace Simulacion.Vistas
{
    partial class SimuladorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            dateTimePickerInicio = new Controles.SelectorFecha();
            label3 = new Label();
            dateTimePickerFin = new Controles.SelectorFecha();
            labelDiaActual = new Label();
            btnIniciarSimulacion = new Button();
            btnToggleTrampas = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(1428, 53);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Demi", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(442, 9);
            label1.Name = "label1";
            label1.Size = new Size(493, 34);
            label1.TabIndex = 0;
            label1.Text = "Simulacion de plantacion de yerba mate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 135);
            label2.Name = "label2";
            label2.Size = new Size(217, 15);
            label2.TabIndex = 1;
            label2.Text = "Ingrese el dia de inicio de la plantacion: ";
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.BorderColor = Color.DarkGreen;
            dateTimePickerInicio.BorderSize = 2;
            dateTimePickerInicio.CalendarFont = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerInicio.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerInicio.Location = new Point(262, 122);
            dateTimePickerInicio.MinimumSize = new Size(0, 35);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(234, 35);
            dateTimePickerInicio.SkinColor = Color.White;
            dateTimePickerInicio.TabIndex = 2;
            dateTimePickerInicio.TextColor = Color.DimGray;
            dateTimePickerInicio.ValueChanged += selectorFecha1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(522, 135);
            label3.Name = "label3";
            label3.Size = new Size(202, 15);
            label3.TabIndex = 3;
            label3.Text = "Ingrese el dia de fin de la plantacion: ";
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.BorderColor = Color.DarkGreen;
            dateTimePickerFin.BorderSize = 2;
            dateTimePickerFin.CalendarFont = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerFin.Font = new Font("Segoe UI", 9.5F);
            dateTimePickerFin.Location = new Point(745, 122);
            dateTimePickerFin.MinimumSize = new Size(0, 35);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(234, 35);
            dateTimePickerFin.SkinColor = Color.White;
            dateTimePickerFin.TabIndex = 4;
            dateTimePickerFin.TextColor = Color.DimGray;
            dateTimePickerFin.CloseUp += dateTimePickerFin_CloseUp;
            // 
            // labelDiaActual
            // 
            labelDiaActual.AutoSize = true;
            labelDiaActual.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDiaActual.Location = new Point(39, 233);
            labelDiaActual.Name = "labelDiaActual";
            labelDiaActual.Size = new Size(46, 24);
            labelDiaActual.TabIndex = 5;
            labelDiaActual.Text = "Dias";
            // 
            // btnIniciarSimulacion
            // 
            btnIniciarSimulacion.Location = new Point(1050, 126);
            btnIniciarSimulacion.Name = "btnIniciarSimulacion";
            btnIniciarSimulacion.Size = new Size(147, 33);
            btnIniciarSimulacion.TabIndex = 6;
            btnIniciarSimulacion.Text = "INICIAR SIMULACION";
            btnIniciarSimulacion.UseVisualStyleBackColor = true;
            btnIniciarSimulacion.Click += btnIniciarSimulacion_Click;
            // 
            // btnToggleTrampas
            // 
            btnToggleTrampas.BackColor = Color.LightGreen;
            btnToggleTrampas.Location = new Point(262, 169);
            btnToggleTrampas.Name = "btnToggleTrampas";
            btnToggleTrampas.Size = new Size(180, 50);
            btnToggleTrampas.TabIndex = 6;
            btnToggleTrampas.Text = "Trampas de luz: ACTIVADO";
            btnToggleTrampas.UseVisualStyleBackColor = false;
            btnToggleTrampas.Click += btnToggleTrampas_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGreen;
            panel2.Location = new Point(324, 308);
            panel2.Name = "panel2";
            panel2.Size = new Size(118, 290);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkGreen;
            panel3.Location = new Point(509, 308);
            panel3.Name = "panel3";
            panel3.Size = new Size(118, 290);
            panel3.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkGreen;
            panel4.Location = new Point(705, 308);
            panel4.Name = "panel4";
            panel4.Size = new Size(118, 290);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkGreen;
            panel5.Location = new Point(899, 308);
            panel5.Name = "panel5";
            panel5.Size = new Size(118, 290);
            panel5.TabIndex = 10;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkGreen;
            panel6.Location = new Point(1092, 308);
            panel6.Name = "panel6";
            panel6.Size = new Size(118, 290);
            panel6.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 187);
            label4.Name = "label4";
            label4.Size = new Size(192, 15);
            label4.TabIndex = 12;
            label4.Text = "Quiere simular con trampas de luz?";
            // 
            // SimuladorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1426, 661);
            Controls.Add(label4);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnIniciarSimulacion);
            Controls.Add(labelDiaActual);
            Controls.Add(dateTimePickerFin);
            Controls.Add(label3);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnToggleTrampas);
            Name = "SimuladorView";
            Text = "Simulador";
            FormClosed += SimuladorView_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Controles.SelectorFecha dateTimePickerInicio;
        private Label label3;
        private Controles.SelectorFecha dateTimePickerFin;
        private Label labelDiaActual;
        private Button btnIniciarSimulacion;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label4;
    }
}