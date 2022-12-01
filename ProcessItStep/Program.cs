using System;
using System.Diagnostics;
namespace ProcessItStep
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Текущий процесс
             */
             var process = Process.GetCurrentProcess();
             Console.WriteLine($"Process ID: {process.Id}");
             Console.WriteLine($"Name of Process: {process.ProcessName}");
             Console.WriteLine($"memory size of Process: {process.PagedMemorySize64}");
             Console.WriteLine($"virtual Memory Size of process: {process.VirtualMemorySize64}");

            /* 
             * Все запущенные процессы
             */
             foreach (Process process1 in Process.GetProcesses())
             {
                 Console.WriteLine($" | ID: {process1.Id} | Name: {process1.ProcessName} | Virtual memory size:{process1.VirtualMemorySize64} |");
             }

            /* 
             * Процесы запущенные в Viscual Studio
             */
            Process[] vsProcesses = Process.GetProcessesByName("devenv");

             foreach(var proc in vsProcesses)
             {
                 Console.WriteLine($" | ID: {proc.Id} | Name: {proc.ProcessName} | Virtual memory size:{proc.VirtualMemorySize64} |");
             }

            /*
             * Потоки процессов в Visual Studio
             */
            Process vsProcesses1 = Process.GetProcessesByName("devenv")[0];

             ProcessThreadCollection processThreads = vsProcesses1.Threads;

             foreach (ProcessThread thread in processThreads)
             {
                 Console.WriteLine($" | ID: {thread.Id} | Start Address: {thread.StartAddress} | Start Time:{thread.StartTime} |");
             }

            /*
             * Модули процесса в Google Chrome
             */
            Process vsProcesses2 = Process.GetProcessesByName("chrome")[0];

            ProcessModuleCollection modules = vsProcesses2.Modules;

            foreach(ProcessModule module in modules)
            {
                Console.WriteLine($" | Module name: {module.ModuleName} | File name : {module.FileName} | Memory size of module :{module.ModuleMemorySize} |");
            }

            /*
             Запуск процесса  CCleaner*/
            Process.Start("C:\\Program Files\\CCleaner\\CCleaner.exe");

            /*
             Запуск процесса Google Chrome с параметром который запускает стэковерфлоу*/
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "https://stackoverflow.com");
            /*
             2 вариант с использованием класса ProcessStartInfo */
            ProcessStartInfo processstartInfo = new ProcessStartInfo();

            processstartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";

            processstartInfo.Arguments = "https://stackoverflow.com";
            Process.Start(processstartInfo);

        }
    }
}