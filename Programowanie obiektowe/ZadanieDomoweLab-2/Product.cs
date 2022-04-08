using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomoweLab_2
{
    abstract class Product : IThing
    {
        private string name;
        public string Name { get => this.name; set => this.name = value; }

        public Product(string name)
        {
            this.name = name;
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
