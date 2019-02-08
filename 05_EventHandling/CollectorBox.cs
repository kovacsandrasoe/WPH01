using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EventVSDelegate
{
    


    class CollectorBox<T>
    {
        //simple delegate "event"
        //we must block the outer access
        //so...we must create register, deregister methods
        private Action<int> insertSignal;


        //eventargs derived class
        public class InsertEventArgs<U> : EventArgs
        {
            public U Content { get; }

            public int Location { get; }

            public InsertEventArgs(U content, int location)
            {
                this.Content = content;
                this.Location = location;
            }
        }

        //event with specified eventargs
        public event EventHandler<InsertEventArgs<T>> InsertSignalAdvanced;



        static Random r;

        T[] collection;

        static CollectorBox()
        {
            r = new Random();
        }

        public CollectorBox(int size)
        {
            collection = new T[size];
        }

        //delegate "event" helper
        public void AddMethod(Action<int> method)
        {
            insertSignal += method;
        }

        //delegate "event" helper
        public void DeleteMethod(Action<int> method)
        {
            insertSignal -= method;
        }

        public void Add(T element)
        {
            int index = r.Next(0, collection.Length);
            collection[index] = element;

            //delegate "event" call
            insertSignal?.Invoke(index);

            //advanced event call
            InsertSignalAdvanced?.Invoke(this, new InsertEventArgs<T>(element, index));
        }


    }
}
