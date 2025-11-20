using ConsoleApp1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1.Services
{
    internal class PlaneService
    {
        public PlaneRepo PlaneRepo;
        public PlaneService(PlaneRepo planeRepo)
        {
            this.PlaneRepo = planeRepo;
        }
        public void ShowAllPlanes()
        {
            var planes = PlaneRepo.GetAllPlanes();
            foreach (var plane in planes)
            {
                Console.WriteLine(plane.ToString());
            }
        }
        public void AddPlane(string name, DateTime yearOfProduction, int numberOfFlights, int capacity)
        {
            var plane = new Plane(name, yearOfProduction, numberOfFlights, capacity);
            PlaneRepo.AddPlane(plane);
        }

        public void SearchPlaneById(Guid id)
        {
            var plane = PlaneRepo.GetPlaneById(id);
            if (plane != null)
            {
                Console.WriteLine(plane.ToString());
            }
        }
        public void SearchPlaneByName(string name)
        {
            var plane = PlaneRepo.GetPlaneByName(name);
            if (plane != null)
            {
                Console.WriteLine(plane.ToString());
            }
        }

        public void RemovePlaneById(Guid id)
        {
            var plane = PlaneRepo.GetPlaneById(id);
            PlaneRepo.RemovePlane(id);
        }

        public void RemovePlaneByName(string name)
        {
            var plane = PlaneRepo.GetPlaneByName(name);
            if (plane != null)
            {
                PlaneRepo.RemovePlane(plane.getId());
            }
        }

    }
}
