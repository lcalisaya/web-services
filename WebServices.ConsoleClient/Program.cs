using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices.ConsoleClient.AsmxPlayerServiceReference;

namespace WebServices.ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Primero agregamos la referencia al servicio ASMX
            //Luego se invoca el servicio ASMX
            PlayerWebServiceSoapClient client = new PlayerWebServiceSoapClient();
            string exitCode;

            do
            {
                //Agregar un jugador
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("---   AGREGUE UN JUGADOR DE FÚTBOL    ---");
                Console.WriteLine("-----------------------------------------");

                Console.Write("Nombre: ");
                var fname = Console.ReadLine();
                Console.Write("Apellido: ");
                var lname = Console.ReadLine();
                Console.Write("Nacionalidad: ");
                var origin = Console.ReadLine();
                Console.Write("Fecha de nacimiento en formato dd/mm/aaaa: ");
                var birth = Console.ReadLine();
                DateTime validDate = DateTime.ParseExact(birth, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Club en donde juega actualmente: ");
                var clubnow = Console.ReadLine();
                Console.Write("Género: ");
                var genre = Console.ReadLine();

                client.AddPlayer(fname, lname, validDate, origin, genre, clubnow);
                Console.Write("\nJugador/a agregado/a!\n");

                //Mostrar los jugadores
                var players = client.GetPlayers();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("---    LISTADO JUGADORES DE FÚTBOL    ---");
                Console.WriteLine("-----------------------------------------");

                foreach (Player player in players)
                {
                    Console.WriteLine($"Jugador/a: {player.FirstName} {player.LastName}");
                }
         
                Console.WriteLine("\nPara salir, ingrese 'S', para continuar ingrese 'C'");
                exitCode = Console.ReadLine();
            } while (!exitCode.ToUpper().Equals("S"));

        }
    }
}
