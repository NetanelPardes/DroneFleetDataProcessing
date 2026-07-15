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

    }
}
