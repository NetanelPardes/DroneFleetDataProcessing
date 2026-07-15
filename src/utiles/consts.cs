using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.utiles;

class Consts
{
    public static List<string> models = ["Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite"];
    public static List<string> categorys = ["Recon", "Patrol", "Mapping", "Delivery", "Search"];
    public static List<string> location_bases = ["North", "South", "Central", "East", "West"];
    public static List<string> statuss = ["Operational", "Maintenance", "Grounded", "Training"];
}