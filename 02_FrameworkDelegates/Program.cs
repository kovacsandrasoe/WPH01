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
namespace _02_FrameworkDelegates
{
    class Program
    {
        //do not create your own delegate type!!!
        //4 functions from the previous project
        static void DisplayGerman(string name, int age)
        {
            Console.WriteLine($"Mein(e) Freund(in) heisst {name}, er/sie ist {age} Jahre alt.");
        }

        static void DisplayFormatted(string name, int age)
        {
            Console.WriteLine($"### {name} ###   ----   [{age}]");
        }

        static double Average(IEnumerable<double> mycollection)//in delegate type: "collection" | in method parameter list: "mycollection"  ->> no problem
        {
            double result = 0;
            int count = 0; //IEnumerable doesn't have length/count property, it supports just the NEXT item, SZTF2 :) )
            foreach (double item in mycollection)
            {
                result += item;
                count++;
            }
            return result / count;
        }

        static double Sum(IEnumerable<double> collection)
        {
            double result = 0;
            foreach (double item in collection)
            {
                result += item;
            }
            return result;
        }


        static void Main(string[] args)
        {
            //create delegate INSTANCES

            //example 1: void(string, int)  ->>>    Action<T1,T2> !!!
            Action<string, int> mydispdel = DisplayGerman;
            mydispdel += DisplayFormatted;

            //example 2: double(IEnumerable<double>)   ->>>>    Func<T, TRes>
            Func<IEnumerable<double>, double> mymathdel = Average;
            mymathdel += Sum;


        }
    }
}
