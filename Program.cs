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
            Client client2 = new Client("Joubert", "Martin",100);
            List<Client> clients = new List<Client> { client1, client2 };
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
    }
}
