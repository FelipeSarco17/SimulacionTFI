using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelo
{
    public class SimulacionYB
    {
        public List<Parcela> Parcelas { get; set; } = new List<Parcela>();
        public CondicionesAmbientales CondicionesActuales { get; set; }
        public int CantidadTrampasTotales { get; set; }
        public int CantidadPsilidosTotales { get; set; }
        public DateTime FechaInicio { get; set; }
        public int DiaActual { get; set; }
        public double IndiceSaludCultivo { get; set; } // de 0 a 1, donde 1 es completamente saludable
        public List<RegistroEvolucion> HistorialEvolucion { get; set; } = new List<RegistroEvolucion>();

        public void AvanzarDia()
        {
            DiaActual++;
            // Lógica para actualizar el estado de la simulación cada día
            // Simulación de propagación de psilidos, efecto de las trampas, condiciones ambientales, etc.

            // Registrar el estado actual para el historial
            HistorialEvolucion.Add(new RegistroEvolucion
            {
                Dia = DiaActual,
                IndiceSaludCultivo = IndiceSaludCultivo,
                CantidadPsilidos = CantidadPsilidosTotales,
                Condiciones = CondicionesActuales
            });
        }
    }
}
