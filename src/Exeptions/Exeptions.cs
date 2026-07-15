using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.Exeptions
{
    public class NoValidDronesException : Exception
    {
        public NoValidDronesException(string message) : base(message) { }
    }
    public class EmptyDroneFileException : Exception
    {
        public EmptyDroneFileException(string message) : base(message) { }
    }
    public class DeserializationReturnedNullException : Exception
    {
        public DeserializationReturnedNullException(string message) : base(message) { }
    }
}
