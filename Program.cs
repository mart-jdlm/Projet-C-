using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace HUET_JOUBERT
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BDD
            int rep = 15;
            List<Commande> commandes = new List<Commande> { };
            Salarie directeur_general = new Salarie("Dupond", "Directeur Général");
            Salarie directrice_commerciale = new Salarie("Fiesta", "Directrice Commerciale");
            Salarie directeur_operations = new Salarie("Fetard", "Directeur des opérations");
            Salarie directrice_RH = new Salarie("Joyeuse", "Directrice des RH");
            Salarie directeur_financier = new Salarie("GripSous", "Directeur Financier");
            Salarie commercial = new Salarie("Forge", "Commercial");
            Salarie commerciale = new Salarie("Fermi", "Commerciale");
            Salarie chef_equipe = new Salarie("Royal", "Chef Equipe");
            Salarie chef_equipe2 = new Salarie("Prince", "Chef d'Equipe");
            Salarie chauffeur = new Salarie("Romu", "Chauffeur");
            Salarie chauffeur2 = new Salarie("Romi", "Chauffeur");
            Salarie chaufeur3 = new Salarie("Roma", "Chauffeur");
            Salarie chauffeur4 = new Salarie("Rome", "Chauffeur");
            Salarie chauffeur5 = new Salarie("Rimou", "Chauffeur");
            Salarie formation = new Salarie("Couleur", "Formation");
            Salarie contrats = new Salarie("ToutleMonde", "Contrats");
            Salarie direction_comptable = new Salarie("Picsou", "Direction comptable");
            Salarie controleur_gestion = new Salarie("GrousSous", "Controleur de Gestion");
            Salarie comptable = new Salarie("Fournier", "Comptable");
            Salarie comptable2 = new Salarie("Gautier", "Comptable");
            List<Salarie> entreprise = new List<Salarie> { directeur_general, directrice_commerciale, directeur_operations, directrice_RH, directeur_financier, commercial, commerciale, chef_equipe, chef_equipe2, chauffeur, chauffeur2, chaufeur3, chauffeur4, chauffeur5, formation, contrats, direction_comptable, controleur_gestion, comptable, comptable2 };
            Organigramme organigramme = new Organigramme(directeur_general);

            // Embauche des employés
            organigramme.Embaucher(directrice_commerciale, organigramme.Racine);
            organigramme.Embaucher(directeur_operations, organigramme.Racine);
            organigramme.Embaucher(directrice_RH, organigramme.Racine);
            organigramme.Embaucher(directeur_financier, organigramme.Racine);

            organigramme.Embaucher(commercial, organigramme.Racine.Subordonnes[0]);
            organigramme.Embaucher(commerciale, organigramme.Racine.Subordonnes[0]);
            organigramme.Embaucher(chef_equipe, organigramme.Racine.Subordonnes[1]);
            organigramme.Embaucher(chef_equipe2, organigramme.Racine.Subordonnes[1]);

            organigramme.Embaucher(chauffeur, organigramme.Racine.Subordonnes[1].Subordonnes[0]);
            organigramme.Embaucher(chauffeur2, organigramme.Racine.Subordonnes[1].Subordonnes[0]);
            organigramme.Embaucher(chaufeur3, organigramme.Racine.Subordonnes[1].Subordonnes[0]);
            organigramme.Embaucher(chauffeur4, organigramme.Racine.Subordonnes[1].Subordonnes[1]);
            organigramme.Embaucher(chauffeur5, organigramme.Racine.Subordonnes[1].Subordonnes[1]);

            organigramme.Embaucher(formation, organigramme.Racine.Subordonnes[2]);
            organigramme.Embaucher(contrats, organigramme.Racine.Subordonnes[2]);
            organigramme.Embaucher(direction_comptable, organigramme.Racine.Subordonnes[3]);
            organigramme.Embaucher(controleur_gestion, organigramme.Racine.Subordonnes[3]);
            organigramme.Embaucher(comptable, organigramme.Racine.Subordonnes[3].Subordonnes[0]);
            organigramme.Embaucher(comptable2, organigramme.Racine.Subordonnes[3].Subordonnes[0]);

            // Affichage de l'organigramme
            organigramme.AfficherOrganigramme(organigramme.Racine);
            Client client1 = new Client("Huet", "Valentin", "Maurepas",100);
            Client client2 = new Client("Joubert", "Martin", "Asnières",200);
            Client client3 = new Client("111111111", "Dupont", "Jean", new DateTime(1980, 5, 15), "Paris", "example1@example.com", "111111111", 100);
            Client client4 = new Client("222222222", "Durand", "Marie", new DateTime(1975, 8, 20), "Lyon", "example2@example.com", "222222222", 150);
            Client client5 = new Client("333333333", "Martin", "Luc", new DateTime(1990, 3, 10), "Marseille", "example3@example.com", "333333333", 200);
            List<Client> clients = new List<Client> { client1, client2, client3, client4, client5 };
            Noeud noeud = new Noeud(directeur_general);
            Organigramme orga = new Organigramme(directeur_general);
            int chiffre_affaires = 0;
            Commande commande1 = new Commande(client1, "Paris", "Angers", 37, "camion-citerne", chauffeur, new DateTime(2024, 4, 2));
            Commande commande2 = new Commande(client2, "Angers", "Lyon", 55, "camion benne", chauffeur2, new DateTime(2024, 8, 7));
            chiffre_affaires = Validation_commande(commandes, commande1, chiffre_affaires);
            chiffre_affaires = Validation_commande(commandes, commande2, chiffre_affaires);
            Console.WriteLine("Chiffres d'affaires après commandes : " + chiffre_affaires);
            #endregion
            while (rep!=0)
            {
                Console.WriteLine("A quel module souhaitez-vous accéder ?");
                Console.WriteLine("1:Clients ; 2:Salariés ; 3:Commandes ; 4:Statistiques ; 5:Autres ; 0:Quitter l'appli");
                rep = Convert.ToInt32(Console.ReadLine());
                switch (rep)
                {
                    case 1:
                        Console.WriteLine("1:Entrer client ; 2:Supprimer client ; 3:Modifier client ; 4:Tri par ordre alphabétique ; 5:Tri par ville ; 6:Tri par montant des achats cumulés");
                        int repclient = Convert.ToInt32(Console.ReadLine());
                        switch(repclient)
                        {
                            case 1:
                                Console.WriteLine("Entrer son nom");
                                string nom_client=Console.ReadLine();
                                Console.WriteLine("Entrer son prénom");
                                string prenom_client=Console.ReadLine();
                                Console.WriteLine("Entrer sa ville");
                                string adresse_client=Console.ReadLine();
                                Console.WriteLine("Entrer sa cagnotte");
                                int cagnotte_client=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                AfficherListeClients(AjouterClient(clients, new Client(nom_client,prenom_client,adresse_client,cagnotte_client)));
                                break;
                            case 2:
                                Console.WriteLine("Entrer le nom du client à supprimer");
                                string nom_supp=Console.ReadLine();
                                AfficherListeClients(SupprimerClient(clients, nom_supp));
                                break;
                            case 3:
                                ModifierClient(client5);
                                AfficherListeClients(clients);
                                break;
                            case 4:
                                AfficherListeClients(TrierParOrdreAlphabetique(clients));
                                break;
                            case 5:
                                AfficherListeClients(TrierParVille(clients));
                                break;        
                            case 6:
                                AfficherListeClients(TrierParMontantAchatsCumules(clients));
                                break;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("1:Affichage organigramme ; 2:Licencier ; 3:Recruter");
                        int rep_salaries = Convert.ToInt32(Console.ReadLine());
                        switch (rep_salaries)
                        {
                            case 1:
                                orga.AfficherOrganigramme(noeud, "");
                                break;
                            case 2:
                                orga.Licencier(chaufeur3);
                                orga.AfficherOrganigramme(noeud, "");
                                break;
                            case 3:
                                Salarie chauffeur6 = new Salarie("Rikou", "Chauffeur");
                                orga.Embaucher(chauffeur6, new Noeud(chef_equipe));
                                break;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("1:Commande pré-définie ; 2:Commande à écrire");
                        int rep_commande = Convert.ToInt32(Console.ReadLine());
                        switch (rep_commande)
                        {
                            case 1:
                                Commande commande3 = new Commande(client2, "Paris", "Lyon", 68, "Voiture", chauffeur2, new DateTime(2024, 9, 6));
                                chiffre_affaires = Validation_commande(commandes, commande3, chiffre_affaires);
                                foreach (Client c in clients)
                                {
                                    Console.WriteLine("Cagnotte " + c.Nom + " : " + c.Cagnotte);
                                }
                                Console.WriteLine("Chiffres d'affaires après commandes : " + chiffre_affaires);
                                Console.WriteLine();
                                AfficherCommandes(commandes);
                                break;
                            case 2:
                                Console.WriteLine("Entrer le lieu de départ");
                                string rep_lieu_dep=Console.ReadLine();
                                Console.WriteLine("Entrer le lieu d'arrivée");
                                string rep_lieu_arr=Console.ReadLine();
                                Console.WriteLine("Entrer le prix");
                                int rep_prix=Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Entrer le véhicule (Voiture, Camionnette, ou autres)");
                                string rep_vehicule=Console.ReadLine();
                                Commande commande4 = new Commande(client1, rep_lieu_dep, rep_lieu_arr, rep_prix, rep_vehicule, chauffeur, DateTime.Now);
                                chiffre_affaires = Validation_commande(commandes, commande4, chiffre_affaires);
                                foreach (Client c in clients)
                                {
                                    Console.WriteLine("Cagnotte " + c.Nom + " : " + c.Cagnotte);
                                }
                                Console.WriteLine("Chiffres d'affaires après commandes : " + chiffre_affaires);
                                Console.WriteLine();
                                AfficherCommandes(commandes);
                                break;
                        }      
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Nombre de livraisons déjà effectuées par chaque chauffeur");
                        Nombre_livraisons_chauffeur(entreprise);
                        Console.WriteLine();
                        DateTime debut = new DateTime(2024, 2, 12);
                        DateTime fin = new DateTime(2024, 5, 2);
                        Console.WriteLine("Commandes entre le 12 février 2024 et le 2 mai 2024 :");
                        Commandes_periode(commandes, debut, fin);
                        Console.WriteLine();
                        Moyenne_Commandes moyenne_globale = Moyenne_Prix_Commandes;
                        Console.WriteLine("Moyenne des prix de toutes les commandes : " + moyenne_globale(commandes));
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Moyenne compte clients : " + Moyenne_Comptes_Clients(clients));
                        Console.WriteLine();
                        Console.WriteLine("Commandes client " + client2.Prenom + " " + client2.Nom + " :");
                        Liste_commandes_client(commandes, client2);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine();
                        Moyenne_Commandes moyenne_specifique = Moyenne_Prix_Grosses_Commandes;
                        Console.WriteLine("Moyenne des prix des plus grosses commandes : " + moyenne_specifique(commandes));
                        Console.WriteLine();
                        Console.WriteLine("Commandes entre le début de l'année et maintenant :");
                        Commandes_actuelles(commandes);
                        Console.WriteLine();
                        string ville = "Paris";
                        Console.WriteLine("Commandes partant de la même ville " + ville + " :");
                        Commandes_trajet_similaire(commandes, ville);
                        Console.WriteLine();
                        Console.WriteLine("Commande la plus rentable : ");
                        Commande retour = Commande_rentable(commandes);
                        if (retour!=null)
                        {
                            Console.WriteLine("Commande " + retour.Lieu_depart + " vers " + retour.Lieu_arrivee + " à " + retour.Prix + "euros");
                        }                     
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            string nomfichier = "sauvegarde.txt";
            Sauvegarde(clients, nomfichier);
            Console.ReadLine();
        }
        #region Salarie
        static void Recrutement_chef_equipe (Salarie nouveau)
        {

        }
        static void Licenciement_chef_equipe(Salarie licencie)
        {

        }
        static void Recrutement_chauffeur (Salarie nouveau)
        {

        }
        static void Licenciement_chauffeur(Salarie licencie)
        {

        }
        static void Visualisation (List<Salarie> entreprise)
        {

        }
        #endregion
        #region Commande
        static int Validation_commande(List<Commande> commandes, Commande achat, int chiffre_affaires)
        {
            bool declencheur = false;
            {
                if (commandes != null && commandes.Count != 0)
                {
                    foreach (Commande c in commandes)
                    {
                        if (achat.Chauffeur.Nom == c.Chauffeur.Nom && achat.Date == c.Date)
                        {
                            Console.WriteLine("Chauffeur indispo ==> Commande impossible");
                            declencheur = true;
                        }
                    }
                }
            }
            if (declencheur == false)
            {
                chiffre_affaires = chiffre_affaires + achat.Prix;
                achat.Customer.Cagnotte = achat.Customer.Cagnotte - achat.Prix;
                achat.Chauffeur.Experience += 1;
                commandes.Add(achat);
                Console.WriteLine("Achat effectué");
            }
            return chiffre_affaires;
        }
        static void AfficherCommandes(List<Commande> commandes)
        {
            if (commandes!=null && commandes.Count!=0)
            {
                foreach(Commande c in commandes)
                {
                    Console.WriteLine("Commande " + c.Customer.Nom + " à " + c.Prix + " de " + c.Lieu_depart + " à " + c.Lieu_arrivee);
                }
            }
        }
        #endregion
        #region Statistiques
        static void Commandes_periode (List<Commande> commandes, DateTime debut, DateTime fin)
        {
            foreach(Commande c in commandes)
            {
                if(c.Date>debut && c.Date<fin)
                {
                    Console.WriteLine("Commande " + c.Lieu_depart + " vers " + c.Lieu_arrivee);
                }
            }
        }
        static void Liste_commandes_client(List<Commande> commandes, Client c)
        {
            foreach(Commande com in commandes)
            {
                if (com.Customer==c && com.Date>DateTime.Now)
                {
                    Console.WriteLine("Commande "+com.Lieu_depart+" vers " +com.Lieu_arrivee);
                }
            }
        }
        static void Nombre_livraisons_chauffeur(List<Salarie> entreprise)
        {
            foreach (Salarie s in entreprise)
            {
                if (s.Poste=="Chauffeur")
                {
                    Console.WriteLine(s.Nom+" : "+s.Experience+" livraisons déjà effectuées");
                }             
            }
        }
        public static double Moyenne_Comptes_Clients(List<Client> clients)
        {
            double moyenne = 0.0;
            foreach(Client c in clients)
            {
                moyenne = moyenne + c.Cagnotte;
            }
            moyenne = moyenne / clients.Count;
            return moyenne;
        }
        public delegate double Moyenne_Commandes(List<Commande> commandes);
        public static double Moyenne_Prix_Commandes(List<Commande> commandes)
        {
            double moyenne = 0.0;
            foreach (Commande c in commandes)
            {
                moyenne=moyenne+c.Prix;
            }
            moyenne= moyenne / commandes.Count;
            return moyenne;
        }
        #endregion
        #region Autre
        public static double Moyenne_Prix_Grosses_Commandes(List<Commande> commandes)
        {
            double moyenne = 0.0;
            double nbr = 0.0;
            foreach (Commande c in commandes)
            {
                if (c.Prix>100)
                {
                    moyenne=moyenne+c.Prix;
                    nbr=nbr+1.0;
                }
            }
            moyenne = moyenne / nbr;
            return moyenne;
        }
        static void Commandes_actuelles(List<Commande> commandes)
        {
            foreach (Commande c in commandes)
            {
                if (c.Date>new DateTime(DateTime.Now.Year,1,1) && c.Date<DateTime.Now)
                {
                    Console.WriteLine("Commande " + c.Lieu_depart + " vers " + c.Lieu_arrivee+" pour "+c.Customer.Prenom+" "+c.Customer.Nom);
                }
            }
        }
        static void Commandes_trajet_similaire(List<Commande> commandes, string ville)
        {
            foreach (Commande c in commandes)
            {
                if (c.Lieu_depart==ville)
                {
                    Console.WriteLine("Commande " + c.Lieu_depart + " vers " + c.Lieu_arrivee);
                }
            }
        }
        static Commande Commande_rentable(List<Commande> commandes)
        {
            Commande retour = null;
            if (commandes != null && commandes.Count!=0)
            {
                retour = commandes[0];
                foreach (Commande c in commandes)
                {
                    if (c.Prix > retour.Prix)
                    {
                        retour = c;
                    }
                }
            }
            return retour;
        }
        #endregion
        #region Client
        public static List<Client> AjouterClient(List<Client> clients, Client ajout)
        {
            clients.Add(ajout);
            return clients;
        }
        public static List<Client> SupprimerClient(List<Client> clients, string supprime)
        {
            foreach(Client c in clients)
            {
                if (c.Nom==supprime)
                {
                    clients.Remove(c);
                    return clients;
                }
            }
            return clients;
        }
        public static void ModifierClient(Client c)
        {
            Console.WriteLine("Quel attribut voulez-vous modifier ?");
            Console.WriteLine("1:ss, 2:nom, 3:prenom, 4:adresse, 5:mail ou 6:num");
            int rep = Convert.ToInt32(Console.ReadLine());
            string modif=Console.ReadLine();
            switch (rep)
            {
                case 1:
                    c.SS = modif;
                    break;
                case 2:
                    c.Nom = modif;
                    break;
                case 3:
                    c.Prenom = modif;
                    break;
                case 4:
                    c.Adresse = modif;
                    break;
                case 5:
                    c.Mail = modif;
                    break;
                case 6:
                    c.Num = modif;
                    break;
            }
        }
        static List<Client> TrierParOrdreAlphabetique(List<Client> clients)
        {
            int n = clients.Count;
            for (int i = 1; i < n; i++)
            {
                Client comparaison = clients[i];
                int j = i - 1;
                while (j >= 0 && clients[j].CompareTo(comparaison) > 0)
                {
                    clients[j + 1] = clients[j];
                    j = j - 1;
                }
                clients[j + 1] = comparaison;
            }
            return clients;
        }
        // Fonction pour trier une liste de clients par ville
        public static List<Client> TrierParVille(List<Client> clients)
        {
            return clients.OrderBy(client => client.Adresse).ToList();
        }

        /// Méthode pour afficher une liste de clients en utilisant List.ForEach
        public static void AfficherListeClients(List<Client> clients)
        {
            clients.ForEach(client =>
            {
                Console.WriteLine($"Nom: {client.Nom}, Prénom: {client.Prenom}, Cagnotte: {client.Cagnotte}, Montant global: {client.MontantGlobal}, Adresse: {client.Adresse}");
            });
        }
        public static List<Client> TrierParMontantAchatsCumules(List<Client> clients)
        {
            return clients.OrderBy(client => client.MontantGlobal).ToList();
        }
        #endregion
        #region sauvegarde
        static void Sauvegarde(List<Commande> commandes, string nomfichier)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nomfichier))
                {
                    foreach (var commande in commandes)
                    {
                        string line = $"{commande.Lieu_depart},{commande.Lieu_arrivee},{commande.Prix},{commande.Vehicule},{commande.Date}";
                        sw.WriteLine(line);
                    }
                }
                Console.WriteLine("Commandes saved successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving commandes: {e.Message}");
            }
        }


        static List<Commande> ChargerCommandes(string nomfichier)
        {
            List<Commande> commandes = new List<Commande>();

            try
            {
                using (StreamReader sr = new StreamReader(nomfichier))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');

                        // Créer un objet Commande à partir des données lues
                        Commande commande = new Commande(
                            null, // Client non sauvegardé
                            values[0],
                            values[1],
                            int.Parse(values[2]),
                            values[3],
                            null, // Chauffeur non sauvegardé
                            DateTime.Parse(values[4])
                        );

                        commandes.Add(commande);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading commandes: {e.Message}");
            }

            return commandes;
        }
        #endregion
    }
}
