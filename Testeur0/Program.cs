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
            Console.WriteLine("Jeux 1 joueur à 2 Dés");
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
            Sauvegarde Sauvegarde;

            int SelectionMenu = 0;
            int.TryParse(Console.ReadLine(), out SelectionMenu);

            switch (SelectionMenu)
            {
                case 0:
                default:
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Indiquez un nom de joueur:");
                    string Nom = Console.ReadLine();

                    //Liste des Joueurs (1 joueur)
                    List<Joueur> ListeJoueurs = new List<Joueur>();
                    ListeJoueurs.Add(new Joueur(Nom));

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
                            for (int k = 0; k < grDes.Des.Count; k++)
                            {
                                strCombi += grDes.Des[k].ToString() + " ";
                            }
                            Console.WriteLine(String.Format(" {0,-15} {1}", p.Joueurs[j].Nom, strCombi));

                            //Gestion du score pour chaque joueur
                            if(grDes.Des[0] == grDes.Des[1])
                            {
                                p.Joueurs[j].Score += 5;
                            }
                            else if ((grDes.Des[0].Valeur + grDes.Des[1].Valeur) == 7)
                            {
                                p.Joueurs[j].Score += 10;
                            }
                            Console.WriteLine("{0} a pour score {1}.", p.Joueurs[j].Nom, p.Joueurs[j].Score); 
                        }
                        Console.ReadLine();
                    }

                    //Enregistrement du classemenent dans la sauvegarde
                    for (int i = 0; i < ListeJoueurs.Count; i++)
                    {
                        p.Classement.AjouterEntree(new Entree(p.Joueurs[i].Nom, p.Joueurs[i].Score));
                    }
                        
                    Partie.SauvegardeType = TypeFichier.Xml;
                    Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                    Sauvegarde.Classement = p.Classement;
                    Sauvegarde.Ecrire();

                    Program.RetourMenu();
                    break;
                case 2: //Affichage classement binaire
                    {
                        Console.Clear();
                        Console.WriteLine("Classement:");
                        Partie.SauvegardeType = TypeFichier.Binaire;
                        Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                        Classement jeuClassement = Sauvegarde.Lire();

                        foreach (Entree e in jeuClassement)
                        {
                            Console.WriteLine(e);
                        }

                        Program.RetourMenu();
                        break;
                    }
                case 3: //Affichage classement xml
                    {
                        Console.Clear();
                        Console.WriteLine("Classement:");

                        Partie.SauvegardeType = TypeFichier.Xml;
                        Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                        Classement jeuClassement = Sauvegarde.Lire();

                        foreach (Entree e in jeuClassement)
                        {
                            Console.WriteLine(e);
                        }

                        Program.RetourMenu();
                        break;
                    }
                case 4: //Affichage classement Json
                    {
                        Console.Clear();
                        Console.WriteLine("Classement:");

                        Partie.SauvegardeType = TypeFichier.Json;
                        Sauvegarde = ConstructeurSauvegarde.RecupererSauvegarde();
                        Classement jeuClassement = Sauvegarde.Lire();

                        foreach (Entree e in jeuClassement)
                        {
                            Console.WriteLine(e);
                        }

                        Program.RetourMenu();
                        break;
                    }
                case 5: //Affichage classement Json
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

                        //Sauvegarde de la partie dans tous les fichier
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
