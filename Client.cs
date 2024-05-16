using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Client : Personne, IComparable<Client>, IIdentification<Client>
    {
        int cagnotte;
        int montant_global = 0;
        /// <summary>
        /// Constructeur avec tous les attributs
        /// </summary>
        /// <param name="ss">numéro de sécurité sociale</param>
        /// <param name="nom">nom</param>
        /// <param name="prenom">prénom</param>
        /// <param name="naissance">date de naissance</param>
        /// <param name="adresse">ville</param>
        /// <param name="mail">mail</param>
        /// <param name="num">numéro de téléphone</param>
        /// <param name="cagnotte">porte-monnaie virtuel</param>
        public Client(string ss, string nom, string prenom, DateTime naissance, string adresse, string mail, string num,int cagnotte) : base(ss,nom,prenom,naissance,adresse,mail,num)
        {
            this.cagnotte = cagnotte;
        }
        /// <summary>
        /// Constructeur simplifié
        /// </summary>
        /// <param name="nom">Nom</param>
        /// <param name="prenom">Prénom</param>
        /// <param name="adresse">Ville</param>
        /// <param name="cagnotte">Porte-monnaie virtuel</param>
        public Client(string nom, string prenom, string adresse, int cagnotte) : base(nom,prenom,adresse)
        {
            this.cagnotte= cagnotte;
        }
        /// <summary>
        /// Propriété porte-monnaie virtuel
        /// </summary>
        public int Cagnotte
        {
            get { return cagnotte; }
            set { cagnotte = value; }
        }
        /// <summary>
        /// Propriété argent cumulé dépensé
        /// </summary>
        public int MontantGlobal
        {
            get { return montant_global;}
            set { montant_global = value;}
        }
        /// <summary>
        /// Méthode de comparaison basée sur le nom des clients
        /// </summary>
        /// <param name="other">Client servant de comparatif</param>
        /// <returns>Entier qui illustre quel client a le nom arrivant en 1er dans l'ordre alpabétique</returns>
        public int CompareTo(Client other)
        {
            if (other == null) return 1;
            return this.Nom.CompareTo(other.Nom);
        }
        /// <summary>
        /// Identifie le client avec son prénom et son nom
        /// </summary>
        /// <param name="c">Client à identifier</param>
        public void IIdentification(Client c)
        {
            Console.WriteLine(c.Prenom+" "+c.Nom);
        }
    }
}
