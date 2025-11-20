using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    internal class FlightRepo
    {
       
        public readonly List<Flight> _flights = new List<Flight>();
        public FlightRepo() { }

        public void AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }

        public List<Flight> GetAllFlights()
        {
            return _flights;
        }

        public Flight GetFlightById(Guid id)
        {
            return _flights.FirstOrDefault(f => f.getId() == id);
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
        public Flight GetFlightByName(string name)
        {
            return _flights.FirstOrDefault(f => f.getName() == name);
        }


    }
}
