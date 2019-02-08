using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BuiltinDelegateExamples
{
    class Person
    {
        //static value -> name and age randomization helpers
        static Random r;
        static string[] names;

        //real life auto properties
        //only getter: write just in the constructor
        public string Name { get; }
        public int Age { get; }

        //static constructor: names, random initialization
        static Person()
        {
            r = new Random();
            string [] tmpnames = { "John", "Kate", "Alfred", "William", "Brian", "Stuart", "Jessica", "Laurel", "Oliver" };
            names = tmpnames;
        }

        //instance level constructor: create Name and Age prop values
        public Person()
        {
            this.Name = names[r.Next(0, names.Length)];
            this.Age = r.Next(18, 90);
        }
    }
}
