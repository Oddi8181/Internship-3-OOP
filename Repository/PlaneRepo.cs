using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repository
{
    internal class PlaneRepo
    {
        private List<Plane> planes;
        public PlaneRepo()
        {
            planes = new List<Plane>();

            planes.Add( new Plane("Boeing 737",new DateTime(2001), 180));
            planes.Add(new Plane("Airbus A380",new DateTime(2005), 220));

           
        }
        public void AddPlane(Plane plane)
        {
            planes.Add(plane);
        }
        public Plane GetPlaneById(Guid id)
        {
            return planes.FirstOrDefault(p => p.getId() == id);
        }
        public Plane GetPlaneByName(string name)
        {
            return planes.FirstOrDefault(p => p.getName() == name);
        }
        public List<Plane> GetAllPlanes()
        {
            return planes;
        }

        public void RemovePlane(Guid id)
        {
            var plane = GetPlaneById(id);
            if (plane != null)
            {
                planes.Remove(plane);
            }
        }
        public void AddFlightToPlane(Guid planeId, Guid flightId)
        {
            var plane = GetPlaneById(planeId);
            if (plane != null)
            {
                plane.FlightIds.Add(flightId);
                plane.setNumberOfFlights(plane.getNumberOfFlights() + 1);
            }
        }



    }
}
