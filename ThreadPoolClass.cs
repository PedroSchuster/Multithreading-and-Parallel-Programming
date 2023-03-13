using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStudy
{

    class ThreadPoolClass
    {


        static void BackgroundTask(Object stateInfo)
        {
            Console.WriteLine("Hello! I'm a worker from ThreadPool");
            Thread.Sleep(1000);
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void BackgroundTaskWithObject(Object stateInfo)
        {
            Person data = (Person)stateInfo;
            Console.WriteLine($"Hi {data.Name} from ThreadPool.");
            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {
            // Use ThreadPool for a worker thread        
            ThreadPool.QueueUserWorkItem(BackgroundTask);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(500);

            // Create an object and pass it to ThreadPool worker thread  
            Person p = new Person("Jhonathan Soares", 28, "Male");
            ThreadPool.QueueUserWorkItem(BackgroundTaskWithObject, p);

            int workers, ports;

            // Get maximum number of threads  
            ThreadPool.GetMaxThreads(out workers, out ports);
            Console.WriteLine($"Maximum worker threads: {workers} ");
            Console.WriteLine($"Maximum completion port threads: {ports}");

            // Get available threads  
            ThreadPool.GetAvailableThreads(out workers, out ports);
            Console.WriteLine($"Availalbe worker threads: {workers} ");
            Console.WriteLine($"Available completion port threads: {ports}");

            // Set minimum threads  
            int minWorker, minIOC;
            ThreadPool.GetMinThreads(out minWorker, out minIOC);
            ThreadPool.SetMinThreads(minWorker, minIOC);

            // Get total number of processes availalbe on the machine  
            int processCount = Environment.ProcessorCount;
            Console.WriteLine($"No. of processes available on the system: {processCount}");

            // Get minimum number of threads  
            ThreadPool.GetMinThreads(out workers, out ports);
            Console.WriteLine($"Minimum worker threads: {workers} ");
            Console.WriteLine($"Minimum completion port threads: {ports}");

            Console.ReadKey();
        }

        // Create a Person class  
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Sex { get; set; }

            public Person(string name, int age, string sex)
            {
                this.Name = name;
                this.Age = age;
                this.Sex = sex;
            }
        }
    }
}
