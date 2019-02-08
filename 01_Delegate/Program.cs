using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Delegate
{
    class Program
    {
        //step 1: Create some delegate TYPE(!!!)

        //syntax:
        //delegate [return type] [delegate type name] (params...)

        delegate void MyDisplayDelegate(string name, int age);
        delegate double MyMathDelegate(IEnumerable<double> collection);


        //step 2: create some functions, which match with the delegate types
        //void(string, int) template:

        static void DisplayGerman(string name, int age)
        {
            Console.WriteLine($"Mein(e) Freund(in) heisst {name}, er/sie ist {age} Jahre alt.");
        }

        static void DisplayFormatted(string name, int age)
        {
            Console.WriteLine($"### {name} ###   ----   [{age}]");
        }

        //double(IEnumerable<double>)
        //IEnumerable ???? Perfect interface for every collection (array, list, linkedlist, arraylist, etc.)
        static double Average(IEnumerable<double> mycollection)//in delegate type: "collection" | in method parameter list: "mycollection"  ->> no problem
        {
            double result = 0;
            int count = 0; //IEnumerable doesn't have length/count property, it supports just the NEXT item, SZTF2 :) )
            foreach (double item in mycollection)
            {
                result += item;
                count++;
            }
            return result/count;
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
            //##################################### EXAMPLE 1


            //step 3: create delegate INSTANCES

            //MyDisplayDelegate mydispdel = new MyDisplayDelegate(DisplayGerman);   -> long format
            MyDisplayDelegate mydispdel = DisplayGerman;  // -> short format

            //delegate instance: "array of methods" named: multicast delegate (.NET has unicast delegate too, in c# just multicast)
            //we can add several methods
            mydispdel += DisplayFormatted;

            //adding the first element: instance creating time (constructor or assignment)
            //addig the other element: += operator
            //deleting element: -= operator

            //step4: execute all functions (DisplayGerman, DisplayFormatted with John and 43 parametres)
            //NULL VALUE CHECK IS IMPORTANT (thread safety reasons)

            //if (mydispdel != null)
            //{
            //    mydispdel("John", 43);
            //}

            //short format:
            mydispdel?.Invoke("John", 43);



            //##################################### EXAMPLE 2




            //the other example -> double(IEnumerable<double>)
            //create collection
            double[] heights = { 175, 198, 187, 176, 206, 188, 199, 167, 154, 149 };

            //create deleage instance, add two functions (Average, Sum)
            MyMathDelegate mathdelegate = Average;
            mathdelegate += Sum;

            //execute and catch the return values
            //double is a value type and cannot have "null" value -> use nullable double
            double? result = mathdelegate?.Invoke(heights);

            Console.WriteLine(result);

            //wait...the result contains just the result of sum
            //where is the result of average?
            //nowhere :( we can just catch the result of the last function of the delegate (sum)


            //solution

            //collection for the results
            List<double?> results = new List<double?>();

            foreach (MyMathDelegate item in mathdelegate.GetInvocationList())
            {
                results.Add(item?.Invoke(heights));
            }

            //results[0]: average
            //results[1]: sum

            //call sequence is not guaranteed under .NET 4.5
            

            


            Console.ReadLine();

        }
    }
}
