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
        /// <summary>
        /// Importer le fichier des distances
        /// </summary>
        /// <param name="cheminFichier">Nom du fichier</param>
        /// <returns>Toutes les possibilités de déplacements sont placées dans un tableau de string</returns>
        public static string[] ImporterDistances(string cheminFichier)
        {
            // Vérification si le fichier existe
            if (File.Exists(cheminFichier))
            {
                // Lecture du fichier et stockage des lignes dans un tableau de chaînes
                string[] lignes = File.ReadAllLines(cheminFichier);
                return lignes;
            }
            else
            {
                Console.WriteLine("Le fichier n'existe pas.");
                return null;
            }
        }
        /// <summary>
        /// Enregistrer toutes les possibilités de déplacement dans un fichier
        /// </summary>
        /// <param name="distances">Liste de tous les déplacements possibles</param>
        /// <param name="cheminFichier">Fichier sur lequel on enregistre</param>
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
        /// <summary>
        /// Afficher l'ensemble des déplacements possibles
        /// </summary>
        /// <param name="distances">Liste de tous les déplacements possibles</param>
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
        /// <summary>
        /// Crée les duos de villes
        /// </summary>
        /// <returns>Duos de villes</returns>
        public static ListeSCE CreerListeVille()
        {
            string[] ToutesLesLignes = ImporterDistances("Distances.txt");
            ListeSCE listeVilles = new ListeSCE();
            foreach (var ligne in ToutesLesLignes)
            {
                var villes = ligne.Split('\t');
                // Ajouter uniquement la première ville de la ligne à la liste
                listeVilles.AjouterVille(villes[0]);
                // Ajouter uniquement la deuxième ville de la ligne à la liste
                listeVilles.AjouterVille(villes[1]);
            }
            return listeVilles;
        }
        /// <summary>
        /// Crée la matrice d'adjacence
        /// </summary>
        /// <returns>Tableau des distances pour les déplacements possibles</returns>
        public static int[,] CreerMatriceDeDistance()
        {
            string[] ToutesLesLignes = ImporterDistances("Distances.txt");
            //Créer la liste de ville en appelant la methode CreerListeVille puis initialiser la matrice, 99999 partout sauf sur les diagonales il faut mettre 0
            var listeVilles = CreerListeVille();
            var count = listeVilles.Count;
            var matrice = new int[count, count];
            // Initialiser la matrice avec 99999 partout sauf sur les diagonales où il faut mettre 0
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j)
                    {
                        matrice[i, j] = 0;
                    }
                    else
                    {
                        matrice[i, j] = 99999;
                    }
                }
            }
            foreach (var ligne in ToutesLesLignes)
            {
                var elements = ligne.Split('\t');
                var indexVille1 = listeVilles.GetIndice(elements[0]);
                var indexVille2 = listeVilles.GetIndice(elements[1]);
                var distance = int.Parse(elements[2]);
                matrice[indexVille1, indexVille2] = distance;
                matrice[indexVille2, indexVille1] = distance;
            }
            return matrice;
        }
        /// <summary>
        /// Affiche la matrice contenant toutes les villes avec leurs distances
        /// </summary>
        /// <param name="matrice">Distances entre les villes</param>
        /// <param name="listeVilles">Liste des duos de villes</param>
        public static void AfficherMatriceAvecVilles(int[,] matrice, ListeSCE listeVilles)
        {
            int lignes = matrice.GetLength(0);
            int colonnes = matrice.GetLength(1);

            // Affichage des noms des villes en entête
            Console.Write("   ");
            for (int j = 0; j < colonnes; j++)
            {
                Console.Write($"{listeVilles.GetVille(j),-10}");
            }
            Console.WriteLine();

            for (int i = 0; i < lignes; i++)
            {
                Console.Write($"{listeVilles.GetVille(i),-10}");
                for (int j = 0; j < colonnes; j++)
                {
                    Console.Write($"{matrice[i, j],-10}");
                }
                Console.WriteLine();
            }
        }/// <summary>
        /// Donne l'enchaînement des villes pour le chemin le plus court
        /// </summary>
        /// <param name="villeDepart">Ville de départ</param>
        /// <param name="villeArrivee">Ville d'arrivée</param>
        /// <returns>Suites des villes-étapes</returns>
        /// <exception cref="InvalidOperationException">Exception erreur</exception>
        public static List<string> PlusCourtChemin(string villeDepart, string villeArrivee)
        {
            int[,] matrice = CreerMatriceDeDistance();
            ListeSCE listeVilles = CreerListeVille();
            int nbVilles = listeVilles.Count;
            int[] distances = new int[nbVilles];
            bool[] visite = new bool[nbVilles];
            int[] precedent = new int[nbVilles];
            int indiceDepart = listeVilles.GetIndice(villeDepart);
            int indiceArrivee = listeVilles.GetIndice(villeArrivee);
            if (indiceDepart == -1 || indiceArrivee == -1)
            {
                Console.WriteLine("La ville de départ ou d'arrivée n'existe pas dans la liste des villes.");
                return new List<string>();
            }
            // Initialisation
            for (int i = 0; i < nbVilles; i++)
            {
                distances[i] = int.MaxValue;
                visite[i] = false;
                precedent[i] = -1;
            }
            distances[indiceDepart] = 0;
            for (int i = 0; i < nbVilles - 1; i++)
            {
                int noeudCourant = TrouverNoeudNonVisiteAvecDistanceMinimum(distances, visite);
                visite[noeudCourant] = true;
                for (int j = 0; j < nbVilles; j++)
                {
                    if (!visite[j] && matrice[noeudCourant, j] != 0 && distances[noeudCourant] + matrice[noeudCourant, j] < distances[j])
                    {
                        distances[j] = distances[noeudCourant] + matrice[noeudCourant, j];
                        precedent[j] = noeudCourant;
                    }
                }
            }
            List<string> plusCourtChemin = new List<string>();
            if (distances[indiceArrivee] != int.MaxValue)
            {
                int noeudCourant = indiceArrivee;
                while (noeudCourant != -1)
                {
                    plusCourtChemin.Add(listeVilles.GetVille(noeudCourant));
                    noeudCourant = precedent[noeudCourant];
                }
                // Inverser l'ordre du chemin
                plusCourtChemin.Reverse();
            }
            else
            {
                throw new InvalidOperationException("Il n'existe pas de chemin entre la ville de départ et la ville d'arrivée.");
            }
            return plusCourtChemin;
        }
        /// <summary>
        /// Retourne le nombre qui correspond à la ville la plus proche
        /// </summary>
        /// <param name="distances">Tableau des distances des villes autour</param>
        /// <param name="visite">Tableau décrivant les villes déjà visitées</param>
        /// <returns>Nombre qui correspond à la ville la plus proche</returns>
        private static int TrouverNoeudNonVisiteAvecDistanceMinimum(int[] distances, bool[] visite)
        {
            int minDistance = int.MaxValue;
            int noeudAvecMinDistance = -1;
            for (int i = 0; i < distances.Length; i++)
            {
                if (!visite[i] && distances[i] < minDistance)
                {
                    minDistance = distances[i];
                    noeudAvecMinDistance = i;
                }
            }
            return noeudAvecMinDistance;
        }
        /// <summary>
        /// Calcule la somme des distances sur le chemin le plus court
        /// </summary>
        /// <param name="villeDepart">Ville départ</param>
        /// <param name="villeArrivee">Ville arrivée</param>
        /// <returns>Somme des distances parcourues sur le chemin</returns>
        public static int CalculerDistanceTotale(string villeDepart, string villeArrivee)
        {
            int[,] matrice = CreerMatriceDeDistance();
            ListeSCE listeVilles = CreerListeVille();
            List<string> chemin = PlusCourtChemin(villeDepart, villeArrivee);
            int distanceTotale = 0;
            for (int i = 0; i < chemin.Count - 1; i++)
            {
                int indiceVilleDepart = listeVilles.GetIndice(chemin[i]);
                int indiceVilleArrivee = listeVilles.GetIndice(chemin[i + 1]);
                distanceTotale += matrice[indiceVilleDepart, indiceVilleArrivee];
            }
            return distanceTotale;
        }
    }
}
