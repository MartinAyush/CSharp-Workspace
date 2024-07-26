using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    // When applying Generic Constraints(where T : {0})
    // in above comment {0} can be only class

    /*
        Write a generic class called Pair that can store two values of any type. 
        The Pair class should have two properties, First and Second, that can be used to access the two values.
     */
    public class CustomPair<T1, T2>
    {
        private T1 _type1;
        private T2 _type2;

        public T1 Value1 { get { return _type1; } }
        public T2 Value2 { get { return _type2; } }
        public CustomPair(T1 type1, T2 type2)
        {
            this._type1 = type1;
            this._type2 = type2;
        }

    }
}
