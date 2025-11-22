using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Models
{
    internal class Passenger
    {
        public Guid Id { get; }
        string Name { get; set; }
        string Surname { get; set; }
        DateTime DateOfBirth { get; set; }
        string Email { get; set; }
        string Password { get; set; }

        DateTime CreatedAt { get; set; }
        public List<Guid> FligtIds { get; }
    

 
        public Passenger(string name, string surname, DateTime dateOfBirth, string email, string password)
        {
            FligtIds = new List<Guid>();
            Id = Guid.NewGuid();
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.Password = password;
            this.CreatedAt = DateTime.Now;
        }

        public string getName() { return Name; }
        public string getSurname() { return Surname; }
        public DateTime getDateOfBirth() { return DateOfBirth; }      
        public string getEmail() { return Email; }
        
        public string getPassword() { return Password; }








    }
}
