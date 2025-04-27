using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelo
{
    public class Parcela
    {
        public int Id { get; set; }
        public double Ancho { get; set; } // en metros
        public double Largo { get; set; } // en metros
        public int CantidadPlantas { get; set; }
        public DateTime FechaSiembra { get; set; }
        public double DensidadPlantas => CantidadPlantas / (Ancho * Largo);
        public List<Planta> Plantas { get; set; } = new List<Planta>();
        public List<TrampaLuz> Trampas { get; set; } = new List<TrampaLuz>();

        /// <summary>
        /// Calcula el nivel de infestación promedio de la parcela
        /// </summary>
        public double CalcularNivelInfestacionPromedio()
        {
            if (Plantas.Count == 0) return 0;
            return Plantas.Average(p => p.NivelInfestacion);
        }
    }
}

