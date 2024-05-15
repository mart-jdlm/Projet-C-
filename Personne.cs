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
        public Personne(string nom)
        {
            this.nom = nom;
        }
        public Personne(string nom, string prenom)
        {
            this.nom=nom;
            this.prenom = prenom;
        }
        public string SS
        {
            get { return ss; }
            set { ss = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public DateTime Naissance
        {
            get { return naissance; }
            set { naissance = value; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
    }
}
