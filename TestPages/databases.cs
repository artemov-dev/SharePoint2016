using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPages
{
    public class databases
    {
        public string Name { get; set; }
        public ulong size { get; set; }

        public databases(string Name, ulong size)
        {
            this.Name = Name;
            this.size = size;
        }
    }
}
