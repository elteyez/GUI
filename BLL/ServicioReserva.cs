using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioReserva
    {
        List<Reserva> reservas;
        ReservaRepository reservaRepository;
        public ServicioReserva()
        {
            reservaRepository = new ReservaRepository();
            reservas = reservaRepository.ObtenerTodas();

        }

        public string Agregar(Reserva reserva)
        {
            var mensaje = reservaRepository.Agregar(reserva);
            return mensaje;
        }

        public List<Reserva> ObtenerTodas()
        {
            reservas = reservaRepository.ObtenerTodas();
            return reservas;
        }

        public int ObtenerId()
        {
            if (reservas == null)
            {
                return 1;
            }
            else
            {
                int ultimoId = reservas.Last().id;
                ultimoId++;

                return ultimoId;
            }    
        }
    }
}
