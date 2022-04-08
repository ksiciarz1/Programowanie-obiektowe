using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieDomoweLab_2
{
    internal interface IThing
    {
        string Name { get => this.Name; set => this.Name = value; }
    }
}
