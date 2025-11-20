using AirportApp.Models;
using AirportApp.Services;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Menus
{
    internal class PassengerMenu
    {
        public static PassengerService _passengerService;
        public static FlightService _flightService;

        public PassengerMenu(PassengerService passengerService, FlightService flightService) 
        {
            _passengerService = passengerService;
            _flightService = flightService;
        }

        public static Passenger LoginMenu()
        {
            Console.WriteLine("----- PRIJAVA KORISNIKA -----");
            Console.Write("Unesite e-mail: ");
            string email = Console.ReadLine();
            Console.Write("Unesite lozinku: ");
            string password = Console.ReadLine();
            var passenger = _passengerService.LoginPassenger(email, password);
            if (passenger == null)
            {
                Console.WriteLine("Neispravan e-mail ili lozinka. Pokušajte ponovno.");
               return null;
            }
            return passenger;
            
        }
        public static void RegistrationMenu()
        {
            Console.WriteLine("----- REGISTRACIJA KORISNIKA -----");
            Console.Write("Unesite ime: ");
            string name = Console.ReadLine();
            Console.Write("Unesite prezime: ");
            string surname = Console.ReadLine();
            Console.Write("Unesite datum rođenja (dd.MM.yyyy): ");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.Write("Neispravan format datuma. Molimo unesite datum rođenja (dd.MM.yyyy): ");
            }
            Console.Write("Unesite e-mail: ");
            string email = Console.ReadLine();
            Console.Write("Unesite lozinku: ");
            string password = Console.ReadLine();
           
            _passengerService.RegisterPassenger(name, surname, dateOfBirth, email, password);
        }
        public static void ChooseFlightMenu(Passenger passenger)
        {
            Console.WriteLine("----- ODABIR LETA -----");
            foreach(var fight in freeFlights)
            {
                Console.WriteLine(flight);
            }
            Console.Write("Unesite ID leta koji želite odabrati: ");
            Guid flightId;
            while (!Guid.TryParse(Console.ReadLine(), out flightId))
            {
                Console.Write("Neispravan format ID-a. Molimo unesite ispravan ID leta: ");
            }
            _passengerService.ChooseFlight(passenger, flightId);
        }
        public void ViewMyFlightsMenu(Passenger passenger)
        {
            Console.WriteLine("----- MOJI LETOVI -----");
            var myFlights = _passengerService.GetPassengerFlights(passenger);
            if (myFlights.Count == 0)
            {
                Console.WriteLine("Nemate odabranih letova.");
                return;
            }
            foreach (var flight in myFlights)
            {
                Console.WriteLine(flight);
            }
        }

        public void CancelFlightMenu(Passenger passenger)
        {
            Console.WriteLine("----- OTKAZIVANJE LETA -----");
            var myFlights = _passengerService.GetPassengerFlights(passenger);
            if (myFlights.Count == 0)
            {
                Console.WriteLine("Nemate odabranih letova za otkazivanje.");
                return;
            }
            foreach (var flight in myFlights)
            {
                Console.WriteLine(flight);
            }
            Console.Write("Unesite ID leta koji želite otkazati: ");
            Guid flightId;
            while (!Guid.TryParse(Console.ReadLine(), out flightId))
            {
                Console.Write("Neispravan format ID-a. Molimo unesite ispravan ID leta: ");
            }
            _passengerService.CancelFlight(passenger, flightId);
        }
        public void SearchFlightsMenu()
        {
            Console.WriteLine("----- PRETRAŽIVANJE LETOVA -----");
            Console.WriteLine("a) Po id-u");
            Console.WriteLine("b) Po nazivu");
            Console.Write("Odaberite opciju pretraživanja: ");
            var choice = Console.ReadLine();
            switch (choice) { 
                case "a":
                    Console.Write("Unesite ID leta: ");
                    Guid flightId;
                    while (!Guid.TryParse(Console.ReadLine(), out flightId))
                    {
                        Console.Write("Neispravan format ID-a. Molimo unesite ispravan ID leta: ");
                    }
                    var flightById = _flightService.SearchFlightById(flightId);
                    if (flightById != null)
                    {
                        Console.WriteLine(flightById);
                    }
                    else
                    {
                        Console.WriteLine("Let s tim ID-om nije pronađen.");
                    }
                    break;
                case "b":

            }
        }
        public void ShowPassengerSubMenu(Passenger passenger)
        {
            Console.WriteLine("----- KORISNIČKI PODIZBORNIK -----");
            Console.WriteLine("1 - Pregled mojih letova");
            Console.WriteLine("2 - Odabir leta");
            Console.WriteLine("3 - Pretraživanje letova");
            Console.WriteLine("4 - Otkazivanje letova");
            Console.WriteLine("5 - Povratak na prethodni izbornik");

            Console.Write("Odaberite opciju: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Pregled mojih letova odabran.");
                    ViewMyFlightsMenu(passenger);
                    break;
                case "2":
                    Console.WriteLine("Odabir leta odabran.");
                    ChooseFlightMenu(passenger);
                    break;
                case "3":
                    Console.WriteLine("Pretraživanje letova odabrano");
                    SearchFlightsMenu();
                    break;
                case "4":
                    Console.WriteLine("Otkazivanje letova odabrano.");
                    CancelFlightMenu(passenger);
                    break;
                case "5":
                    Console.WriteLine("Povratak na prethodni izbornik.");
                    break;
            }

        }
        public void ShowPassengerMenu()
        {
            Console.WriteLine("----- KORISNIČKI MENI -----");
            Console.WriteLine("1 - Registracija");
            Console.WriteLine("2 - Prijava");
            Console.WriteLine("3 - Povratak na prethodni izbornik");
            Console.Write("Odaberite opciju: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    
                    Console.WriteLine("Registracija odabrana.");
                    RegistrationMenu();
                    break;
                case "2":
                    
                    Console.WriteLine("Prijava odabrana.");
                    var loggedInPassenger = LoginMenu();
                    if (loggedInPassenger != null)
                    {
                        Console.WriteLine("Dobrodošli u sustav!");
                        ShowPassengerSubMenu(loggedInPassenger);
                    }
                    break;
                case "3":
                    
                    Console.WriteLine("Povratak na prethodni izbornik.");
                    break;
                default:
                    Console.WriteLine("Nevažeći odabir. Molimo pokušajte ponovno.");
                    break;
            }
        }
    }
}
