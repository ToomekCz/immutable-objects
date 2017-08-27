using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("foo", "boo");
            Console.WriteLine(person.Fullname());
            Console.ReadLine();
        }
    }

    public interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        string Fullname();
    }

    sealed class Person : IPerson, IEquatable<Person>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string fname, string lname)
        {
            this.FirstName = fname;
            this.LastName = lname;
        }

        public string Fullname() => this.ToString();

        public Person Rename(string fname, string lname) =>
            new Person(fname, lname);

        public override bool Equals(object obj) => this.Equals(obj as Person);

        public bool Equals(Person otherPerson) =>
            otherPerson != null &&
            this.FirstName == otherPerson.FirstName &&
            this.LastName == otherPerson.LastName;

        public override int GetHashCode() =>
            this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();

        public static bool operator ==(Person a, Person b) =>
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(Person a, Person b) => !(a == b);

        public override string ToString() => $"{this.FirstName} {this.LastName}";
    }
}
