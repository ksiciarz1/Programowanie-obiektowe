using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomoweLab_2
{
    internal class Seller : Person
    {
        public Seller(string name, int age) : base(name, age)
        {

        }

        public override void Print(string prefix = null)
        {
            StringBuilder sb = new StringBuilder();
            if (prefix != null)
            {
                sb.Append(prefix);
            }
            sb.Append($"Seller: {Name}");
            sb.Append($" ({Age} y.o.)");
            Console.WriteLine(sb.ToString());
        }
    }
}
