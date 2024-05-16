using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Noeud
    {
        /// <summary>
        /// Propriété de l'employé
        /// </summary>
        public Salarie Employe { get; set; }
        /// <summary>
        /// Propriété de la liste des n-1 dans la hiérarchie
        /// </summary>
        public List<Noeud> Subordonnes { get; set; }
        /// <summary>
        /// Constructeur à partir d'un employé
        /// </summary>
        /// <param name="employe">Empoyé</param>
        public Noeud(Salarie employe)
        {
            Employe = employe;
            Subordonnes = new List<Noeud>();
        }
        /// <summary>
        /// Ajouter un n-1
        /// </summary>
        /// <param name="subordonne">Salarié n-1 à ajouter</param>
        public void AjouterSubordonne(Noeud subordonne)
        {
            Subordonnes.Add(subordonne);
        }
        /// <summary>
        /// Retirer un n-1
        /// </summary>
        /// <param name="subordonne">Salarié n-1 à retirer</param>
        public void RetirerSubordonne(Noeud subordonne)
        {
            Subordonnes.Remove(subordonne);
        }
    }
}
