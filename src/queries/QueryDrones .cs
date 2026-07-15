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

    }
}
