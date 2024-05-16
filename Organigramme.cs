using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Organigramme
    {
        /// <summary>
        /// Propriété de la racine de l'organigramme
        /// </summary>
        public Noeud Racine { get; set; }
        /// <summary>
        /// Constructeur de l'organigramme à partir du patron
        /// </summary>
        /// <param name="employeRacine">Patron en haut de l'organigramme</param>
        public Organigramme(Salarie employeRacine)
        {
            Racine = new Noeud(employeRacine);
        }
        /// <summary>
        /// Ajoute un salarié embauché dans l'organigramme
        /// </summary>
        /// <param name="nouvelEmploye">Employé recruté à ajouter</param>
        /// <param name="manager">Son n+1</param>
        public void Embaucher(Salarie nouvelEmploye, Noeud manager)
        {
            Noeud nouveauNoeud = new Noeud(nouvelEmploye);
            manager.AjouterSubordonne(nouveauNoeud);
        }
        /// <summary>
        /// Trouver le noeud correspondant à un certain employé recherché
        /// </summary>
        /// <param name="noeudCourant">Noeud à étudier</param>
        /// <param name="employe">Employé à retrouver</param>
        /// <returns>Noeud associé à la place de l'employé dans l'organigramme</returns>
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
        /// <summary>
        /// Retire de l'organigramme un employé viré 
        /// </summary>
        /// <param name="employe">Employé viré à retirer</param>
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
        /// <summary>
        /// Trouver le n+1 d'un employé
        /// </summary>
        /// <param name="noeudCourant">Noeud à étudier</param>
        /// <param name="employe">Employé dont on cherche son n+1</param>
        /// <returns>Noeud associé au n+1 de l'employé en paramètre</returns>
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
        /// <summary>
        /// Affiche l'organigramme
        /// </summary>
        /// <param name="noeud">Noeud dans lequel passera chaque employé</param>
        /// <param name="prefixe">Délimitateur</param>
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
