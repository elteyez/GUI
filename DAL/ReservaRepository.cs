using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaRepository
    {
        private string ruta = "reservas.txt";


        public string Agregar(Reserva entity)
        {
            try
            {
                //1
                StreamWriter escritor = new StreamWriter(ruta, true);
                //2
                escritor.WriteLine(entity.Formatear());
                //3
                escritor.Close();
                return $"se guardo la reserva con id {entity.id} al solicitante {entity.solicitante}";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public List<Reserva> ObtenerTodas()
        {
            try
            {
                List<Reserva> lista = new List<Reserva>();
                StreamReader lector = new StreamReader(ruta);

                while (!lector.EndOfStream)
                {
                    lista.Add(Mappear(lector.ReadLine()));
                }
                lector.Close();
                return lista;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private Reserva Mappear(string linea)
        {
            Reserva reserva = new Reserva();
            //var aux = linea.Split(';');

            reserva.id = int.Parse(linea.Split('|')[0]);
            reserva.solicitante = linea.Split('|')[1];
            reserva.sala = int.Parse(linea.Split('|')[2]);
            reserva.fecha = linea.Split('|')[3];
            return reserva;
        }

    }
}

