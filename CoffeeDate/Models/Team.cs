using System.Collections.Generic;
namespace CoffeeDate.Models
{
    public class Team : List<Person>
    {
        public string Name { get; private set; }

        public Team(string name, List<Person> people) : base(people)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
