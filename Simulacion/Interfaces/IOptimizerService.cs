using Simulacion.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Interfaces
{
    public interface IOptimizerService
    {
        List<TrampaLuz> OptimizarColocacionTrampas(List<Parcela> parcelas, int cantidadTrampas);
        double EvaluarEficaciaDistribucion(List<Parcela> parcelas, List<TrampaLuz> trampas);
        double CalcularDistanciaOptima(Parcela parcela, CondicionesAmbientales condiciones);


    }
}
