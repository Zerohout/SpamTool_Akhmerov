using System;
using System.Threading;
using static System.Console;

namespace PolygonConsole
{
    class Program
    {
        static object __SyncRoot = new object();

        static void Main(string[] args)
        {
            ThreadTesting(30);
            
            ReadKey();
        }

        static void ThreadTesting(int count)
        {
            var sign = 33;
            var top = 0;
            var threads = new Thread[count];

            for (var i = 0; i < count; i++)
            {
                threads[i] = new Thread(WriteSign);
            }

            for (var i = 0; i < count; i++, sign++, top++)
            {
                threads[i].Start(new Sign((char)sign, top));
            }
        }
        
        static void WriteSign(object obj)
        {
            for (int i = 0, left = 0; i < 119; i++, left++)
            {
                lock (__SyncRoot)
                {
                    SetCursorPosition(left, (obj as Sign).topPos);
                    Write((obj as Sign).sign);
                    Thread.Sleep(10);
                }
            }
        }

        class Sign
        {
            public char sign;
            public int topPos;

            public Sign(char sign, int topPos)
            {
                this.sign = sign;
                this.topPos = topPos;
            }
        }
    }
}
