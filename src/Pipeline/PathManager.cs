using DroneFleetDataProcessing.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src
{
    //A department that manages the routes
    public class PathManager : IPathManager
    {
        private string _basePath;

        //A function that returns the location of the project
        public PathManager()
        {
            _basePath = Directory.GetCurrentDirectory();
        }
        //A function that returns the position of the correct input.
        public string getInputRawPath(string name)
        {
            return Path.Combine(_basePath, "input", "raw", name);
        }
        //A function that returns the position of the correct input.
        public string getInputTestScenariosPath(string name)
        {
            return Path.Combine(_basePath, "input", "test_scenarios", name);
        }
        //A function that returns the position of the output.
        private string getOutputDirPath()
        {
            return (Path.Combine(_basePath, "output"));
        }
        //A function that returns the location of the output file.
        public string getOutputPath(string name)
        {
            if (!Directory.Exists(getOutputDirPath()))
            {
                Directory.CreateDirectory(getOutputDirPath());
            }
            return (Path.Combine(_basePath, "output", name));
        }
    }
}
