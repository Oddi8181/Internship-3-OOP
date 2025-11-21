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
            var crew = _crews.FirstOrDefault(c => c.getId() == id);
            return crew;
        }
        public CrewMember GetCrewMemberById(Guid id)
        {
            var member = _members.FirstOrDefault(m => m.getId() == id);
            return member;
        }

        public void CreateCrew(List<CrewMember> members, Flight flight)
        {
            Crew crew = new Crew(members, flight);
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
        public bool IsCrewMemberAssignedToFlight(CrewMember member, Flight flight)
        {
            foreach (var crew in _crews)
            {
                if (crew.Members.Contains(member) && crew.getFlight() == flight)
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
