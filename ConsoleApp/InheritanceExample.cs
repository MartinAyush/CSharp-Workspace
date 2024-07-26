using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;

namespace ConsoleApp
{
    class InheritanceExample : SampleBaseClass
    {
        public InheritanceExample(int Id, DateTime date, string guid) : base(Id, date, guid)
        {
            Console.WriteLine("InheritanceExample Constructor called Id : {0}, date : {1}, guid : {2}.", Id, date.ToString(), guid);
        }

        public override void WriteYourName()
        {
            Console.WriteLine("MY NAME IS MARTIN AYUSH ANTHONY");
        }

    }

    class SampleBaseClass
    {
        int _id;
        DateTime _date;
        string _guid;
        public SampleBaseClass(int Id, DateTime date, string guid)
        {
            this._id = Id;
            this._date = date;
            this._guid = guid;
            Console.WriteLine("Sample Base Constructor Called!");
        }
        public void SampleBaseClassMethod()
        {
            Console.WriteLine("Sample Base Class Method Called with Id {0} | Date : {1} | guid : {2}.", _id, _date.ToString("dd-MM-yyyy"), _guid);
        }

        public virtual void WriteYourName()
        {
            Console.WriteLine("My Name is Martin");
        }
    }
}
