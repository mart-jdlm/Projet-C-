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
        public Client(string ss, string nom, string prenom, DateTime naissance, string adresse, string mail, string num,int cagnotte) : base(ss,nom,prenom,naissance,adresse,mail,num)
        {
            this.cagnotte = cagnotte;
        }
        public Client(string nom, string prenom, string adresse, int cagnotte) : base(nom,prenom,adresse)
        {
            this.cagnotte= cagnotte;
        }
        public int Cagnotte
        {
            get { return cagnotte; }
            set { cagnotte = value; }
        }
        public int MontantGlobal
        {
            get { return montant_global;}
            set { montant_global = value;}
        }
        public int CompareTo(Client other)
        {
            if (other == null) return 1;
            return this.Nom.CompareTo(other.Nom);
        }
        public void IIdentification(Client c)
        {
            Console.WriteLine(c.Prenom+" "+c.Nom);
        }
    }
}
