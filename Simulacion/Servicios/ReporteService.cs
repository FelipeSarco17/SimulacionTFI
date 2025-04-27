using Simulacion.Interfaces;
using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Servicios
{
    public class ReporteService : IReporteService
    {
        public string GenerarReporteDistribucionTrampas(List<Parcela> parcelas)
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine("# Reporte de Distribución de Trampas");
            sb.AppendLine("---");

            int totalTrampas = 0;
            double areaTotal = 0;

            foreach (var parcela in parcelas)
            {
                totalTrampas += parcela.Trampas.Count;
                areaTotal += parcela.Ancho * parcela.Largo;
            }

            sb.AppendLine($"**Total de trampas instaladas:** {totalTrampas}");
            sb.AppendLine($"**Área total cultivada:** {areaTotal:F2} m²");
            sb.AppendLine($"**Densidad media de trampas:** {totalTrampas / areaTotal:F4} trampas/m²");
            sb.AppendLine();

            sb.AppendLine("## Detalle por parcela");
            sb.AppendLine();
            sb.AppendLine("| ID Parcela | Dimensiones (m) | Área (m²) | # Trampas | Densidad (trampas/m²) |");
            sb.AppendLine("|------------|----------------|-----------|-----------|------------------------|");

            foreach (var parcela in parcelas)
            {
                double areaParcela = parcela.Ancho * parcela.Largo;
                double densidadTrampas = parcela.Trampas.Count / areaParcela;

                sb.AppendLine($"| {parcela.Id} | {parcela.Ancho:F1} x {parcela.Largo:F1} | {areaParcela:F1} | {parcela.Trampas.Count} | {densidadTrampas:F4} |");
            }

            sb.AppendLine();
            sb.AppendLine("## Recomendaciones");

            // Análisis simple de la distribución
            double densidadPromedio = totalTrampas / areaTotal;

            if (densidadPromedio < 0.005)
            {
                sb.AppendLine("⚠️ **La densidad de trampas es baja**. Se recomienda aumentar el número de trampas para mejorar el control de psilidos.");
            }
            else if (densidadPromedio > 0.02)
            {
                sb.AppendLine("ℹ️ **La densidad de trampas es alta**. Podría considerar optimizar la distribución para reducir costos manteniendo la eficacia.");
            }
            else
            {
                sb.AppendLine("✅ **La densidad de trampas es adecuada**. Se recomienda mantener el monitoreo regular de la eficacia.");
            }

            return sb.ToString();
        }

        public string GenerarReporteEvolucionPlagas(SimulacionYB simulacion)
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine("# Reporte de Evolución de Plagas");
            sb.AppendLine("---");

            if (simulacion.HistorialEvolucion.Count == 0)
            {
                sb.AppendLine("No hay datos de evolución disponibles. Ejecute la simulación primero.");
                return sb.ToString();
            }

            var primerRegistro = simulacion.HistorialEvolucion.First();
            var ultimoRegistro = simulacion.HistorialEvolucion.Last();

            sb.AppendLine($"**Período analizado:** {simulacion.FechaInicio.ToShortDateString()} - {simulacion.FechaInicio.AddDays(ultimoRegistro.Dia).ToShortDateString()}");
            sb.AppendLine($"**Duración total:** {ultimoRegistro.Dia} días");
            sb.AppendLine();

            // Análisis de tendencia
            double indiceSaludInicial = primerRegistro.IndiceSaludCultivo;
            double indiceSaludFinal = ultimoRegistro.IndiceSaludCultivo;
            double cambioSalud = indiceSaludFinal - indiceSaludInicial;

            sb.AppendLine("## Indicadores Clave");
            sb.AppendLine();
            sb.AppendLine($"- **Índice de salud inicial:** {indiceSaludInicial:P1}");
            sb.AppendLine($"- **Índice de salud final:** {indiceSaludFinal:P1}");

            if (cambioSalud > 0.05)
            {
                sb.AppendLine($"- **Tendencia:** ✅ **Mejora significativa** (+{cambioSalud:P1})");
            }
            else if (cambioSalud < -0.05)
            {
                sb.AppendLine($"- **Tendencia:** ⚠️ **Deterioro significativo** ({cambioSalud:P1})");
            }
            else
            {
                sb.AppendLine($"- **Tendencia:** ➡️ **Estable** ({cambioSalud:P1})");
            }

            sb.AppendLine();

            // Análisis de población de psilidos
            int poblacionInicial = primerRegistro.CantidadPsilidos;
            int poblacionFinal = ultimoRegistro.CantidadPsilidos;
            double cambioPoblacion = (double)(poblacionFinal - poblacionInicial) / Math.Max(1, poblacionInicial);

            sb.AppendLine($"- **Población inicial de psilidos:** {poblacionInicial:N0}");
            sb.AppendLine($"- **Población final de psilidos:** {poblacionFinal:N0}");

            if (cambioPoblacion < -0.2)
            {
                sb.AppendLine($"- **Cambio poblacional:** ✅ **Reducción** ({cambioPoblacion:P1})");
            }
            else if (cambioPoblacion > 0.2)
            {
                sb.AppendLine($"- **Cambio poblacional:** ⚠️ **Aumento** (+{cambioPoblacion:P1})");
            }
            else
            {
                sb.AppendLine($"- **Cambio poblacional:** ➡️ **Estable** ({cambioPoblacion:P1})");
            }

            sb.AppendLine();
            sb.AppendLine("## Correlación con factores ambientales");

            // Identificar condiciones que favorecen propagación
            var registrosConAltaPropagacion = simulacion.HistorialEvolucion
                .Where(r => r.Dia > 1 && r.CantidadPsilidos > simulacion.HistorialEvolucion
                    .FirstOrDefault(prev => prev.Dia == r.Dia - 1)?.CantidadPsilidos * 1.1)
                .ToList();

            if (registrosConAltaPropagacion.Any())
            {
                sb.AppendLine("### Condiciones que favorecieron la propagación:");

                double tempPromedio = registrosConAltaPropagacion.Average(r => r.Condiciones.Temperatura);
                double humedadPromedio = registrosConAltaPropagacion.Average(r => r.Condiciones.Humedad);
                double lluviaPromedio = registrosConAltaPropagacion.Average(r => r.Condiciones.ProbabilidadLluvia);

                sb.AppendLine($"- **Temperatura media:** {tempPromedio:F1}°C");
                sb.AppendLine($"- **Humedad media:** {humedadPromedio:F1}%");
                sb.AppendLine($"- **Probabilidad de lluvia media:** {lluviaPromedio:F1}%");

                var estacionesPropagacion = registrosConAltaPropagacion
                    .GroupBy(r => r.Condiciones.Estacion)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key)
                    .ToList();

                if (estacionesPropagacion.Any())
                {
                    sb.AppendLine($"- **Estación predominante:** {estacionesPropagacion.First()}");
                }
            }
            else
            {
                sb.AppendLine("No se identificaron períodos claros de alta propagación.");
            }

            sb.AppendLine();
            sb.AppendLine("## Recomendaciones");

            if (indiceSaludFinal < 0.6)
            {
                sb.AppendLine("- ⚠️ **El índice de salud del cultivo es bajo**. Se recomienda aumentar la densidad de trampas y considerar tratamientos complementarios.");
            }

            if (cambioPoblacion > 0.1)
            {
                sb.AppendLine("- ⚠️ **La población de psilidos está en aumento**. Revisar la efectividad de las trampas actuales y considerar su reubicación.");
            }

            if (registrosConAltaPropagacion.Count > simulacion.HistorialEvolucion.Count * 0.3)
            {
                sb.AppendLine("- ⚠️ **Alta frecuencia de días con propagación acelerada**. Considerar medidas preventivas adicionales durante las condiciones ambientales identificadas.");
            }

            return sb.ToString();
        }

        public string GenerarReporteRendimientoTrampas(List<TrampaLuz> trampas, int diasSimulacion)
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine("# Reporte de Rendimiento de Trampas");
            sb.AppendLine("---");

            if (trampas.Count == 0)
            {
                sb.AppendLine("No hay trampas instaladas para analizar.");
                return sb.ToString();
            }

            sb.AppendLine($"**Total de trampas analizadas:** {trampas.Count}");
            sb.AppendLine($"**Período de análisis:** {diasSimulacion} días");
            sb.AppendLine();

            // Estadísticas básicas
            double radioPromedioEfectivo = trampas.Average(t => t.RadioEfectivo);
            double eficienciaPromedioCaptura = trampas.Average(t => t.EficienciaCaptura);

            sb.AppendLine("## Características Técnicas");
            sb.AppendLine();
            sb.AppendLine($"- **Radio efectivo promedio:** {radioPromedioEfectivo:F1} metros");
            sb.AppendLine($"- **Eficiencia promedio de captura:** {eficienciaPromedioCaptura:F1}%");
            sb.AppendLine();

            sb.AppendLine();
            sb.AppendLine("## Análisis de Cobertura");

            // Análisis simple de cobertura
            double areaCubiertaPromedio = Math.PI * Math.Pow(radioPromedioEfectivo, 2) * trampas.Count;
            sb.AppendLine($"- **Área total cubierta (estimada):** {areaCubiertaPromedio:F1} m²");

            return sb.ToString();
        }
    }

}

