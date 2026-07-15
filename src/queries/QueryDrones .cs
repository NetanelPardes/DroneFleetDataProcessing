using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.queries;

public class QueryDrones
{
    List<Drone> _drones;
    public QueryDrones(List<Drone> drones)
    {
        _drones = drones;
    }
    public string GetQueries()
    {
        return $"DRONE FLEET ANALYSIS REPORT\n\n" +
            $"{NonOptional()}\n" +
            $"{Top5()}\n" +
            $"{AvilableDronesNoDuplicates}\n" +
            $"{ByBase}\n" +
            $"{AverageBatteryHelth()}\n" +
            $"{HighestTotalCompleted()}\n" +
            $"{HighestAverageFlyHouersModels()}\n";
    }
    private string NonOptional()
    {

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
