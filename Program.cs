namespace HUET_JOUBERT
{
    class Program
    {
        static void Main(string[] args)
        {
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
            List<Client> clients = new List<Client> { client1, client2 };
            Commande commande1 = new Commande(client1, "Paris", "Angers", 57, "camion-citerne", chauffeur, new DateTime(2024, 4, 2));
            Commande commande2 = new Commande(client2, "Paris", "Lyon", 103, "camion benne", chauffeur2, new DateTime(2024, 4, 7));
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
                Console.WriteLine("Achat effectué");
            }
            return chiffre_affaires;
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
    }
}