using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomoweLab_2
{
    internal class Shop
    {
        private string name;
        private Person[] people;
        private Product[] products;
        public string Name { get => this.name; set => this.Name = value; }

        public Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;
            this.people = people;
            this.products = products;
        }

        public void Print(string prefix = null)
        {
            StringBuilder sb = new StringBuilder();
            if (prefix != null)
            {
                sb.Append(prefix);
            }
            sb.Append($"Shop: {name}\n");
            Console.WriteLine(sb.ToString());
            Console.Write("-- People: --");
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i] is Buyer)
                {
                    Buyer buyer = (Buyer)people[i];
                    buyer.Print();
                }
                else if (people[i] is Seller)
                {
                    Seller seller = (Seller)people[i];
                    seller.Print();
                }
                else
                {
                    people[i].Print();
                }
            }
            Console.WriteLine("-- Products --");
            for (int i = 0; i < products.Length; i++)
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
