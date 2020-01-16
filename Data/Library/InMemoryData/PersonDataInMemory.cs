using Core.Library;
using System.Collections.Generic;
using System.Linq;

namespace DomainData.Library.InMemoryData
{
    public class PersonDataInMemory : IPersonData
    {
        private List<Person> persons;

        public PersonDataInMemory()
        {
            persons = new List<Person>();
        }

        public Person Create(Person person)
        {
            person.Id = persons.Any() ? persons.Max(p => p.Id) + 1 : 1;
            persons.Add(person);

            return person;
        }

        public Person GetPersonById(int personId)
        {
            return persons.SingleOrDefault(p => p.Id == personId);
        }

        public Person Update(Person person)
        {
            var tempPerson = persons.SingleOrDefault(p => p.Id == person.Id);
            if (tempPerson != null)
            {
                tempPerson.FirstName = person.FirstName;
                tempPerson.LastName = person.LastName;
            }

            return tempPerson;
        }
        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Person> GetPersons(string searchTerm = null)
        {
            return persons
                .Where(r => string.IsNullOrEmpty(searchTerm)
                    || r.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                    || r.LastName.ToLower().StartsWith(searchTerm.ToLower()))
                .OrderBy(r => r.FirstName);
        }
    }
}
