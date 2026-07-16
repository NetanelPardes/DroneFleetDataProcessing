using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.interfaces;

public interface IDroneWriter
{
    public void Write(string path, List<Drone> drones);

}

