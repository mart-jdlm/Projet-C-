using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    internal class Distance
    {
        public string VilleDepart { get; set; }
        public string VilleArrivee { get; set; }
        public int DistanceEnKm { get; set; }
        public TimeSpan Duree { get; set; }

        public Distance(string villeDepart, string villeArrivee, int distanceEnKm, TimeSpan duree)
        {
            VilleDepart = villeDepart;
            VilleArrivee = villeArrivee;
            DistanceEnKm = distanceEnKm;
            Duree = duree;
        }
    }
}
