using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Menus
{
    internal class CrewMenu
    {
        public CrewService service;
        public FlightService flightService;
        public CrewMenu(CrewService crewService, FlightService flightService)
        {
            service = crewService;
            this.flightService = flightService;
        }

        public void CreateCrewMenu()
        {
            Console.WriteLine("---- KREIRANJE NOVE POSADE ----");
            service.NotAssignedCrewMembers();
            Console.WriteLine("Unesite ID pilota:");
            var pilotId = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Unesite ID kopilota:");
            var copilotId = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Unesite ID stjuardese 1:");
            var attendant1Id = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Unesite ID stjuardese 2:");
            var attendant2Id = Guid.Parse(Console.ReadLine());  
            flightService.ShowAllFlights();
            Console.WriteLine("Unesite ID leta za koji kreirate posadu:");
            var flightId = Guid.Parse(Console.ReadLine());

            service.CreateCrew(pilotId, copilotId, attendant1Id, attendant2Id, flightId);
        }
        public void AddCrewMemberMenu()
        {
            Console.WriteLine("---- DODAVANJE OSOBE U POSADU ----");
            Console.WriteLine("Unesi ime osobe");
            var name = Console.ReadLine();
            Console.WriteLine("Unesi prezime osobe");
            var surname = Console.ReadLine();
            Console.WriteLine("Unesi ulogu osobe (Pilot, CoPilot, FlightAttendant):");
            var roleInput = Console.ReadLine();
            CrewRole role;
            if (!Enum.TryParse(roleInput, out role))
            {
                Console.WriteLine("Neispravna uloga. Molimo pokušajte ponovno.");
                return;
            }
            Console.WriteLine("Unesi datum rođenja osobe (yyyy-MM-dd):");
            var dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesi spol osobe(male, female, other): ");
            var genderInput = Console.ReadLine();
            Gender gender;
            if (!Enum.TryParse(genderInput, true, out gender))
            {
                Console.WriteLine("Neispravan spol. Molimo pokušajte ponovno.");
                return;
            }
            service.AddCrewMember(name, surname, role, dateOfBirth, gender);
            Console.WriteLine("Nova osoba dodana!");

            
        }
        public void ShowCrewMenu()
        {
            Console.WriteLine("---- MENI POSADE ----");
            Console.WriteLine("1 - Prikazi sve posade");
            Console.WriteLine("2 - Kreiranje nove posade");
            Console.WriteLine("3 - Dodavanje osobe");
            Console.WriteLine("4 - Povratak na glavni meni");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    service.ShowAllCrews();
                    break;
                case "2":
                    CreateCrewMenu();
                    break;
                case "3":
                    AddCrewMemberMenu();
                    break; 
                case "4":
                    break;
            }

        }
    }
}
