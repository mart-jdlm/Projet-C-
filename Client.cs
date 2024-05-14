using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Client : Personne
    {
        int cagnotte;
        int montant_global = 0;
        public Client(string ss, string nom, string prenom, DateTime naissance, string adresse, string mail, string num,int cagnotte) : base(ss,nom,prenom,naissance,adresse,mail,num)
        {
            this.cagnotte = cagnotte;
        }
        public Client(string nom, string prenom, int cagnotte) : base(nom,prenom)
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
    }
}
