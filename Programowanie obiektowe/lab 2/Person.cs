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
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public int GetAge()
        {
            return age;
        }
        public void SetAge(int age)
        {
            this.age = age;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public bool Equals(Person person)
        {
            if (person.GetAge() == age && person.GetName() == name)
            {
                return true;
            }
            return false;
        }

        public string ToString()
        {
            return $"{name}: {age}";
        }
    }
}
