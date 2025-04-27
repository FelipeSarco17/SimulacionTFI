using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Interfaces
{
    public interface IReporteService
    {
        string GenerarReporteDistribucionTrampas(List<Parcela> parcelas);
        string GenerarReporteEvolucionPlagas(SimulacionYB simulacion);
        string GenerarReporteRendimientoTrampas(List<TrampaLuz> trampas, int diasSimulacion);
    }
}
