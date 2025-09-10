using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Reserva
    {
        public int id;
        public string solicitante;
        public int sala;
        public string fecha;

        public Reserva()
        {
        }

        public Reserva(int id, string solicitante, int sala, string fecha)
        {
            this.id = id;
            this.solicitante = solicitante;
            this.sala = sala;
            this.fecha = fecha;
        }

        public string Formatear()
        {
            return $"{id}|{solicitante}|{sala}|{fecha}";
        }
    }
}
