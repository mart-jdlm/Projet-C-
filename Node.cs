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

        public Node(T valeur, int indice = -1, Node<T> suivant = null)
        {
            this.valeur = valeur;
            this.indice = indice;
            this.suivant = suivant;
        }

        public T Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        public int Indice
        {
            get { return indice; }
        }

        public Node<T> Suivant
        {
            get { return suivant; }
            set { suivant = value; }
        }

        public override string ToString()
        {
            // Vous pouvez adapter cette méthode en fonction du type T
            // Par exemple, en utilisant la méthode ToString() de la valeur
            return valeur.ToString().Substring(0, (valeur.ToString().Length <= 5) ? valeur.ToString().Length : 5);
        }
    }

}
