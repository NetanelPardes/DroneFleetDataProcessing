using DroneFleetDataProcessing.src.Exeptions;
using DroneFleetDataProcessing.src.interfaces;
using DroneFleetDataProcessing.src.queries;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
namespace DroneFleetDataProcessing.src
{
    public class DronesManager
    {
        private ILogger _logger;
        private DroneValidation _validation;
        private PathManager _pathManager;
        int totalDrones = 0;

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
            if (validDrons.Count == 0)
            {
                throw new NoValidDronesException("No valid records found for analysis!");
            }
            return validDrons;
        }
        public void RunSummary()
        {
            string sourcePath = _pathManager.getOutputPath("drones_clean.json");
            List<Drone> drones = ReadDronesFile.Read(sourcePath);
            SummeryDrones summeryDrones = new SummeryDrones(drones, totalDrones);
            string result = summeryDrones.GetQueries();
            string resultPath = _pathManager.getOutputPath("analysis_report.txt");
            File.WriteAllText(resultPath, result);
        }
        public void go()
        {
            try
            {
                _logger.WriteLog("=== Drone Fleet Data Processing System ===");

                //Step 1
                _logger.WriteLog("Step 1: Reading raw data...");
                List<Drone> myDroneList = ReadDronesFile.Read(_pathManager.getInputRawPath("drones_raw.json"));
                totalDrones = myDroneList.Count();
                _logger.WriteLog($"Read {myDroneList.Count} records from raw file");

                //Step 2
                _logger.WriteLog("Step 2: Validating data and creating clean dataset...");
                List<Drone> myValidDroneList = ValidDrons(myDroneList);
                _logger.WriteLog($"Valid records: {myValidDroneList.Count}");
                _logger.WriteLog($"Rejected records: {myDroneList.Count - myValidDroneList.Count}");

                //Step 3
                _logger.WriteLog("Step 3: Saving clean data...");
                FileSerialization.Write(_pathManager.getOutputPath("drones_clean.json"), myValidDroneList);
                _logger.WriteLog($"Clean data saved to: drones_clean.json");

                //Step 4
                _logger.WriteLog("Step 4: Reloading clean data...");
                List<Drone> myValidDrones = ReadDronesFile.Read(_pathManager.getOutputPath("drones_clean.json"));
                _logger.WriteLog("Loaded records from clean dataset");

                //Step 5
                _logger.WriteLog("Step 5: Performing analysis...");
                RunSummary();
                _logger.WriteLog("Analysis completed successfully");

                //Step 6
                _logger.WriteLog("Step 6: Generating report...");
                _logger.WriteLog($"Report generated successfully: analysis_report.txt ");

                //Finaly
                _logger.WriteLog("=== Process completed successfully!===");

            }
            catch (FileNotFoundException ex)
            {
                _logger.WriteLog($"Error: File  {Path.GetFileName(ex.FileName)} not found");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.WriteLog($"Error: Access to {ex.Message} denied");
            }
            catch (JsonException ex)
            {
                _logger.WriteLog($"Error: Invalid JSON - {ex.Message}");
            }
            catch (DeserializationReturnedNullException ex)
            {
                _logger.WriteLog($"Error: Deserialization returned null - {ex.Message}");
            }
            catch (EmptyDroneFileException ex)
            {
                _logger.WriteLog($"Error: Empty drone file - {ex.Message}");
            }
            catch (NoValidDronesException ex)
            {
                _logger.WriteLog($"Error: No valid drones - {ex.Message}");
            }
            catch (IOException ex)
            {
                _logger.WriteLog($"Error: File operation failed - {ex.Message}");
            }
        }
    }
}

