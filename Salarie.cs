﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    class Salarie : Personne
    {
        DateTime entree;
        string poste;
        int salaire;
        bool dispo = true;
        int experience = 0;
        public Salarie(string ss, string nom, string prenom, DateTime naissance, string adresse, string mail, string num, DateTime entree, string poste, int salaire) : base(ss, nom, prenom, naissance, adresse, mail, num)
        {
            this.entree = entree;
            this.poste = poste;
            this.salaire = salaire;
        }
        public Salarie(string nom, string poste) :base(nom)
        {
            this.poste = poste;
        }
        public DateTime Entree
        {
            get { return entree; }
            set { entree = value; }
        }
        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }
        public int Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }
        public bool Dispo
        {
            get { return dispo; }
            set { dispo=value; }
        }
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
    }
}
