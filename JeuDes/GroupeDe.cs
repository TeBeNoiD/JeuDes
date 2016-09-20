using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Jeu de dés 
/// </summary>
namespace JeuDes
{
    /// <summary>
    /// Définit un objet regroupant une collection de dés
    /// </summary>
    public class GroupeDe
    {
        #region Attributes and properties
        /// <summary>
        /// Liste des combinaisons disponibles
        /// </summary>
        public List<int[]> Combinaisons { get; set; }

        /// <summary>
        /// Liste des objets de type De utilisé par le groupe de dés
        /// </summary>
        public List<De> Des { get; protected set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public GroupeDe()
        {
            //Création de la collection de dés
            Des = new List<De>();
            for (int i = 0; i < Partie.NombreDes; i++)
            {
                Des.Add(new De());
            }

            //Ajout des n combinaisons de dés possibles
            Combinaisons = new List<int[]>();
            int NbCombinaison = (int)Math.Pow(Partie.NombreFaces, Partie.NombreDes);
            for (int i = 0; i < NbCombinaison; i++)
            {
                Combinaisons.Add(new int[Partie.NombreDes]);
            }

            //Ajout des valeurs des dé pour chaque combinaison
            for (int i = 0; i < Partie.NombreDes; i++)
            {
                int Limit = (int)Math.Pow(Partie.NombreFaces, Partie.NombreDes - i) / Partie.NombreFaces;
                int iterator = 0;
                int Value = 1;
                for (int j = 0; j < NbCombinaison; j++)
                {
                    Combinaisons[j][i] = Value;
                    iterator++;

                    if (iterator == Limit)
                    {
                        iterator = 0;
                        if (Value != Partie.NombreFaces)
                        {
                            Value++;
                        }
                        else
                        {
                            Value = 1;
                        }    
                    }
                }
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Méthode pour lancer un groupe de dés
        /// Chaque dé de la liste de dés se voit affecter une valeur
        /// </summary>
        /// <returns>Un tableau d'entier comportant les valeurs de chaque dé</returns>
        public int[] Lancer()
        {  
            //Initialisation du tableau des positions de dé avec des valeurs égales à 1
            int[] PositionDe = new int[Partie.NombreDes];
            for (int i = 0; i < PositionDe.Length; i++)
            {
                PositionDe[i] = 1;
            }

            return this.Lancer(PositionDe);
        }

        /// <summary>
        /// Méthode pour lancer un ou plusieurs dés
        /// Chaque dé selectionné se voit affecter une valeur
        /// </summary>
        /// <param name="positionDes">Tableau d'entier de valeur 0 (ne pas modifier) ou 1 (modifier)</param>
        /// <returns>Un tableau d'entier comportant les valeurs de chaque dé</returns>
        public int[] Lancer(int[] positionDes)
        {
            //Utilsation du random pour générer l'index de la combinaison dans la collection
            Random r = new Random();

            //Index dans la liste des combinaisons
            int Index = r.Next(0, Combinaisons.Count);

            //Nouvelle combinaison de dés à retourner
            int[] NouvelleCombinaison = new int[Partie.NombreDes];

            for (int i = 0; i < Partie.NombreDes; i++)
            {
                //Si position est modifiable on modifie la valeur du dé 
                //dans la nouvelle combinaison
                if (positionDes[i] == 1)
                {
                    Des[i].Valeur = this.Combinaisons[Index][i];
                    NouvelleCombinaison[i] = this.Combinaisons[Index][i];
                } 
                else if(positionDes[i] == 0)
                {
                    //sinon on ajoute la valeur existante du dé 
                    //dans la nouvelle combinaison
                    NouvelleCombinaison[i] = Des[i].Valeur;
                }  
            }
            return NouvelleCombinaison;
        }
        #endregion
    }
}
