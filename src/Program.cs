using DroneFleetDataProcessing.src.interfaces;
using DroneFleetDataProcessing.src.loggers;
using System;
using System.Net.Http.Headers;
namespace DroneFleetDataProcessing.src
{
    class Program
    {
        //The main program
        static void Main()
        {
            ILogger logger = new ConsoleLogger();
            DroneValidation validation = new DroneValidation();
            IPathManager pathManager = new PathManager();
            IDroneReader droneReader = new ReadDronesFile();
            IDroneWriter droneWriter = new WriteDronesFile();

            DronesManager dronesManager = new DronesManager(logger, validation, pathManager, droneReader, droneWriter);

            dronesManager.go(pathManager.getInputRawPath("drones_raw.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_all_invalid.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_empty.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_malformed.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_null.json"));
        }
    }
}