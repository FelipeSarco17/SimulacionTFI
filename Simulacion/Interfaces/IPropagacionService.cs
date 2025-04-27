using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Interfaces
{
    public interface IPropagacionService
    {
        public interface IPropagacionService
        {
            void SimularPropagacion(SimulacionYB simulacion, int dias);
            double CalcularProbabilidadInfestacion(Planta planta, List<TrampaLuz> trampas, CondicionesAmbientales condiciones);
            void ActualizarNivelesInfestacion(Parcela parcela, CondicionesAmbientales condiciones);
        }
    }
}
