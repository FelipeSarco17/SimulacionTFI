using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelo
{
    public class CondicionesAmbientales
    {
        public double Temperatura { get; set; } // en grados Celsius
        public double Humedad { get; set; } // en porcentaje (0-100)
        public double ProbabilidadLluvia { get; set; } // en porcentaje (0-100)
        public EstacionAnio Estacion { get; set; }
        public int HorasDeLuz { get; set; }

        public double FactorPropagacion()
        {
            // El psilido se beneficia de temperaturas entre 18-30°C, humedad alta y poco viento
            double factorTemperatura = 0;
            if (Temperatura >= 18 && Temperatura <= 30)
                factorTemperatura = 1.0 - Math.Abs((Temperatura - 24) / 12);
            else
                factorTemperatura = 0.3;

            double factorHumedad = Humedad / 100.0;
            double factorLluvia = ProbabilidadLluvia / 100.0;

            // La estación afecta significativamente
            double factorEstacion = Estacion switch
            {
                EstacionAnio.Verano => 1.0,
                EstacionAnio.Primavera => 0.8,
                EstacionAnio.Otoño => 0.6,
                EstacionAnio.Invierno => 0.3,
                _ => 0.5
            };

            return (factorTemperatura * 0.3 + factorHumedad * 0.2  +
                   factorLluvia * 0.15 + factorEstacion * 0.2);
        }
    }

    
}
