using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices.ConsoleClient.AsmxPlayerServiceReference;
using WebServices.ConsoleClient.WCFPlayerServiceReference;

namespace WebServices.ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Primero agregamos la referencia al servicio ASMX
            //Luego se invoca el servicio ASMX
            PlayerWebServiceSoapClient asmxClient = new PlayerWebServiceSoapClient();

            //Segundo agregamos la referencia al servicio WCF
            //Luego se invoca al servicio WCF
            Service1Client wcfClient = new Service1Client();

            string optionCode;

            do
            {
                //Mostrar menú de opciones
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("---          MENÚ: OPCIONES           ---");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Elija una opción:\n 1) Agregar Jugador/a \n 2) Editar Jugador/a \n 3) Eliminar Jugador/a \n 4) Mostrar Jugadores/as");
                Console.Write("opción: ");
                optionCode = Console.ReadLine();

                if (optionCode == "1")
                {
                    //Agregar un jugador
                    AddPlayer(asmxClient);
                }
                else if (optionCode == "2")
                {
                    //Editar un jugador
                    EditPlayer(wcfClient);
                }
                else if (optionCode == "3")
                {
                    //Eliminar un jugador
                    DeletePlayer(wcfClient);
                }
                else if (optionCode == "4")
                {
                    //Mostrar los jugadores
                    ShowPlayers(asmxClient);
                }
                else { Console.WriteLine("Opción Inválida, seleccione otra vez."); }

                Console.WriteLine("\nPara salir, ingrese 'S', para continuar ingrese 'C'");
                optionCode = Console.ReadLine();
            } while (!optionCode.ToUpper().Equals("S"));

        }

        public static void AddPlayer(PlayerWebServiceSoapClient asmxClient)
        {
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

            asmxClient.AddPlayer(fname, lname, validDate, origin, genre, clubnow);
            Console.Write("\nJugador/a agregado/a!\n");
        }

        public static void EditPlayer(Service1Client wfcService)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("---   AGREGUE UN JUGADOR DE FÚTBOL    ---");
            Console.WriteLine("-----------------------------------------");

            Console.Write("Ingrese el id del jugador/a a editar:");
            int idSelected = Int32.Parse(Console.ReadLine());

            WCFPlayerServiceReference.Player player = wfcService.GetPlayer(idSelected);

            Console.Write($"Nombre: {player.FirstName}. Ingrese nuevo nombre: ");
            var fname = Console.ReadLine();
            Console.Write($"Apellido: {player.LastName}. INgrese nuevo apellido: ");
            var lname = Console.ReadLine();
            Console.Write($"Nacionalidad: {player.Nationality}. Ingrese nueva nacionalidad: ");
            var origin = Console.ReadLine();
            Console.Write($"Fecha de nacimiento: {player.BirthDate}. Ingrese nueva Fecha de nacimiento en formato dd/mm/aaaa: ");
            var birth = Console.ReadLine();
            DateTime validDate = DateTime.ParseExact(birth, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write($"Club en donde juega actualmente: {player.ActualClub}. Ingrese nuevo club: ");
            var clubnow = Console.ReadLine();
            Console.Write($"Género: {player.Genre}. Ingrese nuevo género: ");
            var genre = Console.ReadLine();

            wfcService.UpdatePlayer(idSelected, fname, lname, validDate, origin, genre, clubnow);
            Console.Write("\nJugador/a actualizado/a!\n");
        }

        public static void ShowPlayers(PlayerWebServiceSoapClient asmxService)
        {
            var players = asmxService.GetPlayers();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("---    LISTADO JUGADORES DE FÚTBOL    ---");
            Console.WriteLine("-----------------------------------------");

            foreach (AsmxPlayerServiceReference.Player player in players)
            {
                Console.WriteLine($"Jugador/a: ID {player.Id} - {player.FirstName} {player.LastName}");
            }
        }

        public static void DeletePlayer(Service1Client wcfService)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("---   ELIMINE UN JUGADOR DE FÚTBOL    ---");
            Console.WriteLine("-----------------------------------------");

            Console.Write("Ingrese el id del jugador/a a eliminar: ");
            int idSelected = Int32.Parse(Console.ReadLine());

            wcfService.DeletePlayer(idSelected);
            Console.Write("\nJugador/a eliminado/a!\n");
        }
    }
}
