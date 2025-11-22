using AirportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Repository
{
    internal class PassengerRepo
    {
        public readonly List<Passenger> _passengers;
        public PassengerRepo()
        {
            _passengers = new List<Passenger>();

            
            _passengers.Add(new Passenger("Marko", "Marić", new DateTime(1998, 2, 5), "marko@mail.com", "pass123"));
            _passengers.Add(new Passenger("Ana", "Anić", new DateTime(2000, 1, 10), "ana@mail.com", "lozinka"));
            _passengers.Add(new Passenger("Ivan", "Ivić", new DateTime(1995, 5, 20), "ivan@mail.com", "test321"));
        }

        public void AddPassenger(Passenger passenger)
        {
            _passengers.Add(passenger);
        }
        public void RemovePassenger(Passenger passenger)
        {
            _passengers.Remove(passenger);
        }

        public List<Passenger> GetAllPassengers()
        {
            return _passengers;
        }

        public Passenger GetPassengerByEmail(string email)
        {
            return _passengers.FirstOrDefault(p => p.getEmail() == email);
        }

        public void AddFlightToPassenger(Passenger passenger, Guid flightId)
        {
            passenger.FligtIds.Add(flightId);

        }
        public void RemoveFlightFromPassenger(Passenger passenger, Guid flightId)
        {
            passenger.FligtIds.Remove(flightId);
        }


    }
}
