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
        public List<Guid> FlightIds { get; set; }
        public List<CrewMember> Members { get; set; }
        public Crew(List<CrewMember> members)
        {
            Members = members;
            Id = Guid.NewGuid();
        }
        public Crew() { }
        
        
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
