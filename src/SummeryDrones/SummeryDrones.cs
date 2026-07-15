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
            $"{AvilableDronesNoDuplicates}\n" +
            $"{ByBase}\n" +
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

    }
    private string AvilableDronesNoDuplicates()
    {

    }
    private string ByBase()
    {

    }
    private string AverageBatteryHelth()
    {

    }
    private string HighestTotalCompleted()
    {
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
        return "MODEL WITH HIGHEST TOTAL COMPLETED MISSIONS\n" +
            $"Model: {highestTotalComplete[0].Model}\nTotal completed missions: {highestTotalComplete[0].TotalMissions}\n";

    }
    private string HighestAverageFlyHouersModels()
    {
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
        return "SELECTED ADDITIONAL ANALYSIS\n" +
            "Analysis name: THE THREE MODELS WITH THE HIGHEST AVERAGE FLIGHT TIME\r\n\n" +
            $"Model: {HighestAverageFly[0].Model} With average flight {HighestAverageFly[0].Avg}\n" +
            $"Model: {HighestAverageFly[1].Model} With average flight {HighestAverageFly[0].Avg}\n" +
            $"Model: {HighestAverageFly[2].Model} With average flight {HighestAverageFly[0].Avg}\n";
    }
}
