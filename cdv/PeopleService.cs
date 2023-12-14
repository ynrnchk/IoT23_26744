using System.Collections.Generic;
using System.Linq;

namespace YRonchyk.Function
{
    public class PeopleService
    {
        private readonly ApplicationDbContext _context;

        public PeopleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person Add(string firstName, string lastName)
        {
            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            _context.People.Add(person);
            _context.SaveChanges();

            return person;
        }

        public Person Update(int id, string firstName, string lastName)
        {
            var person = _context.People.FirstOrDefault(w => w.Id == id);

            if (person != null)
            {
                person.FirstName = firstName;
                person.LastName = lastName;
                _context.SaveChanges();
            }

            return person;
        }

        public void Delete(int id)
        {
            var person = _context.People.FirstOrDefault(w => w.Id == id);

            if (person != null)
            {
                _context.People.Remove(person);
                _context.SaveChanges();
            }
        }

        public Person Find(int id)
        {
            return _context.People.FirstOrDefault(w => w.Id == id);
        }

        public IEnumerable<Person> Get()
        {
            return _context.People.ToList();
        }

        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
