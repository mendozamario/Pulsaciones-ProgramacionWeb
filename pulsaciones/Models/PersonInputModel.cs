using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace pulsaciones.Models
{
    public class PersonInputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
    public class PersonViewModel: PersonInputModel
    {
        public PersonViewModel() { }
        public PersonViewModel(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            Age = person.Age;
            Gender = person.Gender;
            Pulsation = person.Pulsation;
        }
        public float Pulsation { get; set; }
    }
}
