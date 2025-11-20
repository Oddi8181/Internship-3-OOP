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

    }
}
