using System;
namespace DroneFleetDataProcessing.src;

public class Drone
{
    public int Id { get; init; }

    public string SerialNumber { get; init; }

    public string Model { get; init; }

    public string Category { get; init; }

    public string Base_location { get; init; }
    
    public double FlightHours { get; init; }

    public int BatteryHealth { get; init; }
    
    public double MaxRangeKm { get; init; }

    public int MissionsCompleted { get; init; }

    public string Status { get; init; }

}