using System;
namespace CoffeeDate.Models
{
    public class Pair
    {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }

        public override string ToString()
        {
            return FirstPerson + " and " + SecondPerson;
        }
    }
}
