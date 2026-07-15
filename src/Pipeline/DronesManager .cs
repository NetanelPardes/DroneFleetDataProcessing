using DroneFleetDataProcessing.src.interfaces;
using System;
using System.Security.Cryptography.X509Certificates;
namespace DroneFleetDataProcessing.src
{
    public class DronesManager
    {
        private ILogger _logger;
        private DroneValidation _validation;
        private PathManager _pathManager;

        public DronesManager(ILogger logger, DroneValidation validation, PathManager pathManager)
        {
            _logger = logger;
            _validation = validation;
            _pathManager = pathManager;
        }
        public List<Drone> ValidDrons(List<Drone> myDrones)
        {
            List<Drone> validDrons = new List<Drone>();
            foreach (var item in myDrones)
            {
                if (_validation.droneValidation(item))
                {
                    validDrons.Add(item);
                }
            }
            return validDrons;
        }
        public void go()
        {
            _logger.WriteLog("=== Drone Fleet Data Processing System ===");

            _logger.WriteLog("Step 1: Reading raw data...");
            List<Drone> myDroneList = ReadDronesFile.Read(_pathManager.getInputRawPath("drones_raw.json"));
            _logger.WriteLog($"Read {myDroneList.Count} records from raw file");

            _logger.WriteLog("Step 2: Validating data and creating clean dataset...");
            List<Drone> myValidDroneList = ValidDrons(myDroneList);
            _logger.WriteLog($"Valid records: {myValidDroneList.Count}");
            _logger.WriteLog($"Rejected records: {myDroneList.Count - myValidDroneList.Count}");

            _logger.WriteLog("Step 3: Saving clean data...");
            FileSerialization.Write(_pathManager.getOutputPath("drones_clean.json"), myValidDroneList);
            _logger.WriteLog($"Clean data saved to: drones_clean.json");

            _logger.WriteLog("Step 4: Reloading clean data...");
            List<Drone> myValidDrones = ReadDronesFile.Read(_pathManager.getOutputPath("drones_clean.json"));
            _logger.WriteLog("Loaded records from clean dataset");

            _logger.WriteLog("Step 5: Performing analysis...");


        }
    }
}

