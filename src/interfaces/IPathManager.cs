using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.interfaces;

public interface IPathManager
{

    public string getInputRawPath(string name);
    public string getOutputPath(string name);
    public string getInputTestScenariosPath(string name);
}

