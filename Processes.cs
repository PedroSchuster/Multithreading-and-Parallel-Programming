using System;
using System.Diagnostics;

namespace AsyncStudy
{
    class Processes
    {
        void Start()
        {

           // Process.Start(@"C:\Users\Usuario\Desktop\Programacao\Aulas\C#\teste.txt");
            Process.Start(@"notepad.exe",@"C:\Users\Usuario\Desktop\Programacao\Aulas\C#\teste.txt");

            var app = new Process
            {
                StartInfo =
                {
                    FileName = @"notepad.exe",
                    Arguments = @"C:\Users\Usuario\Desktop\Programacao\Aulas\C#\teste.txt"
                }

            };

            app.Start();

            app.PriorityClass = ProcessPriorityClass.RealTime;

            //app.WaitForExit(); // vai esperar fechar o "app" dai executa o resto do bloco
            //Console.Write("Cabo a espera");

            var processes = Process.GetProcesses();
            foreach (var item in processes)
            {
                if (item.ProcessName == "notepad")
                {
                    item.Kill();
                }
            }

        }
    }
}