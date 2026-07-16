using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src;
//A class that manages writing to the Jason file
class FileSerialization
{
    //Serializing to a Jason file
    private static string Serialize(List<Drone> drones)
    {
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(drones, serializerOptions);
    }
    public static void Write(string path,List<Drone> drones)
    {
        File.WriteAllText(path,Serialize(drones));
    }
}
