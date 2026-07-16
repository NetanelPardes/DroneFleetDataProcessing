using DroneFleetDataProcessing.src.interfaces;
using DroneFleetDataProcessing.src.loggers;
using System;
namespace DroneFleetDataProcessing.src
{
    class Program
    {
        //The main program
        static void Main()
        {
            ILogger logger = new ConsoleLogger();
            DroneValidation validation = new DroneValidation();
            PathManager pathManager = new PathManager();
            IDroneReader droneReader = new ReadDronesFile();

            DronesManager dronesManager = new DronesManager(logger, validation, pathManager, droneReader);

            dronesManager.go(pathManager.getInputRawPath("drones_raw.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_all_invalid.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_empty.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_malformed.json"));
            dronesManager.go(pathManager.getInputTestScenariosPath("drones_null.json"));

        }
    }
}