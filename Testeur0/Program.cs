using JeuDes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testeur0
{
    class Program
    {
        public static void Titre()
        {
            Console.WriteLine("Jeux à n joueur à n Dés pendant n tours");
        }

        public static void Menu()
        {
            Console.WriteLine("1-Jouer une partie");
            Console.WriteLine("2-Afficher classement (Binaire)");
            Console.WriteLine("3-Afficher classement (Xml)");
            Console.WriteLine("4-Afficher classement (Json)");
            Console.WriteLine("5-Effacer Classement");
            Console.WriteLine("6-Quittez le jeu");
            Program.Moteur();
        }

        public static void Moteur()
        {
            Partie p = new Partie();
            
            //Paramètrage de la partie
            Partie.NombreDes = 3;
            Partie.NombreFaces = 6;
            Partie.NombreTours = 3;
            int NombreJoueur = 2;

            //Sauvegarde de la partie
            Sauvegarde Sauvegarde;

            //Selection du menu
            int SelectionMenu = 0;
            int.TryParse(Console.ReadLine(), out SelectionMenu);

            switch (SelectionMenu)
            {
                case 0: // retour au menu
                default:
                    Console.Clear();
                    RetourMenu();
                    break;
                case 1: //Action de jeu
                    Console.Clear();
                    List<Joueur> ListeJoueurs = new List<Joueur>();
                    for (int i = 0; i < NombreJoueur; i++)
                    {
                        Console.WriteLine("Indiquez un nom de joueur {0}:",i + 1);
                        string Nom = Console.ReadLine();

                        ListeJoueurs.Add(new Joueur(Nom));
                    }

                    p.Joueurs = ListeJoueurs;
                    p.Classement = new Classement();
                    GroupeDe grDes = new GroupeDe();

                    for (int i = 0; i < Partie.NombreTours; i++)
                    {
                        Console.WriteLine("---- Tour {0} ----", i + 1);
                        for (int j = 0; j < ListeJoueurs.Count; j++)
                        {
                            grDes.Lancer();

                            string strCombi = "";
                            bool estEgale = true;
                            for (int k = 0; k < grDes.Des.Count; k++)
                            {
                                if (k > 0)
                                {
                                    if (grDes.Des[k] == grDes.Des[k])
                                        estEgale = false;
                                }
                                strCombi += grDes.Des[k].ToString() + " ";
                            }
                            if (estEgale)
                                p.Joueurs[j].Score += 10;

                            Console.WriteLine(String.Format(" {0,-15} {1}", p.Joueurs[j].Nom, strCombi));
                            Console.WriteLine("{0} a pour score {1}.", p.Joueurs[j].Nom, p.Joueurs[j].Score); 
                        }
                        Console.ReadLine();
                    }

                    //Enregistrement du classemenent dans la sauvegarde
                    for (int i = 0; i < ListeJoueurs.Count; i++)
                    {
                        p.Classement.AjouterEntree(new Entree(p.Joueurs[i].Nom, p.Joueurs[i].Score));
                    }
                    
                    //--------Sauvegarde du classement  
                    //Choix du type de sauvegarde   
                    Partie.SauvegardeType = TypeFichier.Xml;

                    //Recupération de l'objet de type Sauvegarde (Design pattern Factory)
                    Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();

                    //Affectation de l'objet classement de la partie à celui de la sauvegarde
                    Sauvegarde.Classement = p.Classement;

                    //Enregistrement de la sauvegarde
                    Sauvegarde.Ecrire();
                    //------------------------------------

                    Program.RetourMenu();
                    break;
                case 2: //binaire
                    {
                        Console.Clear();
                        Console.WriteLine("Classement:");

                        //----------Recuperation du classement de la sauvegarde
                        Partie.SauvegardeType = TypeFichier.Binaire;
                        Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                        Classement jeuClassement = Sauvegarde.Lire();
                        //------------------------------------------------------

                        //Affichage du classement
                        foreach (Entree e in jeuClassement)
                        {
                            Console.WriteLine(e);
                        }

                        Program.RetourMenu();
                        break;
                    }
                case 3: //xml
                    {
                        Console.Clear();
                        Console.WriteLine("Classement:");

                        //----------Recuperation du classement de la sauvegarde
                        Partie.SauvegardeType = TypeFichier.Xml;
                        Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                        Classement jeuClassement = Sauvegarde.Lire();
                        //------------------------------------------------------

                        //Affichage du classement
                        foreach (Entree e in jeuClassement)
                        {
                            Console.WriteLine(e);
                        }

                        Program.RetourMenu();
                        break;
                    }
                case 4: //Json
                    {
                        Console.Clear();
                        Console.WriteLine("Classement:");

                        //----------Recuperation du classement de la sauvegarde
                        Partie.SauvegardeType = TypeFichier.Json;
                        Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                        Classement jeuClassement = Sauvegarde.Lire();
                        //------------------------------------------------------

                        //Affichage du classement
                        foreach (Entree e in jeuClassement)
                        {
                            Console.WriteLine(e);
                        }

                        Program.RetourMenu();
                        break;
                    }
                case 5: //Effacement des fichiers du classement
                    {
                        Console.Clear();
                        Console.WriteLine("Effacement des classements ? (O)ui ou (N)on");

                        string reponse = Console.ReadLine().ToLower();
                        if (reponse == "o")
                        {
                            File.Create("sav.bin").Close();
                            File.Create("sav.xml").Close();
                            File.Create("sav.json").Close();
                            p.Classement = new Classement();

                            Console.WriteLine("Les classements ont été effacé.");
                            Program.RetourMenu();
                        }
                        break;
                    }
                case 6: // Quitter le  jeu
                    {
                        //Récupération de la sauvegarde existante
                        Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                        Classement jeuClassement = Sauvegarde.Lire();

                        //Sauvegarde de la partie dans tous les fichiers de suavegarde (Design Pattern Strategy)
                        for (int i = 0; i < 3; i++)
                        {
                            Partie.SauvegardeType = (TypeFichier)i;
                            Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                            Sauvegarde.Classement = jeuClassement;
                            Sauvegarde.Ecrire();
                        }
                        break;
                    }
            }
        }

        public static void RetourMenu()
        {
            Console.WriteLine("Appuyer sur la touche entrée pour revenir au menu.");
            Console.ReadLine();
            Console.Clear();
            Program.Titre();
            Program.Menu();
        }

        static void Main(string[] args)
        {
            //Test jeu à 2 Dés
            //Affiche le titre du jeu
            Program.Titre();

            //Affiche Le menu
            Program.Menu();
        }
    }
}
