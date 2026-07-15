using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.queries;

public class SummeryDrones
{
    List<Drone> _drones;
    int _total;
    public SummeryDrones(List<Drone> drones, int total)
    {
        _drones = drones;
        _total = total;
    }
    public string GetQueries()
    {
        return $"DRONE FLEET ANALYSIS REPORT\n" +
            $"{Summary()}" +
            $"{NonOptional()}\n" +
            $"{Top5()}\n" +
            $"{AvilableDronesNoDuplicates()}\n" +
            $"{ByBase()}\n" +
            $"{AverageBatteryHelth()}\n" +
            $"{HighestTotalCompleted()}\n" +
            $"{HighestAverageFlyHouersModels()}\n";
    }
    private string Summary()
    {
        return $"PROCESSING SUMMARY\n" +
            $"Total raw records:{_total}" +
            $"Valid records:{_drones.Count()}" +
            $"Rejected records:{_total - _drones.Count()}";
    }
    private string NonOptional()
    {
        string result = "NON-OPERATIONAL DRONES";
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
            result += "No results found.";
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
    private string Top5()
    {
        string result = "TOP 5 DRONES BY FLIGHT HOURS";
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
            result += "No results found.";
        }
        foreach (var drone in top5)
        {
            result += $"{drone.SerialNumber} | " +
                $"{drone.Model} | " +
                $"{drone.FlightHours}";
        }
        return result;
    }
    private string AvilableDronesNoDuplicates()
    {
        string result = "AVAILABLE DRONE MODELS\n";
        var avilableDronesNoDuplicates = _drones
            .Select(d => d.Model)
            .Distinct()
            .ToList();
        if (avilableDronesNoDuplicates.Count == 0)
        {
            return result + "No results found";
        }
        foreach (var item in avilableDronesNoDuplicates)
        {
            result += item;
        }
        return result;

    }
    private string ByBase()
    {
        string result = "DRONES BY BASE\n";
        var byBase = _drones
            .GroupBy(b => b.Base_location)
            .Select(s => new
            {
                Base_loc = s.Key,
                Count = s.Count()
            })
            .ToList();
        if (byBase.Count == 0)
        {
            return result + "No results found";
        }
        foreach (var item in byBase)
        {
            result += item.Base_loc + ": " + item.Count + "\n";
        }
        return result;
    }
    private string AverageBatteryHelth()
    {
        string result = "AVERAGE BATTERY HEALTH BY MODEL\n";
        var highestTotalComplete = _drones
           .GroupBy(r => r.Model)
             .Select(s => new
             {
                 Model = s.Key,
                 AverageBattery = s.Average(t => t.BatteryHealth)
             })
             .ToList();
        if (highestTotalComplete.Count == 0)
        {
            return result + "No results found";
        }
        foreach (var item in highestTotalComplete)
        {
            result += item.Model + ": " + item.AverageBattery.ToString("F2") + "\n";
        }
        return result;
    }
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
        return result +
            "Analysis name: THE THREE MODELS WITH THE HIGHEST AVERAGE FLIGHT TIME\n" +
            $"Model: {HighestAverageFly[0].Model} With average flight {HighestAverageFly[0].Avg.ToString("F2")}\n" +
            $"Model: {HighestAverageFly[1].Model} With average flight {HighestAverageFly[0].Avg.ToString("F2")}\n" +
            $"Model: {HighestAverageFly[2].Model} With average flight {HighestAverageFly[0].Avg.ToString("F2")}\n";
    }
}
