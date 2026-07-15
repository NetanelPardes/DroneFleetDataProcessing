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
        var nonOptional = _drones
            .Where(drone => drone.Status != "Operational")
            .Select(drone => new
            {
                SerialNumber = drone.SerialNumber,
                Model = drone.Model,
                Base = drone.Base_location,
                Status = drone.Status
            })
            .ToList();
        

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
            "The three models with the highest average flight tim\n" +
            $"Analysis name: {HighestAverageFly[0].Model} With average flight {HighestAverageFly[0].Avg}\n" +
            $"Analysis name: {HighestAverageFly[1].Model} With average flight {HighestAverageFly[0].Avg}\n" +
            $"Analysis name: {HighestAverageFly[2].Model} With average flight {HighestAverageFly[0].Avg}\n";
    }
}
