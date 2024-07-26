using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public partial class PartialClass
    {
        private int _score = 0;
        public int MyScore
        {
            get
            {
                return _score;
            }
            set
            {
                if(value > _score)
                {
                    _score = value;
                }
            }
        }
        //public int Age { get; set; } // cannot have same methods, fields, properties

    }
}
