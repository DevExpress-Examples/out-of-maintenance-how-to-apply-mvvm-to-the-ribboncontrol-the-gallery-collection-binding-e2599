using System.Collections.ObjectModel;

namespace DXSample.Model {
    public class PersonCollection : ObservableCollection<Person> {
        public static PersonCollection Generate() {
            PersonCollection persons = new PersonCollection();
            persons.Add(new Person("Jane Lopes", "jane@lopes.com", "9 (679) 89086878"));
            persons.Add(new Person("Abel Tomas", "abel@tomas.com", "4 (456) 78797897"));
            persons.Add(new Person("Zig Perscot", "zig@perscot.com", "5 (568) 12489445"));
            persons.Add(new Person("John Verwolf", "john@verwolf.com", "3 (454) 851384294"));
            persons.Add(new Person("Denis Macdaff", "denis@macdaff.com", "9 (545) 454548489"));
            persons.Add(new Person("Luka Madock", "luka@madock.com", "9 (545) 454548489"));
            persons.Add(new Person("Mary Nickor", "mary@nickor.com", "9 (545) 454548489"));
            persons.Add(new Person("David Avel", "david@avel.com", "9 (545) 454548489"));
            persons.Add(new Person("Arnold Neferson", "arnold@eferson.com", "9 (545) 454548489"));
            persons.Add(new Person("Mike Anderson", "mike@anderson.com", "9 (545) 454548489"));
            return persons;
        }
    }
}