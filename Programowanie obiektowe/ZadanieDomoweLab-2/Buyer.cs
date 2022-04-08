using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomoweLab_2
{
    internal class Buyer : Person
    {
        protected List<Product> products = new List<Product>();

        public Buyer(string name, int age) : base(name, age)
        {

        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void RemoveProduct(int index)
        {
            if (index < 0 || index >= products.Count)
            {
                throw new ArgumentOutOfRangeException("index", nameof(index));
            }
        }
        public override void Print(string prefix = null)
        {
            StringBuilder sb = new StringBuilder();
            if (prefix != null)
            {
                sb.Append(prefix);
            }
            sb.Append($"Buyer: {Name}");
            sb.Append($" (.{Age} y.o.)");
            Console.WriteLine(sb.ToString());
            if (products.Count > 0)
            {
                Console.WriteLine("\t -- Products: --");
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i] is Fruit)
                    {
                        Fruit fruit = (Fruit)products[i];
                        fruit.Print(prefix + "\t");
                    }
                    else if (products[i] is Meat)
                    {
                        Meat meat = (Meat)products[i];
                        meat.Print(prefix + "\t");
                    }
                    else
                    {
                        products[i].Print(prefix + "\t");
                    }
                }
            }
        }

    }
}
