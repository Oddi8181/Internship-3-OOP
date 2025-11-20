using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Plane
    {
        Guid id;
        string Name;
        DateTime YearOfProduction;
        int NumberOfFlights;
        int Capacity;

        public Plane(string name, DateTime yearOfProduction, int numberOfFlights, int capacity)
        {
            id = new Guid();
            Name = name;
            YearOfProduction = yearOfProduction;
            NumberOfFlights = numberOfFlights;
            Capacity = capacity;
        }

        public Guid getId() { return id; }
        public string getName() { return Name; }
        public DateTime getYearOfProduction() { return YearOfProduction; }
        public int getNumberOfFlights() { return NumberOfFlights; }
        public int getCapacity() { return Capacity; }

        public void setName(string name) { Name = name; }
        public void setYearOfProduction(DateTime yearOfProduction) { YearOfProduction = yearOfProduction; }
        public void setNumberOfFlights(int numberOfFlights) { NumberOfFlights = numberOfFlights; }
        public void setCapacity(int capacity) { Capacity = capacity; }


        public override string ToString()
        {
            return $"Plane ID: {id}, Name: {Name}, Year Of Production: {YearOfProduction.ToShortDateString()}, Number Of Flights: {NumberOfFlights}";
        }



    }
}
