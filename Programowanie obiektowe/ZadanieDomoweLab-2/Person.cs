using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomoweLab_2
{
    internal class Person : IThing
    {
        private string name;
        private int age;
        public string Name { get => this.name; set => this.name = value; }
        public int Age { get => this.age; set => this.age = value; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual void Print(string prefix = null)
        {
            StringBuilder sb = new StringBuilder();
            if (prefix != null)
            {
                sb.Append(prefix);
            }
            sb.Append(Name);
            Console.WriteLine(sb.ToString());
        }
    }
}
