using System;
namespace DroneFleetDataProcessing.src
{
    class Program
    {
        static void Main()
        {
            PathManager p = new PathManager();
            Console.WriteLine(p.getInputRawPath("drones_raw.json"));
            Console.WriteLine(p.getInputTestScenariosPath("drones_empty.json"));
            Console.WriteLine(p.getOutputPath());
        }
    }
}