using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.Exeptions
{
    //No valid drones error
    public class NoValidDronesException : Exception
    {
        public NoValidDronesException(string message) : base(message) { }
    }
    //Empty file error
    public class EmptyDroneFileException : Exception
    {
        public EmptyDroneFileException(string message) : base(message) { }
    }
    //Null file error
    public class DeserializationReturnedNullException : Exception
    {
        public DeserializationReturnedNullException(string message) : base(message) { }
    }
}
