using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Repository
{
    internal class CrewRepo
    {
        public List<Crew> _crews;
        public List<CrewMember> _members;
        public CrewRepo() 
        { 

            _crews = new List<Crew>();
            _members = new List<CrewMember>();

            _members.Add(new CrewMember("Petar", "Perić", CrewRole.Pilot, Gender.Male, new DateTime(1994,02,02)));
            _members.Add(new CrewMember("Luka", "Lukić", CrewRole.CoPilot, Gender.Male, new DateTime(1992,12,20)));
            _members.Add(new CrewMember("Sara", "Sarić", CrewRole.FlightAttendant, Gender.Female, new DateTime(1998,05,24)));
            _members.Add(new CrewMember("Iva", "Ivić", CrewRole.FlightAttendant, Gender.Female, new DateTime(2000, 02, 12)));

            var crew = new Crew(_members);
            _crews.Add(crew);

        }

        public void AddCrew(Crew crew)
        {
            _crews.Add(crew);
        }

        public List<Crew> GetAllCrews()
        {
            return _crews;
        }
       
        public Crew GetCrewById(Guid id)
        {
            var crew = _crews.FirstOrDefault(c => c.Members.Any(m => m.getId() == id));
            return crew;
        }
        public CrewMember GetCrewMemberById(Guid id)
        {
            var member = _members.FirstOrDefault(m => m.getId() == id);
            return member;
        }
        public void AddFlight(Crew crew, Guid flightId)
        {
            crew.FlightIds.Add(flightId);
        }
       
        public void CreateCrew(List<CrewMember> members)
        {
            Crew crew = new Crew(members);
            foreach (var member in members)
            {
                member.IsAssigned = true;
            }
            _crews.Add(crew);
        }

        public void RemoveCrew(Crew crew)
        {
            _crews.Remove(crew);
        }

        public void AddCrewMember(CrewMember member)
        {
            _members.Add(member);
        }

        public List<CrewMember> GetAllCrewMembers()
        {
            return _members;
        }
        public void RemoveCrewMember(CrewMember member)
        {
            _members.Remove(member);
        }
        public bool DoesCrewExistForFlight(Guid flightId)
        {
            foreach (var crew in _crews)
            {
                if (crew.FlightIds.Contains(flightId))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCrewMemberAssignedToFlight(CrewMember member, Guid flightId)
        {

            foreach (var crew in _crews)
            {
                if (crew.Members.Contains(member) && DoesCrewExistForFlight(flightId))
                {
                    return true;
                }
            }
            return false;
        }
        public List<CrewMember> GetNotAssignedCrewMembers()
        {
            List<CrewMember> notAssignedMembers = new List<CrewMember>();
            foreach (var member in _members)
            {
                bool isAssigned = false;
                foreach (var crew in _crews)
                {
                    if (crew.Members.Contains(member))
                    {
                        isAssigned = true;
                        break;
                    }
                }
                if (!isAssigned)
                {
                    notAssignedMembers.Add(member);
                }
            }
            return notAssignedMembers;
        }
    }
}
