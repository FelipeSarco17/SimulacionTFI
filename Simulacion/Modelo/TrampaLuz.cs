using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Modelo
{
    public class TrampaLuz
    {
        public int Id { get; set; }
        public double PosicionX { get; set; } // en metros desde el origen de la parcela
        public double PosicionY { get; set; } // en metros desde el origen de la parcela
        public double RadioEfectivo { get; set; } // Radio en metros donde la trampa es efectiva
        
        public bool EstaActiva { get; set; }
        public int EficienciaCaptura { get; set; }
    }
}
