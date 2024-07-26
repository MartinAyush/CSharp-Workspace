using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class AnonymousTypes
    {
        /*
         * An anonymous type in C# is a type (class) without any name 
         * that can contain public read-only properties only. 
         * It cannot contain other members, such as fields, methods, events, etc. 
         * You create an anonymous type using the new operator with an object initializer syntax.
         * var obj = new {  };
         * it has local scope.
         */
        public void Main()
        {
            var customAnonymousType = new
            {
                Name = "Martin",
                Age = 22,
                Gender = "Male"
            };

            // readonly properties 
            //customAnonymousType.Age = 23 - Gives error


            // Nested Anonymous type
            var customAnonymousType1 = new
            {
                AnotherTypes = new {
                    Address = "Pune"
                },
                Name = "Martin"
            };

            string ans = customAnonymousType1.AnotherTypes.Address;

            // Anonymous Arrays
            var anonymousArray = new[]
            {
                new {Prop1 = "Test1", Prop2 = "Test2"},
                new {Prop1 = "Test1", Prop2 = "Test2"},
                new {Prop1 = "Test1", Prop2 = "Test2"},
            };

        }
    }
}
