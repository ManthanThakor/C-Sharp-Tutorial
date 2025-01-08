using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Location { get; set; }

        protected User(int id, string name, string contactInfo, string location)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
            Location = location;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Contact Info: {ContactInfo}, Location: {Location}");
        }
    }

}
