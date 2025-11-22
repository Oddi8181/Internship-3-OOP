using AirportApp.Menus;
using AirportApp.Repository;
using AirportApp.Services;
using ConsoleApp1.Menus;
using ConsoleApp1.Repository;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Run
    {
        public bool exit = false;
        readonly CrewRepo _crewRepo;
        readonly PlaneRepo _planeRepo;
        readonly FlightRepo _flightRepo;
        readonly PassengerRepo _passengerRepo;

        readonly CrewService _crewService;
        readonly PlaneService _planeService;
        readonly FlightService _flightService;
        readonly PassengerService _passengerService;

        readonly PassengerMenu _passengerMenu;
        readonly FlightMenu _flightMenu;
        readonly PlaneMenu _planeMenu;
        readonly CrewMenu _crewMenu;

        public Run()
        {
            _crewRepo = new CrewRepo();
            _planeRepo = new PlaneRepo();
            _flightRepo = new FlightRepo(_planeRepo);
            _passengerRepo = new PassengerRepo();

            _crewService = new CrewService(_crewRepo, _flightRepo);
            _planeService = new PlaneService(_planeRepo);
            _flightService = new FlightService(_flightRepo, _planeRepo);
            _passengerService = new PassengerService(_passengerRepo);

            _passengerMenu = new PassengerMenu(_passengerService, _flightService);
            _flightMenu = new FlightMenu(_flightService);
            _planeMenu = new PlaneMenu(_planeService);
            _crewMenu = new CrewMenu(_crewService, _flightService);
        }


        public void MainMenu()
        {
            do
            {
                Console.WriteLine("---- AERODORM APLIKACIJA ----");
                Console.WriteLine("1 - Putnici");
                Console.WriteLine("2 - Letovi");
                Console.WriteLine("3 - Avioni");
                Console.WriteLine("4 - Posada");
                Console.WriteLine("0 - Izlaz iz programa");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                       _passengerMenu.ShowPassengerMenu();
                        break;
                    case "2":
                        _flightMenu.ShowFlightsMenu();
                        break;
                    case "3":
                        _planeMenu.ShowPlanesMenu();
                        break;
                    case "4":
                        _crewMenu.ShowCrewMenu();
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
            while (!exit);
        }
    }
}
