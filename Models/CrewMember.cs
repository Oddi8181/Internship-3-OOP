using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CrewMember
    {
        Guid id;
        string Name { get; set; }
        string Surname { get; set; }
       
        Gender Gender { get; set; }
        DateTime DateOfBirth { get; set; }
        public CrewRole Role { get; set; }
        public bool IsAssigned { get; set; }

        public CrewMember(string name, string surname, CrewRole role, Gender gender, DateTime dateOfBirth)
        {
            id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Role = role;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            IsAssigned  = false;
        }

        public Guid getId() { return id; }
        public string getName() { return Name; }
        public string getSurname() { return Surname; }
        public CrewRole getRole() { return Role; }
        public Gender getGender() {return Gender; }
        public DateTime getDateOfBirth() { return DateOfBirth; }

        public void setName(string name) { Name = name; }
        public void setSurname(string surname) { Surname = surname; }
        public void setRole(CrewRole role) { Role = role; }
        public void setGender(Gender gender) { Gender = gender; }
        public void setDateOfBirth(DateTime dateOfBirth) { DateOfBirth = dateOfBirth; }


        public override string ToString()
        {
            return $"{Name} {Surname} - {Role}, {Gender}, Born on {DateOfBirth.ToShortDateString()}";
        }

    }
}