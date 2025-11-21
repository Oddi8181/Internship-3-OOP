using ConsoleApp1.Models;
using ConsoleApp1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    internal class CrewService
    {
        public CrewRepo _crewRepo;
        public FlightRepo _flightRepo;
        public CrewService(CrewRepo crewRepo, FlightRepo flightRepo)
        {
            _crewRepo = crewRepo;
            _flightRepo = flightRepo;
        }

        public void ShowAllCrews()
        {
            var crews = _crewRepo.GetAllCrews();
            foreach (var crew in crews)
            {
                Console.WriteLine(crew.ToString());
            }
        }
        public void NotAssignedCrewMembers()
        {
            var notAssignedMembers = _crewRepo.GetNotAssignedCrewMembers();
            Console.WriteLine("Not Assigned Crew Members:");
            foreach (var member in notAssignedMembers)
            {
                Console.WriteLine(member.ToString());
            }

        }
        public void CreateCrew(Guid pilotId,Guid copilotId, Guid flightAttendant1Id, Guid flightAttendant2Id, Guid flightId)
        {
            var flight = _flightRepo.GetFlightById(flightId);
            if (DoesCrewExistForFlight(flight))
            {
                Console.WriteLine("A crew is already assigned to this flight.");
                return;
            }
            var pilot = _crewRepo.GetCrewMemberById(pilotId);
            var copilot = _crewRepo.GetCrewMemberById(copilotId);
            var flightAttendant1 = _crewRepo.GetCrewMemberById(flightAttendant1Id);
            var flightAttendant2 = _crewRepo.GetCrewMemberById(flightAttendant2Id);

            List<CrewMember> members = new List<CrewMember>() { pilot, copilot, flightAttendant1, flightAttendant2 };
            foreach (var member in members) {
                if (_crewRepo.IsCrewMemberAssignedToFlight(member, flight))
                {
                    Console.WriteLine($"Crew member {member.getName()} {member.getSurname()} is already assigned to this flight.");
                    return;
                }
            }
            _crewRepo.CreateCrew(members, flight);
        }

        public void AddCrewMember(string name, string surname, CrewRole role, DateTime dateOfBirth, Gender gender)
        {
            var newMember = new CrewMember(name, surname, role, gender, dateOfBirth);
            _crewRepo.AddCrewMember(newMember);
        }

        public bool DoesCrewExistForFlight(Flight flight)
        {
            var crews = _crewRepo.GetAllCrews();
            foreach (var crew in crews)
            {
                if (crew.getFlight() == flight)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
