using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_AnonMeth_Lambda
{
    /*
 * .NET Framework built-in delegate types
 * 
    Predicate<T>                    bool(T)
    Comparison<T>                   int(T1,T2)
    MethodInvoker                   void()
    EventHandler                    void(object,EventArgs)
    EventHandler<T>                 void(object,T) (T EventArgs utód)
    Action                          void()
    Action<T>                       void(T)
    Action<T1,T2>                   void(T1,T2)
    Action<T1,T2,...,T16>           void(T1,T2,...,T16)
    Func<TRes>                      TRes()
    Func<T, TRes>                   TRes(T)
    Func<T1, T2, TRes>              TRes(T1,T2)
    Func<T1, T2, ... T16, TRes>     TRes(T1,T2,...,T16)

    */
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> friends = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                friends.Add(new Person());
            }

            //example - sorting  -  3 WAY
            //Find ALL person with specified condition
            //Predicate<T>    ->    bool (T)


            //SOLUTION 1 - use named method matching Predicate<T>
            List<Person> filteredPersons = friends.FindAll(OlderThan30);


            //SOLUTION 2 - use unnamed/anonymus method/inline method matching Predicate<T>
            List<Person> filteredPersons2 = friends.FindAll(delegate (Person p)
            {
                return p.Age > 30;
            });


            //SOLUTION 3 - use Lambda expressions (this is anonymus method too, just in simplifier format)
            //syntax : (param1, param2) => return expression
            List<Person> filteredPersons3 = friends.FindAll(p => p.Age > 30);

            //anonymus methods/lambda...why?
            //one time functions (for example OlderThan30) infects the code





            //example 2 - custom sorting
            Person[] friendsArray = friends.ToArray();


            //SOLUTION 1 - use named method matching Comparison<T>
            Array.Sort(friendsArray, SpecialComparer);


            //SOLUTION 2 - use unnamed/anonymus method/inline method matching Comparison<T>
            Array.Sort(friendsArray, delegate (Person p1, Person p2)
            {
                return p1.Name.Length.CompareTo(p2.Name.Length);
            });


            //SOLUTION 3 - use Lambda expressions (this is anonymus method too, just in simplifier format)
            Array.Sort(friendsArray, (Person p1, Person p2) => p1.Name.Length.CompareTo(p2.Name.Length));



            //comments:
            //expression lambda: x => x*x   (return x*x)
            //statement lambda: x => Console.WriteLine(x*x)

        }

        static bool OlderThan30(Person p)
        {
            return p.Age > 30;
        }

        static int SpecialComparer(Person p1, Person p2)
        {
            return p1.Name.Length.CompareTo(p2.Name.Length);
        }
    }
}
