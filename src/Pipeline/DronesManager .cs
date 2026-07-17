using DroneFleetDataProcessing.src.Exeptions;
using DroneFleetDataProcessing.src.interfaces;
using DroneFleetDataProcessing.src.queries;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
namespace DroneFleetDataProcessing.src
{
    //A department that manages the running of the program
    public class DronesManager
    {
        private ILogger _logger;
        private DroneValidation _validation;
        private IPathManager _pathManager;
        IDroneReader _droneReader;
        IDroneWriter _droneWriter;
        int _totalDrones = 0;

        //Manager Builder
        public DronesManager(ILogger logger, DroneValidation validation, IPathManager pathManager, IDroneReader droneReader, IDroneWriter droneWriter)
        {
            _logger = logger;
            _validation = validation;
            _pathManager = pathManager;
            _droneReader = droneReader;
            _droneWriter = droneWriter;
        }
        //Return of all operational drones
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
        //Running all summary functions and returning a text string
        public string RunSummary()
        {
            string sourcePath = _pathManager.getOutputPath("drones_clean.json");
            List<Drone> drones = _droneReader.Read(sourcePath);
            SummeryDrones summeryDrones = new SummeryDrones(drones, _totalDrones);
            string result = summeryDrones.GetQueries();
            return result;
        }
        //Writing to the summary file
        public void WriteSummaryToFile(string summary)
        {
            string resultPath = _pathManager.getOutputPath("analysis_report.txt");
            File.WriteAllText(resultPath, summary);
        }
        //The six stages of the program
        public void go(string source)
        {
            try
            {
                _logger.WriteLog("===Drone Fleet Data Processing System ===");

                //Step 1
                _logger.WriteLog("Step 1: Reading raw data...");
                List<Drone> myDroneList = _droneReader.Read(source);
                _totalDrones = myDroneList.Count();
                _logger.WriteLog($"Read {myDroneList.Count} records from raw file");

                //Step 2
                _logger.WriteLog("Step 2: Validating data and creating clean dataset...");
                List<Drone> myValidDroneList = ValidDrons(myDroneList);
                _logger.WriteLog($"Valid records: {myValidDroneList.Count}");
                _logger.WriteLog($"Rejected records: {myDroneList.Count - myValidDroneList.Count}");

                //Step 3
                _logger.WriteLog("Step 3: Saving clean data...");
                _droneWriter.Write(_pathManager.getOutputPath("drones_clean.json"), myValidDroneList);
                _logger.WriteLog($"Clean data saved to: drones_clean.json");

                //Step 4
                _logger.WriteLog("Step 4: Reloading clean data...");
                List<Drone> myValidDrones = _droneReader.Read(_pathManager.getOutputPath("drones_clean.json"));
                _logger.WriteLog("Loaded records from clean dataset");

                //Step 5
                _logger.WriteLog("Step 5: Performing analysis...");
                string summary = RunSummary();
                _logger.WriteLog("Analysis completed successfully");

                //Step 6
                _logger.WriteLog("Step 6: Generating report...");
                WriteSummaryToFile(summary);
                _logger.WriteLog($"Report generated successfully: analysis_report.txt ");

                //Finaly
                _logger.WriteLog("=== Process completed successfully!===\n");

            }
            catch (FileNotFoundException ex)
            {
                _logger.WriteLog($"Error: File  {Path.GetFileName(ex.FileName)} not found");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.WriteLog($"Error: Access to {ex.Message} denied\n");
            }
            catch (JsonException ex)
            {
                _logger.WriteLog($"Error: Invalid JSON - {ex.Message}\n");
            }
            catch (DeserializationReturnedNullException ex)
            {
                _logger.WriteLog($"Error: Deserialization returned null - {ex.Message}\n");
            }
            catch (EmptyDroneFileException ex)
            {
                _logger.WriteLog($"Error: Empty drone file - {ex.Message}\n");
            }
            catch (NoValidDronesException ex)
            {
                _logger.WriteLog($"Error: No valid drones - {ex.Message}\n");
            }
            catch (IOException ex)
            {
                _logger.WriteLog($"Error: File operation failed - {ex.Message}\n");
            }
        }
    }
}

