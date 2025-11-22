using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Menus
{
    internal class FlightMenu
    {
        public FlightService FlightService;
        public FlightMenu(FlightService flightService)
        {
            FlightService = flightService;
        }
        public void ShowAllFlights()
        {
            Console.WriteLine("PRIKAZ SVIH LETOVA");
            FlightService.ShowAllFlights();
        }

        public void SearchFlightById()
        {
            Console.WriteLine("Unesi ID leta za pretragu: ");
            var id = Guid.Parse(Console.ReadLine());
            var flight = FlightService.SearchFlightById(id);
            Console.WriteLine(flight);
        }
        public void SearchFlight()
        {
            Console.WriteLine("Pretraga letova:");
            Console.WriteLine("1 - Pretraga po ID-u");
            Console.WriteLine("2 - Pretraga po imenu");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SearchFlightById();
                    break;
                case "2":
                    SearchFlightByName();
                    break;
            }
        }
        public void SearchFlightByName()
        {
            Console.WriteLine("Unesi ime leta za pretragu: ");
            var name = Console.ReadLine();
            var flight = FlightService.SearchFlightByName(name);
            Console.WriteLine(flight);
        }
        public void EditFlight()
        {
            Console.WriteLine("Unesi ID leta za uređivanje: ");
            var id = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Unesi novi datum polaska: ");
            var departureDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesi novi datum dolaska: ");
            var arrivalDate = DateTime.Parse(Console.ReadLine());
            FlightService.UpdateFlight(departureDate, arrivalDate, id);
        }

        public void DeleteFlight()
        {
            Console.WriteLine("Unesi ID leta za brisanje: ");
            var id = Guid.Parse(Console.ReadLine());
            FlightService.RemoveFlight(id);
        }

        public void AddFlight()
        {
            Console.WriteLine("Unesi mjesto poljetanja: ");
            var origin = Console.ReadLine();
            Console.WriteLine("Unesi mjesto dolaska: ");
            var destination = Console.ReadLine();
            Console.WriteLine("Unesi datum polaska");
            var departureDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesi datum dolaska");
            var arrivalDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesi vrijeme putovanja");
            var travelTime = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("Unesi unesi id aviona");
            var planeId = Guid.Parse(Console.ReadLine());

            FlightService.AddFlight(origin, destination, departureDate, arrivalDate, travelTime, planeId);
        }
        public void ShowFlightsMenu()
        {
            Console.WriteLine("LETOVI");
            Console.WriteLine("1 - Prikaz svih letova");
            Console.WriteLine("2 - Dodavanje leta");
            Console.WriteLine("3 - Pretraživanje letova");
            Console.WriteLine("4 - Uređivanje leta");
            Console.WriteLine("5 - Brisanje leta");
            Console.WriteLine("6 - Povratak na izbornik");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllFlights();
                    break;
                case "2":
                    AddFlight();
                    break;
                case "3":
                    SearchFlight();
                    break;
                case "4":
                    EditFlight();
                    break;
                case "5":
                    DeleteFlight();
                    break;
                case "6":
                    break;
            }

        }


    }
}
