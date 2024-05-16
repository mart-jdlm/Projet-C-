using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Organigramme
    {
        public Noeud Racine { get; set; }

        public Organigramme(Salarie employeRacine)
        {
            Racine = new Noeud(employeRacine);
        }

        // Méthode pour embaucher un employé et l'ajouter à l'organigramme
        public void Embaucher(Salarie nouvelEmploye, Noeud manager)
        {
            Noeud nouveauNoeud = new Noeud(nouvelEmploye);
            manager.AjouterSubordonne(nouveauNoeud);
        }

        // Méthode récursive pour trouver un employé dans l'organigramme
        private Noeud TrouverNoeud(Noeud noeudCourant, Salarie employe)
        {
            if (noeudCourant.Employe == employe)
            {
                return noeudCourant;
            }

            foreach (Noeud sousNoeud in noeudCourant.Subordonnes)
            {
                Noeud noeudTrouve = TrouverNoeud(sousNoeud, employe);
                if (noeudTrouve != null)
                {
                    return noeudTrouve;
                }
            }

            return null;
        }

        // Méthode pour licencier un employé et le retirer de l'organigramme
        public void Licencier(Salarie employe)
        {
            // Recherche de l'employé dans l'organigramme
            Noeud noeud = TrouverNoeud(Racine, employe);
            if (noeud != null)
            {
                // Retrait de l'employé de son manager
                Noeud parent = TrouverParent(Racine, employe);
                if (parent != null)
                {
                    parent.RetirerSubordonne(noeud);
                }
            }
        }

        // Méthode récursive pour trouver le parent d'un employé dans l'organigramme
        private Noeud TrouverParent(Noeud noeudCourant, Salarie employe)
        {
            foreach (Noeud sousNoeud in noeudCourant.Subordonnes)
            {
                if (sousNoeud.Employe == employe)
                {
                    return noeudCourant;
                }
                else
                {
                    Noeud parent = TrouverParent(sousNoeud, employe);
                    if (parent != null)
                    {
                        return parent;
                    }
                }
            }

            return null;
        }
        // Méthode pour afficher l'organigramme
        public void AfficherOrganigramme(Noeud noeud, string prefixe = "")
        {
            if (noeud == null) return;

            Console.WriteLine(prefixe + "└── " + noeud.Employe.Nom + " : " + noeud.Employe.Poste);

            foreach (Noeud sousNoeud in noeud.Subordonnes)
            {
                AfficherOrganigramme(sousNoeud, prefixe + "    ");
            }
        }
    }
}
