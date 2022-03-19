using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomoweLab_2
{
    internal class Fruit : Product
    {
        private int count;
        public int Count { get => this.count; set => this.count = value; }

        public Fruit(string name, int count) : base(name)
        {
            this.count = count;
        }

        public override void Print(string prefix = null)
        {
            StringBuilder sb = new StringBuilder();
            if (prefix != null)
            {
                sb.Append(prefix);
            }
            sb.Append(Name);
            sb.Append($" ({count} fruits)");
            Console.WriteLine(sb.ToString());
        }
    }
}
