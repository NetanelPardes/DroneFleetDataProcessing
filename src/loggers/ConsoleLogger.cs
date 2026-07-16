using DroneFleetDataProcessing.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.loggers;

class ConsoleLogger : ILogger
{
    //Printing to console
    public void WriteLog(string message)
    {
        Console.WriteLine(message);
    }
}
