using Simulacion.Interfaces;
using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Servicios
{
    public class OptimizerService : IOptimizerService
    {
        private readonly Random _random;

        public OptimizerService()
        {
            _random = new Random();
        }

        public List<TrampaLuz> OptimizarColocacionTrampas(List<Parcela> parcelas, int cantidadTrampas)
        {
            var trampasTotales = new List<TrampaLuz>();

            // Algoritmo de optimización para colocar trampas de manera eficiente
            // Ejemplo simplificado: distribución proporcional al tamaño de cada parcela
            double areaTotal = parcelas.Sum(p => p.Ancho * p.Largo);

            foreach (var parcela in parcelas)
            {
                double areaParcela = parcela.Ancho * parcela.Largo;
                int trampasParcela = (int)Math.Round((areaParcela / areaTotal) * cantidadTrampas);

                // Generar posiciones óptimas para las trampas en esta parcela
                var trampasParcela_list = GenerarPosicionesOptimas(parcela, trampasParcela);
                trampasTotales.AddRange(trampasParcela_list);
            }

            // Ajustar si la cantidad no coincide exactamente
            while (trampasTotales.Count > cantidadTrampas)
            {
                trampasTotales.RemoveAt(trampasTotales.Count - 1);
            }

            return trampasTotales;
        }

        public double EvaluarEficaciaDistribucion(List<Parcela> parcelas, List<TrampaLuz> trampas)
        {
            double coberturaPonderada = 0;
            double areaTotal = 0;

            foreach (var parcela in parcelas)
            {
                double areaParcela = parcela.Ancho * parcela.Largo;
                areaTotal += areaParcela;

                // Matriz de cobertura para evaluar qué proporción de la parcela está cubierta por trampas
                int celdas = 10; // Dividir la parcela en celdas para evaluar cobertura
                bool[,] matrizCobertura = new bool[celdas, celdas];

                // Marcar qué celdas están cubiertas por trampas
                for (int i = 0; i < celdas; i++)
                {
                    for (int j = 0; j < celdas; j++)
                    {
                        double posX = parcela.Ancho * i / celdas;
                        double posY = parcela.Largo * j / celdas;

                        foreach (var trampa in trampas)
                        {
                            double distancia = Math.Sqrt(
                                Math.Pow(posX - trampa.PosicionX, 2) +
                                Math.Pow(posY - trampa.PosicionY, 2));

                            if (distancia <= trampa.RadioEfectivo)
                            {
                                matrizCobertura[i, j] = true;
                                break;
                            }
                        }
                    }
                }

                // Contar celdas cubiertas
                int celdasCubiertas = 0;
                for (int i = 0; i < celdas; i++)
                {
                    for (int j = 0; j < celdas; j++)
                    {
                        if (matrizCobertura[i, j])
                            celdasCubiertas++;
                    }
                }

                double proporcionCubierta = (double)celdasCubiertas / (celdas * celdas);
                coberturaPonderada += proporcionCubierta * areaParcela;
            }

            return coberturaPonderada / areaTotal;
        }

        public double CalcularDistanciaOptima(Parcela parcela, CondicionesAmbientales condiciones)
        {
            // Calcular la distancia óptima entre trampas basada en densidad de plantas y condiciones ambientales
            double factorPropagacion = condiciones.FactorPropagacion();
            double factorDensidad = Math.Min(1.5, Math.Max(0.5, parcela.DensidadPlantas * 100));

            // Base de distancia entre trampas (metros)
            double distanciaBase = 15.0;

            // Ajustar distancia según factores
            double distanciaOptima = distanciaBase / (factorPropagacion * factorDensidad);

            // Limitar el rango práctico de la distancia
            return Math.Min(30.0, Math.Max(5.0, distanciaOptima));
        }

        private List<TrampaLuz> GenerarPosicionesOptimas(Parcela parcela, int cantidadTrampas)
        {
            var trampas = new List<TrampaLuz>();

            if (cantidadTrampas <= 0)
                return trampas;

            // Calculamos cuántas trampas por fila/columna para una distribución en cuadrícula
            int trampasPorLado = (int)Math.Ceiling(Math.Sqrt(cantidadTrampas));
            double espacioX = parcela.Ancho / trampasPorLado;
            double espacioY = parcela.Largo / trampasPorLado;

            for (int i = 0; i < trampasPorLado && trampas.Count < cantidadTrampas; i++)
            {
                for (int j = 0; j < trampasPorLado && trampas.Count < cantidadTrampas; j++)
                {
                    double posX = (i + 0.5) * espacioX;
                    double posY = (j + 0.5) * espacioY;

                    // Añadir un poco de aleatoriedad para evitar patrones demasiado rígidos
                    posX += _random.NextDouble() * espacioX * 0.3 - espacioX * 0.15;
                    posY += _random.NextDouble() * espacioY * 0.3 - espacioY * 0.15;

                    // Asegurarnos de que la trampa está dentro de los límites de la parcela
                    posX = Math.Min(parcela.Ancho - 1, Math.Max(1, posX));
                    posY = Math.Min(parcela.Largo - 1, Math.Max(1, posY));

                    trampas.Add(new TrampaLuz
                    {
                        Id = trampas.Count + 1,
                        PosicionX = posX,
                        PosicionY = posY,
                        RadioEfectivo = 7.5, // 7.5 metros de radio efectivo
                        EstaActiva = true,
                        EficienciaCaptura = 80 // 80% de eficiencia
                    });
                }
            }

            return trampas;
        }

    }
}
