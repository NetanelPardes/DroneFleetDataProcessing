using System.Text.Json;

namespace DroneFleetDataProcessing.src;

class ReadDronesFile
{
    public static List<Drone> Read(string path)
    {
        string text = File.ReadAllText(path);
        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        List<Drone> drones = JsonSerializer.Deserialize<List<Drone>>(text, options) ?? new();
        return drones;
    }
}