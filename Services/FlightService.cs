using ConsoleApp1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    internal class FlightService
    {
        public FlightRepo FlightRepo;
        public PlaneRepo PlaneRepo;
        public FlightService(FlightRepo flightRepo, PlaneRepo planeRepo) 
        {
            this.FlightRepo = flightRepo;
            this.PlaneRepo = planeRepo;
        }
        public void ShowAllFlights()
        {
            var flights = FlightRepo.GetAllFlights();
            foreach (var flight in flights)
            {
                Console.WriteLine(flight.ToString());
            }

        }
        public void AddFlight(string origin, string destination, DateTime departureDate, DateTime arrivalDate, TimeSpan travelTime, Guid planeId)
        {
            var plane = PlaneRepo.GetPlaneById(planeId);
            var flight = new Flight(origin, destination, departureDate, arrivalDate,travelTime, plane);
            FlightRepo.AddFlight(flight);
            PlaneRepo.AddFlightToPlane(planeId, flight.getId());
        }

        public void RemoveFlight(Guid id)
        {
            var flight = FlightRepo.GetFlightById(id);
            if (flight.getAvailableSeats() == flight.getTotalSeats() / 2)
            {
                throw new Exception("Cannot remove flight with booked seats.");
            }
            else if(flight.getDepartureDate() != DateTime.Now)
            {
                throw new Exception("Cannot remove flight that has already departed.");
            }

            FlightRepo.RemoveFlight(flight);
        }

        public string SearchFlightById(Guid id)
        {
            var flight = FlightRepo.GetFlightById(id);
            return flight.ToString();
        }

        public string SearchFlightByName(string name)
        {
            var flight = FlightRepo.GetFlightByName(name);
            return flight.ToString();
        }

        public void UpdateFlight(DateTime departureDate, DateTime arrivalDate, Guid id)
        {
            FlightRepo.UpdateFlight(departureDate, arrivalDate, id);
        }

        public List<Flight> GetAvailableFlights()
        {
            return FlightRepo.GetAvailableFlights();
        }
        public Flight BookingFlight(Guid id)
        {
            var flight = FlightRepo.GetFlightById(id);
            var newAvailableSeats = flight.getAvailableSeats() - 1;
            FlightRepo.UpdateAvailableSeats(id, newAvailableSeats);
            return flight;
        }



    }
}
