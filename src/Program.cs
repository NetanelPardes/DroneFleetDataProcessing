using DroneFleetDataProcessing.src.interfaces;
using DroneFleetDataProcessing.src.loggers;
using System;
namespace DroneFleetDataProcessing.src
{
    class Program
    {
        static void Main()
        {
            ILogger logger = new ConsoleLogger();
            DroneValidation validation = new DroneValidation();
            PathManager pathManager = new PathManager();

            DronesManager dronesManager = new DronesManager(logger, validation, pathManager);

            dronesManager.go();
    }
    }
}