using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    internal class FlightRepo
    {
       
        public readonly List<Flight> _flights;
        private readonly PlaneRepo _planeRepo;

        public FlightRepo(PlaneRepo planeRepo)
        {
            _flights = new List<Flight>();
            _planeRepo = planeRepo;

            var plane1 = _planeRepo.GetPlaneByName("Boeing 737");
            var plane2 = _planeRepo.GetPlaneByName("Airbus A380");

            _flights.Add(new Flight("Zagreb", "Split", new DateTime(2025, 11, 29), new DateTime(2025, 11, 30),TimeSpan.FromHours(0.5), plane1));
            _flights.Add(new Flight("Split", "Berlin", new DateTime(2025, 12, 20), new DateTime(2025, 12, 21),TimeSpan.FromHours(1.5), plane2));
        }
        public void AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }
        public int countOfBookedSeats(Guid flightId)
        {
            var flight = GetFlightById(flightId);
            return flight.getTotalSeats() - flight.getAvailableSeats();
        }
        public List<Flight> GetAllFlights()
        {
            return _flights;
        }

        public Flight GetFlightById(Guid id)
        {
            return _flights.FirstOrDefault(f => f.getId() == id);
        }
        public Flight GetFlightByName(string name)
        {
            return _flights.FirstOrDefault(f => f.getName() == name);
        }

        public void RemoveFlight(Flight flight)
        {
            _flights.Remove(flight);
        }

        public List<Flight> GetAvailableFlights()
        {
            return _flights.Where(f => f.getAvailableSeats() > 0).ToList();
        }

        public void UpdateFlight(DateTime departureDate, DateTime arrivalDate, Guid id)
        {
            var flight = GetFlightById(id);
            flight.setDepartureDate(departureDate);
            flight.setArrivalDate(arrivalDate);
            flight.setCreationDate(DateTime.Now);
        }

        public void UpdateAvailableSeats(Guid id, int newSeatCount)
        {
            var flight = GetFlightById(id);
            flight.setAvailableSeats(newSeatCount);
        }
        public void AddCrewToFlight(Flight flight, Guid crewId)
        {
            flight.setCrewId(crewId);
        }

    }
}
