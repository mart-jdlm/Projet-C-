using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    internal class Node<T>
    {
        private T valeur;
        private int indice;
        private Node<T> suivant;
        /// <summary>
        /// Constructeur avec tous les attributs
        /// </summary>
        /// <param name="valeur">Valeur</param>
        /// <param name="indice">Indice</param>
        /// <param name="suivant">Référence du Node suivant</param>
        public Node(T valeur, int indice = -1, Node<T> suivant = null)
        {
            this.valeur = valeur;
            this.indice = indice;
            this.suivant = suivant;
        }
        /// <summary>
        /// Propriété de la valeur
        /// </summary>
        public T Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }
        /// <summary>
        /// Propriété de l'indice
        /// </summary>
        public int Indice
        {
            get { return indice; }
        }
        /// <summary>
        /// Propriété de la référence du Node suivant
        /// </summary>
        public Node<T> Suivant
        {
            get { return suivant; }
            set { suivant = value; }
        }
        /// <summary>
        /// Méthode pour afficher les attributs
        /// </summary>
        /// <returns>Chaîne descriptive</returns>
        public override string ToString()
        {
            return valeur.ToString().Substring(0, (valeur.ToString().Length <= 5) ? valeur.ToString().Length : 5);
        }
    }
}
