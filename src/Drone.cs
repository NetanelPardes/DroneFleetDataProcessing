using System;
namespace DroneFleetDataProcessing.src;

public class Drone
{
    public int Id { get; }

    public string SerialNumber { get; }

    public string Model { get; }

    public string Category { get; }

    public string Base_location { get; }
    
    public double FlightHours { get; }

    public int BatteryHealth { get; }
    
    public double MaxRangeKm { get; }

    public int MissionsCompleted { get;}

    public string Status { get; }

    public Drone(int id, 
        string serialNumber, 
        string model, 
        string category, 
        string base_location, 
        double flightHours,
        int batteryHealth,
        double maxRangeKm, 
        int missionsCompleted,
        string status)
    {
        Id = id;
        SerialNumber = serialNumber;
        Model = model;
        Category = category;
        Base_location = base_location;
        FlightHours = flightHours;
        BatteryHealth = batteryHealth;
        MaxRangeKm = maxRangeKm;
        MissionsCompleted = missionsCompleted;
        Status = status;
    }
}