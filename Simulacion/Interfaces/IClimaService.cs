using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Interfaces
{
    public interface IClimaService
    {
        CondicionesAmbientales PredecirCondicionesParaDia(int dia, EstacionAnio estacion);
        double CalcularProbabilidadLluvia(DateTime fecha, EstacionAnio estacion);
        EstacionAnio ObtenerEstacionParaFecha(DateTime fecha);
    }
}
