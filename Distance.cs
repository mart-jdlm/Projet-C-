using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    internal class Distance
    {
        /// <summary>
        /// Propriété ville départ
        /// </summary>
        public string VilleDepart { get; set; }
        /// <summary>
        /// Propriété ville d'arrivée
        /// </summary>
        public string VilleArrivee { get; set; }
        /// <summary>
        /// Propriété de la distance de trajet en kilomètres
        /// </summary>
        public int DistanceEnKm { get; set; }
        /// <summary>
        /// Propriété de la durée du trajet
        /// </summary>
        public TimeSpan Duree { get; set; }
        /// <summary>
        /// Constructeur avec tous les attributs
        /// </summary>
        /// <param name="villeDepart">Ville de départ</param>
        /// <param name="villeArrivee">Ville d'arrivée</param>
        /// <param name="distanceEnKm">Distance à parcourir en kilomètres</param>
        /// <param name="duree">Durée du trajet</param>
        public Distance(string villeDepart, string villeArrivee, int distanceEnKm, TimeSpan duree)
        {
            VilleDepart = villeDepart;
            VilleArrivee = villeArrivee;
            DistanceEnKm = distanceEnKm;
            Duree = duree;
        }
    }
}
