using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Commande
    {
        Client customer;
        string lieu_depart;
        string lieu_arrivee;
        int prix;
        string vehicule;
        Salarie chauffeur;
        DateTime date;
        public Commande(Client customer, string lieu_depart, string lieu_arrivee, string vehicule,Salarie chauffeur, DateTime date)
        {
            this.customer = customer;
            this.lieu_depart = lieu_depart;
            this.lieu_arrivee = lieu_arrivee;
            this.vehicule = vehicule;
            this.chauffeur=chauffeur;
            this.date = date;
            this.prix = 0;
            if (vehicule=="Voiture")
            {
                prix = prix + 20;
            }
            else if (vehicule=="Camionnette")
            {
                prix = prix + 30;
            }
            else
            {
                prix = prix + 50;
            }
        }
        public Client Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        public string Lieu_depart
        {
            get { return lieu_depart; }
            set { lieu_depart = value; }
        }
        public string Lieu_arrivee
        {
            get { return lieu_arrivee; }
            set { lieu_arrivee = value; }
        }
        public int Prix
        {
            get { return prix; }
            set { prix=value;}
        }
        public string Vehicule
        {
            get { return vehicule; }
            set { vehicule = value; }
        }
        public Salarie Chauffeur
        {
            get { return chauffeur; }
            set { chauffeur = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
