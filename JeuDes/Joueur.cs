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
    /// Définit un joueur de la partie
    /// </summary>
    public class Joueur
    {
        #region Attributes and properties
        /// <summary>
        /// Nom du joueur
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Ensemble de D manipuler par le joueur
        /// </summary>
        public GroupeDe GrpDes = new GroupeDe();


        /// <summary>
        /// Score du joueur sur la partie en cours
        /// </summary>
        private int _Score;

        public int Score
        {
            get { return _Score; }
            protected set { _Score = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur complet 
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        public Joueur(string nom)
        {
            this.Nom = nom;
            this.Score = 0;
            if (GroupeDe.NbDes > 0)
            {
                for (int i = 0; i < GroupeDe.NbDes; i++)
                {
                    this.GrpDes.Des.Add(new De());
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Joueur() : this("") { }
        #endregion

        #region Method
        /// <summary>
        /// Jouer un tour de lancement du groupe de dés
        /// Selon les règles du jeux le score du joueur est modifié
        /// </summary>
        /// <returns>la combinaison</returns>
        public int[] Jouer()
        {
            //Régle: 2 dés égaux
            //Si le joueur reussi n dés identiques
            //il marque 10 points
            int[] CombinaisonDes = GrpDes.Lancer();
            bool EstIdentique = false;
            if (this.GrpDes.Des.Count > 0)
            {
                for (int i = 0; i < this.GrpDes.Des.Count; i++)
                {
                    if (i > 0 && this.GrpDes.Des[i] == this.GrpDes.Des[i - 1])
                    {
                        EstIdentique = true;
                        break;
                    }
                }
            }
            
            if (EstIdentique)
            {
                this.Score += 10;
            }

            return CombinaisonDes;
        }
        #endregion
    }
}
