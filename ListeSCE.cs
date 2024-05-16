using System;

namespace HUET_JOUBERT
{
    internal class ListeSCE
    {
        private Node<string> racine;
        private int count;
        public Node<string> Racine
        {
            get { return racine; }
            set { racine = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }

        }
        public ListeSCE()
        {
            racine = null;
            count = 0;
        }
        public ListeSCE(string ville)
        {
            racine = new Node<string>(ville, 0);
            count = 0;
        }
        public void AssocierRacine(string ville)
        {
            racine = new Node<string>(ville, 0);
            count = 1;
        }

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
                //si je suis ici, c'est soit la ville existe déja, soit je suis arrivé au dernier maillon
                if (villeCourante.Valeur != ville)//la ville n'existe pas, il faut l'ajouter avec un indice superieure à la précédente
                {
                    villeCourante.Suivant = new Node<string>(ville, villeCourante.Indice + 1);
                    Count++;
                }
            }
        }
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
