using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelo
{
    public class RegistroEvolucion
    {
        public int Dia { get; set; }
        public double IndiceSaludCultivo { get; set; }
        public int CantidadPsilidos { get; set; }
        public CondicionesAmbientales Condiciones { get; set; }
    }
}
