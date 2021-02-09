using System;
namespace CoffeeDate.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string ImageIcon { get; set; }
        public bool IsAvailable { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
