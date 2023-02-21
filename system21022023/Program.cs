using System;
using System.Diagnostics;
using System.Threading;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static public void ask(Thread thread)
        {
            Console.WriteLine("End the process?(y/n)");
            string yesno = Console.ReadLine();
            if (yesno == "y" && thread.IsAlive)
            {
                //thread.Abort();
                Process.GetProcessById(thread.ManagedThreadId).Kill();
            }
            else
            {
                if (thread.IsAlive)
                {
                    Console.WriteLine("w8ing for end of the process...");
                }
            }
        }

        static void Main(string[] args)
        {


            //1
            Thread thread1 = new(() => Console.WriteLine(123));

            thread1.Start();

            while (thread1.IsAlive)
            {
                Console.WriteLine(1);
            }
            Console.WriteLine("Thread is dead");


            //2
            Thread thread2 = new(() =>
            {
                Console.WriteLine("Process is alive...");
                Thread.Sleep(4000);
                Console.WriteLine("Process is dead");
            });
            thread2.Name = "dont kill me pls";
            thread2.Start();
            ask(thread2);
        }
    }
}
