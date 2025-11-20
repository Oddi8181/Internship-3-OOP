using AirportApp.Models;
using AirportApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Services
{
    internal class PassengerService
    {
        public PassengerRepo _passenger = new PassengerRepo();
        public PassengerService(PassengerRepo passengerRepo)
        {
            _passenger = passengerRepo;
        }

        public void RegisterPassenger(string name, string surname, DateTime dateOfBirth, string email, string password)
        {
            if (_passenger.GetPassengerByEmail(email) != null)
            {
                Console.WriteLine("Korisnik s ovim e-mailom već postoji! Molimo vas da probate s drugim e-mailom.");
                return;
            }
            Passenger newPassenger = new Passenger(name, surname, dateOfBirth, email, password);
            _passenger.AddPassenger(newPassenger);
        }


        public Passenger LoginPassenger(string email, string password)
        {
            if (_passenger.GetAllPassengers().Count == 0)
            {
                Console.WriteLine("Nema korisnika, molimo vas da se prvo registrirate!");
                return null;
            }

            if (_passenger.GetPassengerByEmail(email) == null)
            {
                Console.WriteLine("Korisnik s tim e-mailom ne postoji!");
                return null;
            }

            Passenger passenger = _passenger.GetPassengerByEmail(email);
            if (passenger.getPassword() != password)
            {
                Console.WriteLine("Pogrešna lozinka, molimo pokušajte ponovno!");
                return null;
            }
            Console.WriteLine("Uspješno ste prijavljeni!");
            return passenger;
        }

        public Passenger LogoutPassenger() { Console.WriteLine("Uspješno ste odjavljeni!"); return null; }

        public void ChooseFlight(Passenger passenger, Guid flightId)
        {
            if (passenger == null)
            {
                Console.WriteLine("Morate biti prijavljeni da biste odabrali let.");
                return;
            }
            _passenger.AddFlightToPassenger(passenger, flightId);
        }

        public List<Guid> GetPassengerFlights(Passenger passenger)
        {
            return passenger.FligtIds;
        }

        public void CancelFlight(Passenger passenger, Guid flightId)
        {
            if (passenger == null)
            {
                Console.WriteLine("Morate biti prijavljeni da biste otkazali let.");
                return;
            }
        
            _passenger.RemoveFlightFromPassenger(passenger, flightId);
        }

        
    }
}
