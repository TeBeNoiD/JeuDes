using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDes
{
    /// <summary>
    /// Définit un objet regroupant une collection de dés
    /// </summary>
    public class GroupeDe
    {
        #region Attributes and properties
        /// <summary>
        /// Nombre de dés dans la partie
        /// </summary>
        public static int NbDes = 2;

        /// <summary>
        /// Liste des combinaisons disponibles
        /// </summary>
        public List<int[]> Combinaison { get; set; }

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
            //TODO Généralisation à N dés
            Combinaison = new List<int[]>();

            //Génération des combinaisons de 2 dés 
            for (int i = 1; i <= De.NbFaces; i++)
            {
                for (int j = De.NbFaces; j >= 1; j--)
                {
                    if (j >= i)
                    {
                        Combinaison.Add(new int[] { i, j });
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Des = new List<De>();
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
            //Utilsation du random pour générer l'index de la combinaison dans la collection
            Random r = new Random();
            int index = r.Next(0, Combinaison.Count);

            for (int i = 0; i < Des.Count; i++)
            {
                Des[i].Valeur = this.Combinaison[index][i];
            }

            return this.Combinaison[index];
        }

        //TODO surcharge de la méthode GroupeDe.Lancer() pour lancer un dé uniquement dans le groupe de dés
        #endregion
    }
}
