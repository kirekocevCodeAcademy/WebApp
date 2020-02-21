using Core.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainData.Library.SqlData
{
    public class PersonDataSql : IPersonData
    {
        private readonly LibraryDbContext libraryDbContext;

        public PersonDataSql(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public Person Create(Person person)
        {
            libraryDbContext.Person.Add(person);
            return person;
        }

        public Person GetPersonById(int personId)
        {
            return libraryDbContext.Person.SingleOrDefault(p => p.Id == personId);
        }

        public Person Update(Person person)
        {
            libraryDbContext.Person.Update(person);
            return person;
        }
        public int Commit()
        {
            return libraryDbContext.SaveChanges();
        }

        public IEnumerable<Person> GetPersons(string searchTerm = null)
        {
            return libraryDbContext.Person
                .Where(r => string.IsNullOrEmpty(searchTerm)
                    || r.FirstName.ToLower().StartsWith(searchTerm.ToLower())
                    || r.LastName.ToLower().StartsWith(searchTerm.ToLower()))
                .OrderBy(r => r.FirstName)
                .ToList();
        }
    }
}
