using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Crew
    {
        Guid Id;
        Flight Flight { get; set; }
        public List<CrewMember> Members { get; set; }
        public Crew(List<CrewMember> members,Flight flight)
        {
            Members = members;
            Id = new Guid();
            this.Flight = flight;
        }
        public Flight getFlight() { return Flight; }
        public Guid getId() { return Id; }
        public void setFlight(Flight flight) { Flight = flight; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Crew Members:");
            foreach (var member in Members)
            {
                sb.AppendLine(member.ToString());
            }
            return sb.ToString();
        }
    }
}
