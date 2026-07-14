using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src
{
    public class PathManager
    {
        private string _basePath;

        public PathManager()
        {
            _basePath = Directory.GetCurrentDirectory();
        }
        public string getInputRawPath(string filename)
        {
            return Path.Combine(_basePath,"input","raw", filename);
        }

        public string getInputTestScenariosPath(string filename)
        {
            return Path.Combine(_basePath, "test_scenarios", filename);
        }

        public string getOutputPath(string filename)
        {
            return (Path.Combine(_basePath, "output" , filename));
        }
    }
}
