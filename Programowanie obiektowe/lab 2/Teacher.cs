using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Teacher : Person
    {
        public Teacher(string name, int age) : base(name, age)
        {

        }
        public string ToString()
        {
            return $"Teacher: {name}, ({age} y.o.)\n\n";
        }
    }
}
