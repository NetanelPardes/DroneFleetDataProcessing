using System.Text.Json;

namespace DroneFleetDataProcessing.src;

class ReadDronesFile
{
    public static List<Drone> Read(string path)
    {
        string text = File.ReadAllText(path);
        List<Drone> drones = JsonSerializer.Deserialize<List<Drone>>(text) ?? new();
        return drones;
    }
}