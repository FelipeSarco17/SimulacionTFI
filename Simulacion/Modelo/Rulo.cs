using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelo
{
    public class Rulo
    {
        public double TasaReproduccion { get; set; } // Tasa de reproducción base por día
        public double TasaMovilidad { get; set; } // Distancia promedio de desplazamiento por día en metros
        public int CicloVida { get; set; } // Duración del ciclo de vida en días
        public double SensibilidadLuz { get; set; } // Sensibilidad a las trampas de luz (0-1)
        public double SensibilidadHumedad { get; set; } // Sensibilidad a la humedad (0-1)
        public double SensibilidadTemperatura { get; set; } // Sensibilidad a la temperatura (0-1)

        public double CalcularTasaReproduccionEfectiva(CondicionesAmbientales condiciones)
        {
            var factorHumedad = 1 + ((condiciones.Humedad - 50) / 50.0) * SensibilidadHumedad;
            var factorTemperatura = 1 + ((condiciones.Temperatura - 20) / 15.0) * SensibilidadTemperatura;

            return TasaReproduccion * factorHumedad * factorTemperatura;
        }

    }

    

}
