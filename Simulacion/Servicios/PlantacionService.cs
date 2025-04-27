using Simulacion.Interfaces;
using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Servicios
{
    public class PlantacionService : IPlantacionService
    {
        private readonly Random _random;

        public PlantacionService()
        {
            _random = new Random();
        }

        public void GenerarPlantacion(Parcela parcela, double densidad)
        {
            // Limpiar plantas existentes
            parcela.Plantas.Clear();

            // Calcular cantidad de plantas basado en la densidad (plantas por metro cuadrado)
            int cantidadPlantas = (int)(parcela.Ancho * parcela.Largo * densidad);
            parcela.CantidadPlantas = cantidadPlantas;

            // Determinar la disposición en filas y columnas (habitualmente las yerbas se plantan en hileras)
            double espacioEntreFilas = Math.Sqrt(1.0 / densidad);
            double espacioEntrePlantas = espacioEntreFilas;

            int filasEstimadas = (int)(parcela.Largo / espacioEntreFilas);
            int plantasPorFila = (int)(parcela.Ancho / espacioEntrePlantas);

            // Ajustar si es necesario
            if (filasEstimadas * plantasPorFila < cantidadPlantas)
            {
                filasEstimadas++;
            }

            // Generar las plantas
            int plantasGeneradas = 0;
            for (int fila = 0; fila < filasEstimadas && plantasGeneradas < cantidadPlantas; fila++)
            {
                for (int col = 0; col < plantasPorFila && plantasGeneradas < cantidadPlantas; col++)
                {
                    // Posición base
                    double posX = col * espacioEntrePlantas + espacioEntrePlantas / 2;
                    double posY = fila * espacioEntreFilas + espacioEntreFilas / 2;

                    // Añadir un poco de aleatoriedad para que no sea una cuadrícula perfecta
                    posX += (_random.NextDouble() - 0.5) * espacioEntrePlantas * 0.2;
                    posY += (_random.NextDouble() - 0.5) * espacioEntreFilas * 0.2;

                    // Verificar que esté dentro de los límites de la parcela
                    if (posX >= 0 && posX <= parcela.Ancho && posY >= 0 && posY <= parcela.Largo)
                    {
                        var planta = new Planta
                        {
                            Id = plantasGeneradas + 1,
                            PosicionX = posX,
                            PosicionY = posY,
                            Edad = _random.Next(12, 60), // Edad inicial en meses (1-5 años)
                            Altura = _random.Next(100, 201), // Altura en cm (1-2 metros)
                            NivelInfestacion = _random.NextDouble() * 0.2, // Nivel inicial de infestación bajo
                            Estado = EstadoPlanta.Saludable
                        };

                        planta.ActualizarEstado();
                        parcela.Plantas.Add(planta);
                        plantasGeneradas++;
                    }
                }
            }
        }

        public void ActualizarEstadoPlantacion(Parcela parcela, CondicionesAmbientales condiciones)
        {
            foreach (var planta in parcela.Plantas)
            {
                // Simular crecimiento mensual (en una aplicación real esto se haría con una frecuencia menor)
                if (_random.NextDouble() < 0.03) // Aprox. una vez por mes
                {
                    planta.Edad++;

                    // Crecimiento de altura (con límite máximo)
                    if (planta.Edad < 60) // Menos de 5 años
                    {
                        planta.Altura += _random.Next(1, 4);
                    }
                    else if (planta.Edad < 120) // Entre 5 y 10 años
                    {
                        planta.Altura += _random.Next(0, 2);
                    }
                    // Después de 10 años casi no crece

                    // Limitar altura máxima
                    planta.Altura = Math.Min(300, planta.Altura); // Máximo 3 metros
                }

                // La infestación se maneja en PropagacionService
            }
        }

        public double CalcularSaludPromedio(Parcela parcela)
        {
            if (parcela.Plantas.Count == 0)
                return 1.0; // Sin plantas, consideramos salud máxima

            return parcela.Plantas.Average(p => 1.0 - p.NivelInfestacion);
        }
    }
}

