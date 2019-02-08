using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace _03_BuiltinDelegateExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> friends = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                friends.Add(new Person());
            }


            //example 1 - selection
            //Find ONE/FIRST person with specified condition
            //Predicate<T>    ->    bool (T)
            Person actual = friends.Find(OlderThan30);


            //example 2 - sorting
            //Find ALL person with specified condition
            //Predicate<T>    ->    bool (T)
            List<Person> filteredPersons = friends.FindAll(OlderThan30);



            //example 3 - decision
            //Determine: Is anybody with specified condition?
            //Predicate<T>    ->    bool (T)
            bool result = friends.Exists(OlderThan30);




            //example 4 - custom sort
            //SZTF2: Implement IComparable<T> in class level
            //new solution: use external function
            //Comparison<T>   ->    int(T1,T2)
            Person[] personscopy = friends.ToArray();
            Array.Sort(personscopy, SpecialComparer);
            

            //important!
            //collections have FindAll and Where (extension) methods -> same result (sorting)
            //FindAll -> List<T> [pure references to object...not safe]
            //Where -> IEnumerable<T> [only getting the object values, backwriting is blocked]
            

        }

        static bool OlderThan30(Person p)
        {
            return p.Age > 30;
        }

        static int SpecialComparer(Person p1, Person p2)
        {
            //calculate a point: age * length of name
            //compare by points
            int point1 = p1.Age * p1.Name.Length;
            int point2 = p2.Age * p2.Name.Length;

            //long solution
            //if (point1 < point2)
            //{
            //    return -1; //or any number less than zero
            //}
            //else if (point2 < point1)
            //{
            //    return 1; //or any number greater than zero
            //}
            //else
            //{
            //    return 0;
            //}


            //trick: primitve types (int, double, etc.) has own CompareTo overrider
            return point1.CompareTo(point2);
        }


    }
}
