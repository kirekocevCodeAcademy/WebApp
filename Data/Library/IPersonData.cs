using System.Collections.Generic;
using Core.Library;

namespace DomainData.Library
{
    public interface IPersonData
    {
        Person Create(Person person);
        Person GetPersonById(int personId);
        Person Update(Person person);
        int Commit();
        IEnumerable<Person> GetPersons(string searchTerm = null);
    }
}
