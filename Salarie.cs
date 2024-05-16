using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Salarie : Personne,IIdentification<Salarie>
    {
        DateTime entree;
        string poste;
        int salaire;
        int experience = 0;
        /// <summary>
        /// Constructeur avec tous les attributs
        /// </summary>
        /// <param name="ss">Numéro de sécurité sociale</param>
        /// <param name="nom">Nom</param>
        /// <param name="prenom">Prénom</param>
        /// <param name="naissance">Date de naissance</param>
        /// <param name="adresse">Ville</param>
        /// <param name="mail">Mail</param>
        /// <param name="num">Numéro de téléphone</param>
        /// <param name="entree">Date de rentrée dans la société</param>
        /// <param name="poste">Métier</param>
        /// <param name="salaire">Salaire</param>
        public Salarie(string ss, string nom, string prenom, DateTime naissance, string adresse, string mail, string num, DateTime entree, string poste, int salaire) : base(ss, nom, prenom, naissance, adresse, mail, num)
        {
            this.entree = entree;
            this.poste = poste;
            this.salaire = salaire;
        }
        /// <summary>
        /// Constructeur simplifié
        /// </summary>
        /// <param name="nom">Nom</param>
        /// <param name="poste">Métier</param>
        public Salarie(string nom, string poste) :base(nom)
        {
            this.poste = poste;
        }
        /// <summary>
        /// Propriété de la date d'embauche dans la société
        /// </summary>
        public DateTime Entree
        {
            get { return entree; }
            set { entree = value; }
        }
        /// <summary>
        /// Propriété du métier
        /// </summary>
        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }
        /// <summary>
        /// Propriété du salaire
        /// </summary>
        public int Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }
        /// <summary>
        /// Propriété du nombre de commandes gérées
        /// </summary>
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        /// <summary>
        /// Identification du salarié avec son prénom et son nom
        /// </summary>
        /// <param name="s">Salarié à identifier</param>
        public void IIdentification(Salarie s)
        {
            Console.WriteLine(s.Prenom + " " + s.Nom);
        }
    }
}
