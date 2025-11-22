using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Flight
    {
        Guid Id { get; }
        string Origin { get; set; }
        string Destination { get; set; }
        string Name { get; set; }
        DateTime DepartureDate { get; set; }
        DateTime ArrivalDate { get; set; }

        TimeSpan TravelTime { get; set; }
        int AvailableSeats { get; set; }
        int TotalSeats { get; set; }
        Guid CrewId { get; set; }
        DateTime CreationDate { get; set; }
        public Plane Plane { get; set; }
        public List<Guid> PassengerIds { get; }
        
        public FlightCategory FlightCategory { get; set; }

        



        public Flight(string origin, string destination, DateTime departureDate, DateTime arrivalDate, TimeSpan travelTime, Plane plane)
        {
            Id = Guid.NewGuid();
            Origin = origin;
            Destination = destination;
            Name = "Let u" + destination;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            TravelTime = travelTime;
            TotalSeats = plane.getCapacity();
            PassengerIds = new List<Guid>();
            AvailableSeats = TotalSeats - countOfBookedSeats();
            CreationDate = DateTime.Now;
            Plane = plane;
            
        }
        public Guid getId() { return Id; }
        public string getOrigin() { return Origin; }
        public string getDestination() { return Destination; }
        public string getName() { return Name; }
        public DateTime getDepartureDate() { return DepartureDate; }
        public DateTime getArrivalDate() { return ArrivalDate; }
        public TimeSpan getTravelTime() { return TravelTime; }
        public int getAvailableSeats() { return AvailableSeats; }
        public int getTotalSeats() { return TotalSeats; }
        public Guid getCrewId() { return CrewId; }
        public void setAvailableSeats(int seats) { AvailableSeats = seats; }
        public void setTotalSeats(int seats) { TotalSeats = seats; }

        public void setOrigin(string origin) { Origin = origin; }
        public void setDestination(string destination) { Destination = destination; }
        public void setDepartureDate(DateTime departureDate) { DepartureDate = departureDate; }
        public void setArrivalDate(DateTime arrivalDate) { ArrivalDate = arrivalDate; }
        public void setTravelTime(TimeSpan travelTime) { TravelTime = travelTime; }
        public void setCrewId(Guid crewId) { CrewId = crewId; }

        public DateTime getCreationDate() { return CreationDate; }
        public void setCreationDate(DateTime creationDate) { CreationDate = creationDate; }



        public override string ToString()
        {
            return $"Flight ID: {Id}, Naziv: {Name}, Datum polaska: {DepartureDate}, Datum dolaska: {ArrivalDate}, Vrijeme putovanja: {TravelTime}";
        }
        public int countOfBookedSeats()
        {
            int cnt = PassengerIds.Count;
            
            return cnt;
        }
    }
}
