using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class VistaReservas
    {
        ServicioReserva servicioReserva;
        public VistaReservas()
        {
            servicioReserva = new ServicioReserva();
        }

        public void MenuReservas()
        {
            int opcion = 0;
            do
            {
               Console.Clear();
                Console.WriteLine("R E S E R V A S   M E N U");
                Console.WriteLine("1. Agregar Reserva");
                Console.WriteLine("2. Listar Reservas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opcion: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: RegistrarReserva(); break;
                    case 2: ListarReservas(); break;
                    default:
                        break;
                }
            } while (opcion != 3);
        }

        private void RegistrarReserva()
        {
            Console.Clear();
            Reserva reserva = new Reserva();
            Console.WriteLine("Solicitante: ");
            reserva.solicitante = Console.ReadLine();
            Console.WriteLine("Sala: ");
            reserva.sala = int.Parse(Console.ReadLine());
            reserva.fecha = DateTime.Now.ToString("dd/MM/yyyy");
            reserva.id = servicioReserva.ObtenerId();

            if (reserva.solicitante == "" || reserva.sala <= 0)
            {
                Console.WriteLine("Error, datos invalidos");
                Console.ReadKey();
                return;
            }

            var mensaje = servicioReserva.Agregar(reserva);
            Console.WriteLine(mensaje);    

            Console.ReadKey();
        }

        private void ListarReservas()
        {
            Console.Clear();
            int salto = 0;
            Console.Clear();
            Console.SetCursorPosition(19, 3); Console.WriteLine("L I S T A D O  D E  R E S E R V A S");
            Console.SetCursorPosition(15, 5); Console.Write("------------------------------------------------");
            Console.SetCursorPosition(15, 6); Console.WriteLine("ID");
            Console.SetCursorPosition(28, 6); Console.WriteLine("SOLICITANTE");
            Console.SetCursorPosition(44, 6); Console.WriteLine("SALA");
            Console.SetCursorPosition(52, 6); Console.WriteLine("FECHA");
            var lista = servicioReserva.ObtenerTodas();
            if (lista == null)
            {
                Console.Clear();
                Console.SetCursorPosition(15, 8 + salto); Console.Write("no hay reservas aún");
                Console.ReadKey();
                return;
            }
            foreach (var item in lista)
            {
                Console.SetCursorPosition(15, 8 + salto); Console.Write(item.id);
                Console.SetCursorPosition(28, 8 + salto); Console.Write(item.solicitante);
                Console.SetCursorPosition(44, 8 + salto); Console.Write(item.sala);
                Console.SetCursorPosition(52, 8 + salto); Console.Write(item.fecha);
                Console.SetCursorPosition(15, 9 + salto); Console.Write("------------------------------------------------");
                salto=salto+2;
            }
            Console.ReadKey();
        }
    }
}
