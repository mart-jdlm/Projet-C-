namespace HUET_JOUBERT
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BDD
            Salarie directeur_general = new Salarie ("Dupond","Directeur Général");
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
            int chiffre_affaires = 0;
            Client client1 = new Client("Huet", "Valentin",100);
            Client client2 = new Client("Joubert", "Martin",200);
            Client client3 = new Client("111111111", "Dupont", "Jean", new DateTime(1980, 5, 15), "Paris", "example1@example.com", "111111111", 100);
            Client client4 = new Client("222222222", "Durand", "Marie", new DateTime(1975, 8, 20), "Lyon", "example2@example.com", "222222222", 150);
            Client client5 = new Client("333333333", "Martin", "Luc", new DateTime(1990, 3, 10), "Marseille", "example3@example.com", "333333333", 200);
            List<Client> clients = new List<Client> { client1, client2, client3, client4, client5 };
            #endregion
            AfficherListeClients(TrierParOrdreAlphabetique(clients));
            string nomfichier = "sauvegarde.txt";
            Sauvegarde(clients, nomfichier);
            Console.ReadLine();
            Commande commande1 = new Commande(client1, "Paris", "Angers", 57, "camion-citerne", chauffeur, new DateTime(2024, 4, 2));
            Commande commande2 = new Commande(client2, "Paris", "Lyon", 103, "camion benne", chauffeur2, new DateTime(2024, 8, 7));
            List<Commande> commandes=new List<Commande> { commande1, commande2 };
            Moyenne_Commandes moyenne_globale = Moyenne_Prix_Commandes;
            Moyenne_Commandes moyenne_specifique = Moyenne_Prix_Grosses_Commandes;
            Console.WriteLine("Moyenne globale : "+moyenne_globale(commandes));
            Console.WriteLine("Moyenne spécifique : "+moyenne_specifique(commandes));
            Console.WriteLine("Moyenne compte clients : " + Moyenne_Comptes_Clients(clients));
            Nombre_livraisons_chauffeur(entreprise);
            chiffre_affaires=Validation_commande(commande1, chiffre_affaires);
            chiffre_affaires=Validation_commande(commande2, chiffre_affaires);
            Console.WriteLine("Chiffres d'affaires après commandes : " + chiffre_affaires);
            foreach (Client c in clients)
            {
                Console.WriteLine("Cagnotte : " + c.Cagnotte);
            }
            Console.WriteLine("Commandes client " + client2.Prenom +" "+client2.Nom+ " :");
            Liste_commandes_client(commandes, client2);
            DateTime debut = new DateTime(2024, 2, 12);
            DateTime fin = new DateTime(2024,5,2);
            Console.WriteLine("Commandes entre le 12 février 2024 et le 2 mai 2024 :");
            Commandes_periode(commandes, debut, fin);
            Console.WriteLine("Commandes entre le début de l'année et maintenant :");
            Commandes_actuelles(commandes);
            string ville = "Paris";
            Console.WriteLine("Commandes partant de la même ville " + ville + " :");
            Commandes_trajet_similaire(commandes, ville);
            Console.WriteLine("Commande la plus rentable : ");
            Commande retour=Commande_rentable(commandes);
            Console.WriteLine("Commande " + retour.Lieu_depart + " vers " + retour.Lieu_arrivee+" à "+retour.Prix+"euros");
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
        static int Validation_commande(Commande achat, int chiffre_affaires)
        {
            if (achat.Chauffeur.Dispo==false)
            {
                Console.WriteLine("Chauffeur indispo ==> Commande impossible");
            }
            else
            {
                chiffre_affaires = chiffre_affaires + achat.Prix;
                achat.Customer.Cagnotte = achat.Customer.Cagnotte - achat.Prix;
                achat.Chauffeur.Experience += 1;
                Console.WriteLine("Achat effectué");
            }
            return chiffre_affaires;
        }
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
                    Console.WriteLine("Commande " + c.Lieu_depart + " vers " + c.Lieu_arrivee);
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
            Commande retour = commandes[0];
            foreach(Commande c in commandes)
            {
                if (c.Prix>retour.Prix)
                {
                    retour= c;
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
        /*public static List<Client> SupprimerClient(List<Client> clients, string supprime)
        {
            for (int i=0;i<clients.Count;i++)
            {
                if (clients[i].Nom==supprime)
                {
                    
                }
            }
            return clients;
        }*/
        public static List<Client> TrierParOrdreAlphabetique(List<Client> clients)
        {
            return clients.OrderBy(client => client.Nom).ThenBy(client => client.Prenom).ToList();
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
                Console.WriteLine($"Nom: {client.Nom}, Prénom: {client.Prenom}, Adresse: {client.Adresse}");
            });
        }

        public static List<Client> TrierParMontantAchatsCumules(List<Client> clients)
        {
            return clients.OrderBy(client => client.MontantGlobal).ToList();
        }
        #endregion
        #region sauvegarde
        static void Sauvegarde(List<Client> clients, string nomfichier)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nomfichier))
                {
                    foreach (var client in clients)
                    {
                        string line = $"{client.SS},{client.Nom},{client.Prenom},{client.Naissance},{client.Adresse},{client.Mail},{client.Num},{client.Cagnotte}";
                        sw.WriteLine(line);
                    }
                }
                Console.WriteLine("Clients saved successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving clients: {e.Message}");
            }
        }

        static List<Client> ImporterClients(string nomfichier)
        {
            List<Client> clients = new List<Client>();

            try
            {
                using (StreamReader sr = new StreamReader(nomfichier))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 8)
                        {
                            string ss = parts[0].Trim();
                            string nom = parts[1].Trim();
                            string prenom = parts[2].Trim();
                            DateTime naissance = DateTime.Parse(parts[3].Trim());
                            string adresse = parts[4].Trim();
                            string mail = parts[5].Trim();
                            string num = parts[6].Trim();
                            int cagnotte = int.Parse(parts[7].Trim());

                            Client client = new Client(ss, nom, prenom, naissance, adresse, mail, num, cagnotte);
                            clients.Add(client);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line: {line}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error reading file: {e.Message}");
            }
            return clients;
        }
        #endregion
    }
}