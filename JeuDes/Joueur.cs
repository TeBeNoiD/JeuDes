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
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Joueur() : this("") { }
        #endregion

        #region Method
        public int[] Jouer()
        {
            //Si le joueur reussi n dés identiques
            //il marque 10 points
            bool EstIdentique = true;
            for (int i = 0; i < GrpDes.Des.Count; i++)
            {
                if (i > 0 && GrpDes.Des[i] != GrpDes.Des[i - 1])
                {
                    EstIdentique = false;
                    break;
                }
            }
            if (EstIdentique)
            {
                this.Score += 10;
            }

            return GrpDes.Lancer();
        }
        #endregion
    }
}
