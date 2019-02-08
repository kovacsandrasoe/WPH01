using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SmartList
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
    class SmartList<T>
    {
        /* 
         Create a very special generic sorted linked list
         We have to customize all following behaviour with external functions
         -import elements from file: line reading policy
         -sorting mechanism
         -writing element to file: line writeout policy
         */

        class SmartListNode<U>
        {
            public U Content { get; set; }

            public SmartListNode<U> NextNode { get; set; }
        }

        SmartListNode<T> header;
        Comparison<T> comparer;
        Func<string, T> importer;
        Func<T, string> exporter;

        public SmartList(Comparison<T> comparer, Func<string, T> importer, Func<T, string> exporter)
        {
            this.comparer = comparer;
            this.importer = importer;
            this.exporter = exporter;
        }

        public SmartList(string fileName, Encoding encoding, Comparison<T> comparer, Func<string, T> importer, Func<T, string> exporter)
            : this(comparer, importer, exporter)
        {
            if (importer == null)
            {
                throw new ArgumentException("Importer method not attached!");
            }

            StreamReader sr = new StreamReader(fileName, encoding);
            while (!sr.EndOfStream)
            {
                T element = importer(sr.ReadLine());
                AddElement(element);
            }
            sr.Close();
        }

        public void AddElement(T element)
        {
            if (comparer == null)
            {
                throw new ArgumentException("Comparer method not attached!");
            }


            SmartListNode<T> newelement = new SmartListNode<T>();
            newelement.Content = element;

            if (header == null)
            {
                newelement.NextNode = null;
                header = newelement;
            }
            else
            {
                if (comparer(header.Content, newelement.Content) > 0)
                {
                    newelement.NextNode = header;
                    header = newelement;
                }
                else
                {
                    SmartListNode<T> p = header;
                    SmartListNode<T> e = null;
                    while (p != null && comparer(p.Content, newelement.Content) < 0)
                    {
                        e = p;
                        p = p.NextNode;
                    }
                    if (p == null)
                    {
                        newelement.NextNode = null;
                        e.NextNode = newelement;
                    }
                    else
                    {
                        newelement.NextNode = p;
                        e.NextNode = newelement;
                    }
                }
            }
        }

        public void Export(string fileName, Encoding encoding)
        {
            if (exporter == null)
            {
                throw new ArgumentException("Exporter method not attached!");
            }

            StreamWriter sw = new StreamWriter(fileName, false, encoding);

            SmartListNode<T> pointer = header;
            while (pointer != null)
            {
                sw.WriteLine(exporter(pointer.Content));
                pointer = pointer.NextNode;
            }

            sw.Close();
        }
    }
}
