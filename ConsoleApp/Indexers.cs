using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    // Indexer is a property with Name = this
    class Indexers
    {
        private string[] _brandName = new string[] { "BMW", "Toyota", "Maruti", "Audi" };
        public string this[int index]
        {
            get
            {
                return _brandName[index];
            }
            set
            {
                _brandName[index] = value; 
            }
        }


    }
}
