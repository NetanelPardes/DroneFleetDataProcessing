using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFleetDataProcessing.src.utiles;

class Consts
{
    //Model list
    public static List<string> models = ["Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite"];
    //Category list
    public static List<string> categorys = ["Recon", "Patrol", "Mapping", "Delivery", "Search"];
    //List of bases
    public static List<string> location_bases = ["North", "South", "Central", "East", "West"];
    //Drone status list
    public static List<string> statuss = ["Operational", "Maintenance", "Grounded", "Training"];
}