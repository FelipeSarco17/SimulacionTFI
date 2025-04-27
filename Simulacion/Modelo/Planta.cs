using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelo
{
    public class Planta
    {
        public int Id { get; set; }
        public double PosicionX { get; set; } // en metros desde el origen de la parcela
        public double PosicionY { get; set; } // en metros desde el origen de la parcela
        public int Edad { get; set; } // en meses
        public int Altura { get; set; } // en centímetros
        public double NivelInfestacion { get; set; } // de 0 a 1, donde 1 es completamente infestada

        public EstadoPlanta Estado { get; set; }

        public void ActualizarEstado()
        {
            if (NivelInfestacion >= 0.7)
                Estado = EstadoPlanta.Grave;
            else if (NivelInfestacion >= 0.4)
                Estado = EstadoPlanta.Moderado;
            else if (NivelInfestacion > 0)
                Estado = EstadoPlanta.Leve;
            else
                Estado = EstadoPlanta.Saludable;
        }
    }
}
