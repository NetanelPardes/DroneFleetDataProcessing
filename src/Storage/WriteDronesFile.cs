using DroneFleetDataProcessing.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src;

class WriteDronesFile : IDroneWriter
{
    private string Serialize(List<Drone> drones)
    {
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(drones, serializerOptions);
    }
    public void Write(string path, List<Drone> drones)
    {
        File.WriteAllText(path, Serialize(drones));
    }
}
