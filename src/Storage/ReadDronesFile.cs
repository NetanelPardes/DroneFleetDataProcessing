using DroneFleetDataProcessing.src.Exeptions;
using System.Text.Json;

namespace DroneFleetDataProcessing.src;

class ReadDronesFile
{
    public static List<Drone> Read(string path)
    {
        string text = File.ReadAllText(path);
        JsonSerializerOptions options = new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true
        };
        List<Drone> drones = JsonSerializer.Deserialize<List<Drone>>(text, options) ?? new();
        if (drones == null)
        {
            throw new DeserializationReturnedNullException("Deserialization returned null.");
        }
        if (drones.Count == 0)
        {
            throw new EmptyDroneFileException("The raw drones file contains no records.");
        }
        return drones;
    }
}