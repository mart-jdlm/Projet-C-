using System;

namespace HUET_JOUBERT
{
    internal class ListeSCE
    {
        private Node<string> racine;
        private int count;
        /// <summary>
        /// Propriété de la racine
        /// </summary>
        public Node<string> Racine
        {
            get { return racine; }
            set { racine = value; }
        }
        /// <summary>
        /// Propriété de la valeur totale
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        /// <summary>
        /// Constructeur avec tous les attributs
        /// </summary>
        public ListeSCE()
        {
            racine = null;
            count = 0;
        }
        /// <summary>
        /// Autre constructeur utilisant une ville
        /// </summary>
        /// <param name="ville">Ville</param>
        public ListeSCE(string ville)
        {
            racine = new Node<string>(ville, 0);
            count = 0;
        }
        /// <summary>
        /// Placer la ville en racine
        /// </summary>
        /// <param name="ville">Ville</param>
        public void AssocierRacine(string ville)
        {
            racine = new Node<string>(ville, 0);
            count = 1;
        }
        /// <summary>
        /// Rajouter une ville dans la liste
        /// </summary>
        /// <param name="ville">Ville à ajouter</param>
        public void AjouterVille(string ville)
        {
            if (racine == null)
            {
                AssocierRacine(ville);
            }
            else
            {
                Node<string> villeCourante = racine;
                while (villeCourante.Valeur != ville && villeCourante.Suivant != null)
                {
                    villeCourante = villeCourante.Suivant;
                }
                if (villeCourante.Valeur != ville)
                {
                    villeCourante.Suivant = new Node<string>(ville, villeCourante.Indice + 1);
                    Count++;
                }
            }
        }
        /// <summary>
        /// Afficher l'ensemble des villes
        /// </summary>
        public void AfficherVilles()
        {
            Node<string> courant = racine;
            Console.WriteLine("Nombre de Ville :" + Count);
            Console.Write("[        ] ");
            while (courant != null)
            {
                Console.Write("[{0,2:d}:{1,-5}] ", courant.Indice, courant);
                courant = courant.Suivant;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Obtenir l'indice associé à la ville en paramètre 
        /// </summary>
        /// <param name="ville">Ville</param>
        /// <returns>Indice</returns>
        public int GetIndice(string ville)
        {
            int indice = -1;
            if (racine != null)
            {
                Node<string> courant = racine;
                while (courant != null && indice == -1)
                {
                    if (courant.Valeur == ville) indice = courant.Indice;
                    courant = courant.Suivant;
                }
            }
            return indice;
        }
        /// <summary>
        /// Obtenir la ville située à l'index placé en paramètre
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Ville trouvée</returns>
        /// <exception cref="IndexOutOfRangeException">Exception erreur</exception>
        public string GetVille(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            Node<string> courant = racine;
            for (int i = 0; i < index; i++)
            {
                courant = courant.Suivant;
            }
            return courant.Valeur;
        }
    }
}
