using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace HUET_JOUBERT
{
    class Program
    {
        /// <summary>
        /// Programme principal de l'application
        /// </summary>
        /// <param name="args">Paramètres C#</param>
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
            Client client1 = new Client("Huet", "Valentin", "Maurepas",100);
            Client client2 = new Client("Joubert", "Martin", "Asnières",200);
            Client client3 = new Client("111111111", "Dupont", "Jean", new DateTime(1980, 5, 15), "Paris", "example1@example.com", "111111111", 100);
            Client client4 = new Client("222222222", "Durand", "Marie", new DateTime(1975, 8, 20), "Lyon", "example2@example.com", "222222222", 150);
            Client client5 = new Client("333333333", "Martin", "Luc", new DateTime(1990, 3, 10), "Marseille", "example3@example.com", "333333333", 200);
            List<Client> clients = new List<Client> { client1, client2, client3, client4, client5 };
            int chiffre_affaires = 0;
            Commande commande1 = new Commande(client1, "Paris", "Angers", 37, "camion-citerne", chauffeur, new DateTime(2024, 4, 2));
            Commande commande2 = new Commande(client2, "Angers", "La Rochelle", 55, "camion benne", chauffeur2, new DateTime(2024, 8, 7));
            chiffre_affaires = Validation_commande(commandes, commande1, chiffre_affaires);
            chiffre_affaires = Validation_commande(commandes, commande2, chiffre_affaires);
            Console.WriteLine();
            Console.WriteLine("Chiffres d'affaires après commandes : " + chiffre_affaires);
            #endregion
            while (rep!=0)
            {
                Console.WriteLine();
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
                                organigramme.AfficherOrganigramme(organigramme.Racine);
                                break;
                            case 2:
                                organigramme.Licencier(chaufeur3);
                                organigramme.AfficherOrganigramme(organigramme.Racine);
                                break;
                            case 3:
                                Salarie chauffeur6 = new Salarie("Rikou", "Chauffeur");
                                organigramme.Embaucher(chauffeur6, organigramme.Racine.Subordonnes[1].Subordonnes[0]);
                                organigramme.AfficherOrganigramme(organigramme.Racine);
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
                                Console.WriteLine();
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
                                Console.WriteLine();
                                Console.WriteLine("Chiffres d'affaires après commandes : " + chiffre_affaires);
                                Console.WriteLine();
                                AfficherCommandes(commandes);
                                Console.WriteLine();
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
            Sauvegarde(commandes, nomfichier);
            Console.ReadLine();
        }
        #region Commande
        /// <summary>
        /// Invalider ou valider une commande et effectuer la transaction
        /// </summary>
        /// <param name="commandes">Liste de toutes les commandes validées</param>
        /// <param name="achat">Commande à potentiellement valider</param>
        /// <param name="chiffre_affaires">Chiffre d'affaires de l'entrprise</param>
        /// <returns>Nouveau chiffre d'affaires de l'entrprise après cette nouvelle commande</returns>
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
                Console.WriteLine();
                Console.WriteLine("Achat effectué");
                Console.WriteLine();
                Console.WriteLine("Chemin : ");
                foreach (string v in GestionDistance.PlusCourtChemin(achat.Lieu_depart, achat.Lieu_arrivee)) Console.WriteLine(v);
                Console.WriteLine();
                Console.WriteLine("Nombre de kilomètres : "+GestionDistance.CalculerDistanceTotale(achat.Lieu_depart,achat.Lieu_arrivee));
                chiffre_affaires = chiffre_affaires + achat.Prix;
                achat.Customer.Cagnotte = achat.Customer.Cagnotte - achat.Prix;
                achat.Customer.MontantGlobal=achat.Customer.MontantGlobal+achat.Prix;
                achat.Chauffeur.Experience += 1;
                commandes.Add(achat);
            }
            return chiffre_affaires;
        }
        /// <summary>
        /// Affiche l'ensemble des commandes déjà validées
        /// </summary>
        /// <param name="commandes">Liste des commandes déjà validées</param>
        static void AfficherCommandes(List<Commande> commandes)
        {
            if (commandes!=null && commandes.Count!=0)
            {
                foreach(Commande c in commandes)
                {
                    Console.WriteLine("Commande " + c.Customer.Nom + " à " + c.Prix + " euros de " + c.Lieu_depart + " à " + c.Lieu_arrivee);
                }
            }
        }
        #endregion
        #region Statistiques
        /// <summary>
        /// Commandes validées durant une certaine période
        /// </summary>
        /// <param name="commandes">Liste de toutes les commandes validées</param>
        /// <param name="debut">Début de cette période à étudier</param>
        /// <param name="fin">Fin de cette période</param>
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
        /// <summary>
        /// Affiche l'ensemble des commandes validées d'un certain client
        /// </summary>
        /// <param name="commandes">Liste de toutes les commndes validées</param>
        /// <param name="c">Client dont on cherche ses commandes</param>
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
        /// <summary>
        /// Affiche le nombre de livraisons effectuées par chaque chauffeur
        /// </summary>
        /// <param name="entreprise">L'ensemble des salariés de l'entreprise dont ses chauffeurs</param>
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
        /// <summary>
        /// Donne la moyenne des portes-monnaies virtuels de l'ensemble des clients
        /// </summary>
        /// <param name="clients">Ensemble de clients</param>
        /// <returns>Valeur moyenne</returns>
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
        /// <summary>
        /// Delegation pour trouver des moyennes des prix de certaines commandes
        /// </summary>
        /// <param name="commandes">Commandes à prendre en considération</param>
        /// <returns>Valur moyenne</returns>
        public delegate double Moyenne_Commandes(List<Commande> commandes);
        /// <summary>
        /// Donne la moyenne des prix de l'ensemble des commandes validées
        /// </summary>
        /// <param name="commandes">Ensemble des commandes validées</param>
        /// <returns>Valeur moyenne</returns>
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
        /// <summary>
        /// Donne la moyenne des prix des commandes de prix supérieur à 100€
        /// </summary>
        /// <param name="commandes">Ensemble des commandes validées</param>
        /// <returns>Valeur moyenne</returns>
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
        /// <summary>
        /// Affiche l'ensemble des commandes de cette année
        /// </summary>
        /// <param name="commandes">Ensemble des commandes validées depuis la création de l'entreprise</param>
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
        /// <summary>
        /// Affiche l'ensemble des commandes partant d'une même ville
        /// </summary>
        /// <param name="commandes">Ensemble des commandes validées</param>
        /// <param name="ville">Ville de départ</param>
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
        /// <summary>
        /// Donne la commande de prix le plus élévé
        /// </summary>
        /// <param name="commandes">Ensemble des commandes validées</param>
        /// <returns>Commande dont le prix est le plus élevé parmi toutes les commandes</returns>
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
        /// <summary>
        /// Ajoute un client dans la liste de tous les clients
        /// </summary>
        /// <param name="clients">Liste de tous les clients déjà recensés</param>
        /// <param name="ajout">Client à ajouter</param>
        /// <returns>Nouvelle liste avec le client rajouté</returns>
        public static List<Client> AjouterClient(List<Client> clients, Client ajout)
        {
            clients.Add(ajout);
            return clients;
        }
        /// <summary>
        /// Retire un client qui n'existe plus
        /// </summary>
        /// <param name="clients">Liste de tous les clients de l'entreprise</param>
        /// <param name="supprime">Client à retirer</param>
        /// <returns>Nouvelle liste sans le client en question</returns>
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
        /// <summary>
        /// Modifie un attribut d'un client
        /// </summary>
        /// <param name="c">Client à modifier</param>
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
        /// <summary>
        /// Trier les clients par ordre alphabétique
        /// </summary>
        /// <param name="clients">Tous les clients de l'entreprise</param>
        /// <returns>Liste nouvellement ordonnée</returns>
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
        /// <summary>
        /// Trie les par leur ville
        /// </summary>
        /// <param name="clients">Tous les clients de l'entreprise</param>
        /// <returns>Liste nouvellement ordonnée</returns>
        // Fonction pour trier une liste de clients par ville
        public static List<Client> TrierParVille(List<Client> clients)
        {
            return clients.OrderBy(client => client.Adresse).ToList();
        }
        /// <summary>
        /// Affiche l'ensemble des clients
        /// </summary>
        /// <param name="clients">Tous les clients de l'entreprise</param>
        public static void AfficherListeClients(List<Client> clients)
        {
            clients.ForEach(client =>
            {
                Console.WriteLine($"Nom: {client.Nom}, Prénom: {client.Prenom}, Cagnotte: {client.Cagnotte}, Montant global: {client.MontantGlobal}, Adresse: {client.Adresse}");
            });
        }
        /// <summary>
        /// Trie les clients par fidélité (selon leur argent dépensé dans cette entreprise)
        /// </summary>
        /// <param name="clients">Tous les clients de l'entreprise</param>
        /// <returns>Liste nouvellement ordonnée</returns>
        public static List<Client> TrierParMontantAchatsCumules(List<Client> clients)
        {
            return clients.OrderBy(client => client.MontantGlobal).ToList();
        }
        #endregion
        #region Sauvegarde
        /// <summary>
        /// Sauvegarde l'ensemble des commandes validées dans un fichier
        /// </summary>
        /// <param name="commandes">Toutes les commandes validées</param>
        /// <param name="nomfichier">Nom du fichier de recensement</param>
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
        /// <summary>
        /// Récupère les commandes présentes dans un fichier
        /// </summary>
        /// <param name="nomfichier">Fichier contenant les commandes à extraire</param>
        /// <returns>Ensemble des commandes récupérées</returns>
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