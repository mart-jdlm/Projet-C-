using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    internal class GestionDistance
    {
        public static List<Distance> ImporterDistances(string cheminFichier)
        {
            List<Distance> distances = new List<Distance>();

            try
            {
                using (StreamReader sr = new StreamReader(cheminFichier))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('\t');

                        string villeDepart = parts[0];
                        string villeArrivee = parts[1];
                        int distanceEnKm = int.Parse(parts[2]);
                        TimeSpan duree = TimeSpan.Parse(parts[3]);

                        distances.Add(new Distance(villeDepart, villeArrivee, distanceEnKm, duree));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'importation des distances : " + ex.Message);
            }

            return distances;
        }

        public static void EnregistrerDistances(List<Distance> distances, string cheminFichier)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(cheminFichier))
                {
                    foreach (Distance distance in distances)
                    {
                        string line = $"{distance.VilleDepart}\t{distance.VilleArrivee}\t{distance.DistanceEnKm}\t{distance.Duree}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'enregistrement des distances : " + ex.Message);
            }
        }

        public static void AfficherDistances(List<Distance> distances)
        {
            foreach (Distance distance in distances)
            {
                Console.WriteLine($"De {distance.VilleDepart} à {distance.VilleArrivee} :");
                Console.WriteLine($" - Distance : {distance.DistanceEnKm} km");
                Console.WriteLine($" - Durée : {distance.Duree}");
                Console.WriteLine();
            }
        }
    }
}
