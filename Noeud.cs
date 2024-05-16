using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Noeud
    {
        public Salarie Employe { get; set; }
        public List<Noeud> Subordonnes { get; set; }

        public Noeud(Salarie employe)
        {
            Employe = employe;
            Subordonnes = new List<Noeud>();
        }

        // Méthode pour ajouter un subordonné
        public void AjouterSubordonne(Noeud subordonne)
        {
            Subordonnes.Add(subordonne);
        }

        // Méthode pour retirer un subordonné
        public void RetirerSubordonne(Noeud subordonne)
        {
            Subordonnes.Remove(subordonne);
        }
    }
}
