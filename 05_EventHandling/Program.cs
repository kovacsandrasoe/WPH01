using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EventVSDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectorBox<string> names = new CollectorBox<string>(10);
            //names.AddMethod(DisplayEvent);

            names.InsertSignalAdvanced += Names_InsertSignalAdvanced;

            names.Add("Peter");
            ;
            
        }

        private static void Names_InsertSignalAdvanced(object sender, CollectorBox<string>.InsertEventArgs<string> e)
        {
            Console.WriteLine($"{e.Content} element inserted to: {e.Location}");
        }

        static void DisplayEvent(int number)
        {
            Console.WriteLine($"Element inserted to: {number}");
        }

        
    }
}
