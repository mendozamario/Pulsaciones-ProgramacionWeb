using System;
using Entity;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class PersonService
    {
        private readonly PulsationsContext _context;
    
        public PersonService(PulsationsContext context)
        {
            _context = context;
        }
        public SavePersonResponse Save(Person person)
        {
            try
            {
                var search = _context.Persons.Find(person.Id);
                if (search != null)
                {
                    return new SavePersonResponse("This person is registered");
                }
                person.CalculatePulsation();
                _context.Persons.Add(person);
                _context.SaveChanges();
                return new SavePersonResponse(person);
            }
            catch (Exception e)
            {
                return new SavePersonResponse($"Aplicattion Error: {e.Message}");
            }
        }
        public List<Person> CheckAll()
        {
            List<Person> persons = _context.Persons.ToList();
            return persons;
        }
        public string Delete(string id)
        {
            try
            {
                var searchPerson = _context.Persons.Find(id);
                if (searchPerson != null)
                {
                    _context.Persons.Remove(searchPerson);
                    _context.SaveChanges();
                    return ("This record has been successfully removed");
                }
                else
                {
                    return ("This person is not registered");
                }
            }
            catch (Exception e)
            {
                return ($"Aplicattion Error: {e.Message}");
            }
        }
        public string Update(Person newPerson)
        {
            try
            {
                var oldPerson = _context.Persons.Find(newPerson.Id);
                if (oldPerson != null)
                {
                    newPerson.CalculatePulsation();
                    _context.Persons.Update(newPerson);
                    _context.SaveChanges();
                    return ("This record has been updated successfully");
                }
                else
                {
                    return ("This person is not registered");
                }
            }
            catch (Exception e)
            {
                return ($"Aplicattion Error: {e.Message}");
            }
        }
    }
    public class SavePersonResponse
    {
        public SavePersonResponse(string message)
        {
            Message = message;
            Error = true;
        }
        public SavePersonResponse(Person person)
        {
            Person = person;
            Error = false;
        }
        public string Message { get; set; }
        public bool Error { get; set; }
        public Person Person { get; set; }
    }
}
