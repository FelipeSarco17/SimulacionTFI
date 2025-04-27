using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Interfaces
{
    public interface IPlantacionService
    {
        void GenerarPlantacion(Parcela parcela, double densidad);
        void ActualizarEstadoPlantacion(Parcela parcela, CondicionesAmbientales condiciones);
        double CalcularSaludPromedio(Parcela parcela);
    }
}
