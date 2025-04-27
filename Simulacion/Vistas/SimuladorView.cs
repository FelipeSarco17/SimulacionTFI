using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accessibility;
using Simulacion.Controles;
using Simulacion.Vistas;


namespace Simulacion.Vistas
{
    public partial class SimuladorView : Form
    {
        private MenuPrincipal _mp;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private DateTime fechaActualSimulada;
        private System.Windows.Forms.Timer timerSimulacion;
        private int avanceDias;
        private bool avanzarPorMes;
        private bool _trampasHabilitadas = true;
        private Button btnToggleTrampas;

        public SimuladorView(MenuPrincipal mp)
        {
            InitializeComponent();
            _mp = mp;

        }

        private void ConfigurarSimulacion()
        {
            fechaInicio = dateTimePickerInicio.Value;
            fechaFin = dateTimePickerFin.Value;
            fechaActualSimulada = fechaInicio;

            TimeSpan diferencia = fechaFin - fechaInicio;

            if (diferencia.TotalDays < 30)
            {
                avanceDias = 1;
                avanzarPorMes = false;
            }
            else if (diferencia.TotalDays < 120) //
            {
                avanceDias = 7;
                avanzarPorMes = false;
            }
            else
            {
                avanzarPorMes = true;
            }

            if (timerSimulacion == null)
            {
                timerSimulacion = new System.Windows.Forms.Timer();
                timerSimulacion.Interval = 1000; // 1 segundo
                timerSimulacion.Tick += TimerSimulacion_Tick;
            }

            timerSimulacion.Start();
        }

        private void TimerSimulacion_Tick(object sender, EventArgs e)
        {
            if (avanzarPorMes)
            {
                fechaActualSimulada = fechaActualSimulada.AddMonths(1);
            }
            else
            {
                fechaActualSimulada = fechaActualSimulada.AddDays(avanceDias);
            }

            labelDiaActual.Text = "Día simulado: " + fechaActualSimulada.ToShortDateString();

            if (fechaActualSimulada >= fechaFin)
            {
                timerSimulacion.Stop();
                labelDiaActual.Text = "Simulación Finalizada";
                HabilitarControles();
            }
        }

        private void HabilitarControles()
        {
            btnToggleTrampas.Enabled = true;
            btnIniciarSimulacion.Enabled = true;
            dateTimePickerInicio.Enabled = true;
            dateTimePickerFin.Enabled = true;
            btnIniciarSimulacion.BackColor = Color.LightGreen;
            btnIniciarSimulacion.Text = "Iniciar Simulación";
            btnIniciarSimulacion.ForeColor = Color.Black;
        }

        private void SimuladorView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mp.Show();
        }

        private void selectorFecha1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerFin.MinDate = dateTimePickerInicio.Value.AddDays(1);


        }

        private void dateTimePickerFin_CloseUp(object sender, EventArgs e)
        {

        }

        private void btnIniciarSimulacion_Click(object sender, EventArgs e)
        {
            ConfigurarSimulacion();
            btnToggleTrampas.Enabled = false;
            btnIniciarSimulacion.Enabled = false;
            dateTimePickerInicio.Enabled = false;
            dateTimePickerFin.Enabled = false;
            btnIniciarSimulacion.BackColor = Color.LightGray;
            btnIniciarSimulacion.Text = "Simulación en curso...";
            btnIniciarSimulacion.ForeColor = Color.Gray;
        }

        private void btnToggleTrampas_Click(object sender, EventArgs e)
        {
            _trampasHabilitadas = !_trampasHabilitadas;

            if (_trampasHabilitadas)
            {
                btnToggleTrampas.Text = "Trampas de luz: ACTIVADO";
                btnToggleTrampas.BackColor = Color.LightGreen;
            }
            else
            {
                btnToggleTrampas.Text = "Trampas de luz: DESACTIVADO";
                btnToggleTrampas.BackColor = Color.LightCoral;
            }

        }
    }
}
