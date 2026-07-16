using DroneFleetDataProcessing.src.utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.queries;
//Department that manages the summary
public class SummeryDrones
{
    List<Drone> _drones;
    int _total;
    //A constructor that initializes a list of drones
    public SummeryDrones(List<Drone> drones, int total)
    {
        _drones = drones;
        _total = total;
    }
    //A function that calls all summary queries
    public string GetQueries()
    {
        return $"DRONE FLEET ANALYSIS REPORT\n\n" +
            $"{Summary()}\n" +
            $"{NonOptional()}\n" +
            $"{Top5()}\n" +
            $"{AvilableDronesNoDuplicates()}\n" +
            $"{ByBase()}\n" +
            $"{AverageBatteryHelth()}\n" +
            $"{HighestTotalCompleted()}\n" +
            $"{HighestAverageFlyHouersModels()}\n";
    }
    //A function that returns a general summary
    private string Summary()
    {
        return $"PROCESSING SUMMARY\n" +
            $"Total raw records:{_total}\n" +
            $"Valid records:{_drones.Count()}\n" +
            $"Rejected records:{_total - _drones.Count()}\n";
    }
    //A function that returns the not Operational drones
    private string NonOptional()
    {
        string result = "NON-OPERATIONAL DRONES \n";
        var nonOptionals = _drones
            .Where(drone => drone.Status != "Operational")
            .Select(drone => new
            {
                SerialNumber = drone.SerialNumber,
                Model = drone.Model,
                Base_location = drone.Base_location,
                Status = drone.Status
            })
            .ToList();
        if (result.Length == 0)
        {
            result += "No results found.\n";
        }
        foreach (var drone in nonOptionals)
        {
            result += $"{drone.SerialNumber} | " +
                $"{drone.Model} | " +
                $"{drone.Base_location} | " +
                $"{drone.Status}\n";
        }
        return result;
    }
    //A function that returns the 5 drones with the most flight hours
    private string Top5()
    {
        string result = "TOP 5 DRONES BY FLIGHT HOURS\n";
        var top5 = _drones
            .OrderByDescending(drone => drone.FlightHours)
            .Take(5)
            .Select(drone => new
            {
                SerialNumber = drone.SerialNumber,
                Model = drone.Model,
                FlightHours = drone.FlightHours
            })
            .ToList();
        if (result.Length == 0)
        {
            result += "No results found.\n";
        }
        for (int i = 1; i <= 5; i++)
        {
            if (i > top5.Count)
            {
                result += $"{i}. no exists";
            }
            else
            {
                result += $"{i}. {top5[i-1].SerialNumber} | " +
                    $"{top5[i - 1].Model} | " +
                    $"{top5[i - 1].FlightHours.ToString("F2")} "
                    + "\n";
            }
        }
        return result;
    }
    //A function that returns the module types
    private string AvilableDronesNoDuplicates()
    {
        string result = "AVAILABLE DRONE MODELS\n";
        var avilableDronesNoDuplicates = _drones
            .Select(d => d.Model)
            .Distinct()
            .ToList();
        if (avilableDronesNoDuplicates.Count == 0)
        {
            return result + "No results found\n";
        }
        foreach (var item in avilableDronesNoDuplicates)
        {
            result += item + "\n";
        }
        return result;

    }
    //A function that returns how many drones there are at each base
    private string ByBase()
    {
        string result = "DRONES BY BASE\n";

        foreach (string location in Consts.location_bases)
        {
            int count = _drones.Count(d => d.Base_location == location);

            result += $"{location}: {count}\n";
        }

        return result;
    }
    //A function that returns a battery average for each model type
    private string AverageBatteryHelth()
    {
        string result = "AVERAGE BATTERY HEALTH BY MODEL\n";
        foreach (string model in Consts.models)
        {
            var dronesByModel = _drones
                .Where(d => d.Model == model)
                .ToList();
            if (dronesByModel.Count == 0)
            {
                result += $"{model}: N/A\n";
            }
            else
            {
                double avg = dronesByModel.Average(t => t.BatteryHealth);
                result += $"{model}: {avg.ToString("F2")}\n";
            }
        }
        return result;
    }
    //A function that returns the model with the most completed tasks
    private string HighestTotalCompleted()
    {
        string result = "MODEL WITH HIGHEST TOTAL COMPLETED MISSIONS\n";
        var highestTotalComplete = _drones
           .GroupBy(r => r.Model)
             .Select(s => new
             {
                 Model = s.Key,
                 TotalMissions = s.Sum(t => t.MissionsCompleted)
             })
             .OrderByDescending(a => a.TotalMissions)
             .Take(1)
             .ToList();
        return result +
            $"Model: {highestTotalComplete[0].Model}\nTotal completed missions: {highestTotalComplete[0].TotalMissions}\n";

    }
    //A function that returns the five models with the most flight time
    private string HighestAverageFlyHouersModels()
    {
        string result = "SELECTED ADDITIONAL ANALYSIS\n";
        var HighestAverageFly = _drones
             .GroupBy(r => r.Model)
             .Select(s => new
             {
                 Model = s.Key,
                 Avg = s.Average(t => t.FlightHours)
             })
             .OrderByDescending(x => x.Avg)
             .Take(3)
             .ToList();
        if (HighestAverageFly.Count == 0)
        {
            return result + "No results found\n";
        }
        foreach (var item in HighestAverageFly)
        {
            result += "Model: " + item.Model + " with average flight " + item.Avg.ToString("F2") + "\n";
        }
        return result;
    }
}
