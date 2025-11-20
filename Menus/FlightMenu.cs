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
            var travelTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesi ukupan broj sjedala");
            var totalSeats = int.Parse(Console.ReadLine());

            FlightService.AddFlight(origin, destination, departureDate, arrivalDate, travelTime, totalSeats);
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
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
            }

        }


    }
}
