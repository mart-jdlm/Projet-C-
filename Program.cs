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
            Client client2 = new Client("Joubert", "Martin",100);
            Client client3 = new Client("111111111", "Dupont", "Jean", new DateTime(1980, 5, 15), "Paris", "example1@example.com", "111111111", 100);
            Client client4 = new Client("222222222", "Durand", "Marie", new DateTime(1975, 8, 20), "Lyon", "example2@example.com", "222222222", 150);
            Client client5 = new Client("333333333", "Martin", "Luc", new DateTime(1990, 3, 10), "Marseille", "example3@example.com", "333333333", 200);

            List<Client> clients = new List<Client> { client1, client2, client3, client4, client5 };
            #endregion

            AfficherListeClients(TrierParOrdreAlphabetique(clients));
            string nomfichier = "sauvegarde.txt";
            Sauvegarde(clients, nomfichier);
            Console.ReadLine();
        }
        static void Recrutement_chef_equipe (Salarie nouveau)
        {

        }
        static void Recrutement_chaffeur (Salarie nouveau)
        {

        }
        static void Visualisation (List<Salarie> entreprise)
        {

        }
        static void Validation_commande(Commande achat, int chiffre_affaires)
        {
            if (achat.Chauffeur.Dispo==false)
            {
                Console.WriteLine("Chauffeur indispo ==> Commande impossible");
            }
            else
            {
                chiffre_affaires = chiffre_affaires + achat.Prix;
                achat.Customer.Cagnotte = achat.Customer.Cagnotte - achat.Prix;
                Console.WriteLine("Achat effectué");
            }
        }
        #region gestion clients
        public static List<Client> TrierParOrdreAlphabetique(List<Client> clients)
        {
            return clients.OrderBy(client => client.Nom).ThenBy(client => client.Prenom).ToList();
        }
        // Fonction pour trier une liste de clients par ville

        /// Méthode pour afficher une liste de clients en utilisant List.ForEach
        public static void AfficherListeClients(List<Client> clients)
        {
            clients.ForEach(client =>
            {
                Console.WriteLine($"Nom: {client.Nom}, Prénom: {client.Prenom}, Adresse: {client.Adresse}");
            });
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
