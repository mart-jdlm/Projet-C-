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
        /// <summary>
        /// Constructeur avec tous les attributs
        /// </summary>
        /// <param name="customer">Client associé</param>
        /// <param name="lieu_depart">Lieu de départ</param>
        /// <param name="lieu_arrivee">Lieu de réception</param>
        /// <param name="prix">Prix</param>
        /// <param name="vehicule">Véhicule utilisé</param>
        /// <param name="chauffeur">Chauffeur</param>
        /// <param name="date">Date de la livraison</param>
        public Commande(Client customer, string lieu_depart, string lieu_arrivee, int prix, string vehicule,Salarie chauffeur, DateTime date)
        {
            this.customer = customer;
            this.lieu_depart = lieu_depart;
            this.lieu_arrivee = lieu_arrivee;
            this.vehicule = vehicule;
            this.chauffeur = chauffeur;
            this.date = date;
            this.prix = prix;
            if (vehicule == "Voiture")
            {
                this.prix = this.prix + 20;
            }
            else if (vehicule == "Camionnette")
            {
                this.prix = this.prix + 30;
            }
            else
            {
                this.prix = this.prix + 50;
            }
            if (GestionDistance.CalculerDistanceTotale(lieu_depart,lieu_arrivee)<200)
            {
                this.prix=this.prix+ 20;
            }
            else if (GestionDistance.CalculerDistanceTotale(lieu_depart,lieu_arrivee)>=200 && GestionDistance.CalculerDistanceTotale(lieu_depart,lieu_arrivee)<300)
            {
                this.prix=this.prix+ 30;
            }
            else
            {
                this.prix=this.prix+ 50;
            }
        }
        /// <summary>
        /// Propriété Client
        /// </summary>
        public Client Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        /// <summary>
        /// Propriété lieu de départ 
        /// </summary>
        public string Lieu_depart
        {
            get { return lieu_depart; }
            set { lieu_depart = value; }
        }
        /// <summary>
        /// Propriété lieu de réception
        /// </summary>
        public string Lieu_arrivee
        {
            get { return lieu_arrivee; }
            set { lieu_arrivee = value; }
        }
        /// <summary>
        /// Propriété prix
        /// </summary>
        public int Prix
        {
            get { return prix; }
            set { prix=value;}
        }
        /// <summary>
        /// Propriété véhicule utilisé
        /// </summary>
        public string Vehicule
        {
            get { return vehicule; }
            set { vehicule = value; }
        }
        /// <summary>
        /// Propriété chauffeur
        /// </summary>
        public Salarie Chauffeur
        {
            get { return chauffeur; }
            set { chauffeur = value; }
        }
        /// <summary>
        /// Propriété date de livraison
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
