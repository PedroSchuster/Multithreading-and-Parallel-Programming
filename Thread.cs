using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStudy
{

    public class PrintingInfo
    {
        public int ProcessedNumbes { get; set; }
    }

    class ThreadClass
    {
        void Main()
        {
            var printInfo = new PrintingInfo();
            Thread t1 = new Thread(() => Print(false, printInfo));
            t1.IsBackground = true;
            t1.Start();
            /*
            if (t1.Join(TimeSpan.FromMilliseconds(50))) // controlar o tempo de execução, apesar de continuar a execuçao
                                                        // vai retornar falso se a thread n finalizar nesse tempo
            {
                Console.WriteLine($"Print info:{printInfo.ProcessedNumbes}");
            }
            else
            {
                Console.WriteLine("Timed out sem resultados");
            }

            Print(true, printInfo);
            */


        }

        private static void Print(bool isEven, PrintingInfo printingInfo)
        {

            while (true)
            {
                Thread.Sleep(1000);
            }

            if (isEven)
            {
                for (int i = 0; i < 10000; i++)
                {
                    if (i % 2 == 0)
                    {
                        printingInfo.ProcessedNumbes++;
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10000; i++)
                {
                    if (i % 2 != 0)
                    {
                        printingInfo.ProcessedNumbes++;
                        Console.WriteLine(i);
                    }
                }
            }


        }

    }
}
