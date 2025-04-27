using Simulacion.Interfaces;
using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Servicios
{
    public class PropagacionService : IPropagacionService
    {
        private readonly Rulo _caracteristicasPsilido;
        private readonly Random _random;

        public PropagacionService()
        {
            _caracteristicasPsilido = new Rulo
            {
                TasaReproduccion = 0.15,
                TasaMovilidad = 2.5,
                CicloVida = 30,
                SensibilidadLuz = 0.8,
                SensibilidadHumedad = 0.6,
                SensibilidadTemperatura = 0.7
            };
            _random = new Random();
        }

        public void SimularPropagacion(SimulacionYB simulacion, int dias)
        {
            for (int i = 0; i < dias; i++)
            {
                // Actualizar condiciones ambientales para el día actual
                ActualizarCondicionesDiarias(simulacion);

                // Para cada parcela, simular la propagación de los psilidos
                foreach (var parcela in simulacion.Parcelas)
                {
                    ActualizarNivelesInfestacion(parcela, simulacion.CondicionesActuales);
                }

                // Avanzar la simulación un día
                simulacion.AvanzarDia();
            }
        }

        public double CalcularProbabilidadInfestacion(Planta planta, List<TrampaLuz> trampas, CondicionesAmbientales condiciones)
        {
            double factorPropagacion = condiciones.FactorPropagacion();
            double factorProteccionTrampas = CalcularFactorProteccionTrampas(planta, trampas);

            // Plantas más jóvenes son más susceptibles
            double factorEdad = Math.Max(0.5, Math.Min(1.0, planta.Edad / 36.0));

            // Probabilidad base de infestación
            double probabilidadBase = 0.05;

            return probabilidadBase * factorPropagacion / (factorProteccionTrampas * factorEdad);
        }

        public void ActualizarNivelesInfestacion(Parcela parcela, CondicionesAmbientales condiciones)
        {
            foreach (var planta in parcela.Plantas)
            {
                // Calcular probabilidad de infestación
                double probabilidadInfestacion = CalcularProbabilidadInfestacion(planta, parcela.Trampas, condiciones);

                // Actualizar nivel de infestación
                planta.NivelInfestacion = Math.Min(1.0, planta.NivelInfestacion +
                                                  (_random.NextDouble() < probabilidadInfestacion ?
                                                  _caracteristicasPsilido.CalcularTasaReproduccionEfectiva(condiciones) :
                                                  -0.02)); // Recuperación natural muy lenta

                planta.NivelInfestacion = Math.Max(0, planta.NivelInfestacion);

                // Actualizar estado de la planta
                planta.ActualizarEstado();
            }
        }

        private double CalcularFactorProteccionTrampas(Planta planta, List<TrampaLuz> trampas)
        {
            double factorProteccion = 1.0; // Sin protección

            foreach (var trampa in trampas.Where(t => t.EstaActiva))
            {
                // Calcular distancia entre la planta y la trampa
                double distancia = Math.Sqrt(
                    Math.Pow(planta.PosicionX - trampa.PosicionX, 2) +
                    Math.Pow(planta.PosicionY - trampa.PosicionY, 2));

                // Si la planta está dentro del radio efectivo de la trampa
                if (distancia <= trampa.RadioEfectivo)
                {
                    // Calcular factor de protección basado en la distancia y eficiencia de la trampa
                    double factorDistancia = 1 - distancia / trampa.RadioEfectivo;
                    double factorEficiencia = trampa.EficienciaCaptura / 100.0;
                    factorProteccion += factorDistancia * factorEficiencia * _caracteristicasPsilido.SensibilidadLuz;
                }
            }

            return factorProteccion;
        }

        private void ActualizarCondicionesDiarias(SimulacionYB simulacion)
        {
            // Implementar lógica para actualizar las condiciones ambientales
            // Este método sería más complejo en una implementación real
        }
    }
}

