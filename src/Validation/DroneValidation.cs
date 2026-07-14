using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src
{
    public class DroneValidation
    {
        public List<int> Ids { get; set; }

        public List<string> SerialNumbers { get; set; }

        public DroneValidation()
        {
            Ids = new List<int>();
            SerialNumbers = new List<string>();
        }
        public bool droneValidation(Drone drone)
        {
            if (IsUniqueId(drone.Id) &&
                IsSerialNumber(drone.SerialNumber) &&
                IsModel(drone.Model) &&
                IsCategory(drone.Category) &&
                IsLocation_base(drone.Base_location) &&
                IsFlightHours(drone.FlightHours) &&
                IsBatteryHealth(drone.BatteryHealth) &&
                IsMaxRangeKm(drone.MaxRangeKm) &&
                IsMissionsCompleted(drone.MissionsCompleted) &&
                IsStatus(drone.Status) &&
                BatteryHealthValidationByStatus(drone.BatteryHealth, drone.Status))
            {
                Ids.Add(drone.Id);
                SerialNumbers.Add(drone.SerialNumber);

                return true;
            }
            return false;
        }
        public bool IsUniqueId(int id)
        {
            if (id <= 0 || Ids.Contains(id))
            {
                return false;
            }
            return true;
        }
        public bool IsSerialNumber(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
            {
                return false;
            }
            if (SerialNumbers.Contains(serialNumber))
            {
                return false;
            }
            string[] serial = serialNumber.Split('-');
            if (serial.Length != 2)
            {
                return false;
            }

            if (serial[0] != "DR")
            {
                return false;
            }
            if (!int.TryParse(serial[1], out int num) || num < 1000 || num > 9999)
            {
                return false;
            }

            return true;
        }
        public bool IsModel(string model)
        {
            List<string> models = ["Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite" ];
            if (models.Contains(model))
            {
                return true;
            }
            return false;
        }
        public bool IsCategory(string category)
        {
            List<string> categorys = ["Recon" ,"Patrol"  ,"Mapping" ,"Delivery" ,"Search"];

            if (categorys.Contains(category))
            {
                return true;
            }
            return false;
        }
        public bool IsLocation_base(string location_base)
        {
            List<string> location_bases = ["North" ,"South" ,"Central" ,"East" ,"West"];
            if (location_bases.Contains(location_base))
            {
                return true;
            }
            return false;
        }
        public bool IsFlightHours(double flightHours)
        {
            if (flightHours < 0.0 || flightHours > 2500.0)
            {
                return false;
            }
            return true;
        }
        public bool IsBatteryHealth(int batteryHealth)
        {
            if (batteryHealth < 0 || batteryHealth > 100)
            {
                return false;
            }
            return true;
        }
        public bool IsMaxRangeKm(double maxRangeKm)
        {
            if (maxRangeKm < 1 || maxRangeKm > 150)
            {
                return false;
            }
            return true;
        }
        public bool IsMissionsCompleted(int missionsCompleted)
        {
            if (missionsCompleted < 0 || missionsCompleted > 5000)
            {
                return false;
            }
            return true;
        }
        public bool IsStatus(string status)
        {
            List<string> statuss = ["Operational", "Maintenance", "Grounded", "Training"];
            if (statuss.Contains(status))
            {
                return true;
            }
            return false;
        }
        public bool BatteryHealthValidationByStatus(int battery, string status)
        {
            if (battery < 20 && status == "Operational")
            {
                return false;
            }
            return true;
        }
    }
}
