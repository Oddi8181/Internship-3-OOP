using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Menus
{
    internal class PlaneMenu
    {
        public PlaneService _planeService;
        public PlaneMenu(PlaneService planeService) 
        { 
            this._planeService = planeService;
        }
        public void ShowPlanes()
        {
            Console.WriteLine("PRIKAZ SVIH AVIONA");
            _planeService.ShowAllPlanes();
        }


        public void AddPlane()
        {
            Console.WriteLine("Unesi ime aviona: ");
            var name = Console.ReadLine();
            Console.WriteLine("Unesi godinu proizvodnje aviona: ");
            var yearOfProduction = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesi broj letova aviona: ");
            var numberOfFlights = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesi kapacitet aviona: ");
            var capacity = int.Parse(Console.ReadLine());
            _planeService.AddPlane(name, yearOfProduction, numberOfFlights, capacity);
        }
        public void SearchPlane()
        {
            Console.WriteLine("Pretraga aviona:");
            Console.WriteLine("1 - Pretraga po ID-u");
            Console.WriteLine("2 - Pretraga po imenu");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Unesi ID aviona za pretragu: ");
                    var id = Guid.Parse(Console.ReadLine());
                    _planeService.SearchPlaneById(id);
                    break;
                case "2":
                    Console.WriteLine("Unesi ime aviona za pretragu: ");
                    var name = Console.ReadLine();
                    _planeService.SearchPlaneByName(name);
                    break;
            }
        }

        public void DeletePlane()
        {
            Console.WriteLine("Brisanje aviona:");
            Console.WriteLine("1 - Brisanje po ID-u");
            Console.WriteLine("2 - Brisanje po imenu");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Unesi ID aviona za brisanje: ");
                    var id = Guid.Parse(Console.ReadLine());
                    _planeService.RemovePlaneById(id);
                    break;
                case "2":
                    Console.WriteLine("Unesi ime aviona za brisanje: ");
                    var name = Console.ReadLine();
                    _planeService.RemovePlaneByName(name);
                    break;
            }
        }
        public void ShowPlanesMenu()
        {
            Console.WriteLine("----AVION MENI----");

            Console.WriteLine("1 - Prikaz svih aviona");
            Console.WriteLine("2 - Dodaj novi avion");
            Console.WriteLine("3 - Pretraga aviona");
            Console.WriteLine("4 - Brisanje aviona");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowPlanes();
                    break;
                case "2":
                    AddPlane();
                    break;
                case "3":
                    SearchPlane();
                    break;
                case "4":
                    DeletePlane();
                    break;
            }

        }
    }
}
