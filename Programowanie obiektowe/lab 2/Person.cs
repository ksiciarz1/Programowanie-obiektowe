using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Person
    {
        protected string name;
        protected int age;
        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public bool Equals(Person person)
        {
            if (person.Age == age && person.Name == name)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{name}: {age}";
        }
    }
}
