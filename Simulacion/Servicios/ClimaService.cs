using Simulacion.Interfaces;
using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Servicios
{
    public class ClimaService : IClimaService
    {
        private readonly Random _random;

        public ClimaService()
        {
            _random = new Random();
        }

        public CondicionesAmbientales PredecirCondicionesParaDia(int dia, EstacionAnio estacion)
        {
            // Temperatura base según estación
            double temperaturaBase = estacion switch
            {
                EstacionAnio.Verano => 28,
                EstacionAnio.Primavera => 22,
                EstacionAnio.Otoño => 18,
                EstacionAnio.Invierno => 12,
                _ => 20
            };

            // Variación diaria de temperatura
            double variacionTemperatura = (_random.NextDouble() * 6) - 3;

            // Humedad base según estación
            double humedadBase = estacion switch
            {
                EstacionAnio.Verano => 65,
                EstacionAnio.Primavera => 70,
                EstacionAnio.Otoño => 75,
                EstacionAnio.Invierno => 80,
                _ => 70
            };

            // Variación diaria de humedad
            double variacionHumedad = (_random.NextDouble() * 20) - 10;

            // Probabilidad de lluvia según estación
            double probabilidadLluviaBase = estacion switch
            {
                EstacionAnio.Verano => 30,
                EstacionAnio.Primavera => 40,
                EstacionAnio.Otoño => 50,
                EstacionAnio.Invierno => 60,
                _ => 40
            };

            // Variación diaria de probabilidad de lluvia
            double variacionProbabilidadLluvia = (_random.NextDouble() * 30) - 15;

            // Velocidad del viento según estación
            int velocidadVientoBase = estacion switch
            {
                EstacionAnio.Verano => 10,
                EstacionAnio.Primavera => 15,
                EstacionAnio.Otoño => 20,
                EstacionAnio.Invierno => 25,
                _ => 15
            };

            // Variación diaria de velocidad del viento
            int variacionVelocidadViento = _random.Next(-5, 6);

            // Horas de luz según estación
            int horasLuzBase = estacion switch
            {
                EstacionAnio.Verano => 14,
                EstacionAnio.Primavera => 12,
                EstacionAnio.Otoño => 10,
                EstacionAnio.Invierno => 8,
                _ => 12
            };

            // Generar condiciones ambientales para el día
            return new CondicionesAmbientales
            {
                Temperatura = Math.Round(temperaturaBase + variacionTemperatura, 1),
                Humedad = Math.Min(100, Math.Max(0, Math.Round(humedadBase + variacionHumedad, 1))),
                ProbabilidadLluvia = Math.Min(100, Math.Max(0, Math.Round(probabilidadLluviaBase + variacionProbabilidadLluvia, 1))),
                Estacion = estacion,
                HorasDeLuz = horasLuzBase
            };
        }

        public double CalcularProbabilidadLluvia(DateTime fecha, EstacionAnio estacion)
        {
            // Determinar mes y día
            int mes = fecha.Month;
            int dia = fecha.Day;

            // Base según estación
            double probabilidadBase = estacion switch
            {
                EstacionAnio.Verano => 30,
                EstacionAnio.Primavera => 40,
                EstacionAnio.Otoño => 50,
                EstacionAnio.Invierno => 60,
                _ => 40
            };

            // Ajuste por mes dentro de la estación
            double ajusteMes = 0;

            // Ejemplo para hemisferio sur (ajustar según hemisferio)
            if (estacion == EstacionAnio.Verano) // Diciembre a Febrero
            {
                if (mes == 12) ajusteMes = -5;
                else if (mes == 1) ajusteMes = 0;
                else if (mes == 2) ajusteMes = 10;
            }

            // Factor de oscilación semanal (simulación simplificada de ciclos meteorológicos)
            double oscilacionSemanal = Math.Sin(dia / 7.0 * 2 * Math.PI) * 10;

            // Probabilidad final
            double probabilidadFinal = probabilidadBase + ajusteMes + oscilacionSemanal;

            // Limitamos entre 0 y 100
            return Math.Min(100, Math.Max(0, probabilidadFinal));
        }

        public EstacionAnio ObtenerEstacionParaFecha(DateTime fecha)
        {
            // Adaptado para hemisferio sur
            int mes = fecha.Month;

            if (mes >= 3 && mes <= 5)
                return EstacionAnio.Otoño;
            else if (mes >= 6 && mes <= 8)
                return EstacionAnio.Invierno;
            else if (mes >= 9 && mes <= 11)
                return EstacionAnio.Primavera;
            else
                return EstacionAnio.Verano;

        }
    }
}
