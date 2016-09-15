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
    /// Définit un objet représentant une ligne du classement
    /// </summary>
    [Serializable]
    public class Entree : IComparable, IComparable<Entree>
    {
        #region Attributes and properties
        /// <summary>
        /// Propriété définissant le nom du joueur
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Propriété définissant le score du joueur
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
        /// Constructeur complet => instancie un objet Entree à partir du nom et du score d'un joueur
        /// </summary>
        public Entree(string nom, int score)
        {
            this.Nom = nom;
            this.Score = score;
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Entree() : this("ABC", 0) { }


        public override bool Equals(object obj)
        {
            if (obj != null && this.GetType() == obj.GetType())
            {
                Entree E = (Entree)obj;
                if (this.Score == E.Score && this.Nom == E.Nom)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.Nom + "-" + this.Score.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (obj is Entree)
            {
                return this.CompareTo((Entree)obj);
            }
            return -1;
        }

        public int CompareTo(Entree entree)
        {
            if (entree != null)
            {
                if (this.Equals(entree))
                    return 0;

                if (this.Score > entree.Score)
                    return 1;
            }
            return -1;
        }
        #endregion

        #region Method

        #endregion
    }
}

