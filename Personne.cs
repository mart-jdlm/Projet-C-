using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    abstract class Personne
    {
        string ss;
        string nom;
        string prenom;
        DateTime naissance;
        string adresse;
        string mail;
        string num;
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
        public Personne(string ss, string nom, string prenom, DateTime naissance, string adresse, string mail, string num)
        {
            this.ss = ss;
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adresse = adresse;
            this.mail = mail;
            this.num = num;
        }
        /// <summary>
        /// Constructeur simplifié avec juste un nom en paramètre
        /// </summary>
        /// <param name="nom">Nom</param>
        public Personne(string nom)
        {
            this.nom = nom;
        }
        /// <summary>
        /// Autre constructeur simplifié avec 3 paramètres
        /// </summary>
        /// <param name="nom">Nom</param>
        /// <param name="prenom">Prénom</param>
        /// <param name="adresse">Ville</param>
        public Personne(string nom, string prenom, string adresse)
        {
            this.nom=nom;
            this.prenom = prenom;
            this.adresse = adresse;
        }
        /// <summary>
        /// Propriété du numéro de sécurité sociale
        /// </summary>
        public string SS
        {
            get { return ss; }
            set { ss = value; }
        }
        /// <summary>
        /// Propriété du nom
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        /// <summary>
        /// Propriété du prénom
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        /// <summary>
        /// Propriété de la date de naissance
        /// </summary>
        public DateTime Naissance
        {
            get { return naissance; }
            set { naissance = value; }
        }
        /// <summary>
        /// Propriété de la ville où la personne vit
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        /// <summary>
        /// Propriété du mail
        /// </summary>
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        /// <summary>
        /// Propriété du numéro de téléphone
        /// </summary>
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
    }
}
