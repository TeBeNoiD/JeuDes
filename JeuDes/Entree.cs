using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    [DataContract]
    public class Entree : IComparable, IComparable<Entree>
    {
        #region Attributes and properties
        /// <summary>
        /// Propriété définissant le nom du joueur
        /// </summary>
        [DataMember]
        public string Nom { get; set; }

        /// <summary>
        /// Propriété définissant le score du joueur
        /// </summary>
        private int _Score;

        [DataMember]
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
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
        #endregion

        #region Method
        /// <summary>
        /// Determine si l'objet de type Entree est égale à un autre objet
        /// Deux objets de type Entree sont egaux si leurs scores et leurs noms sont égaux
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>retourne true si deux entrées sont égales</returns>
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

        /// <summary>
        /// Récupérer la chaine de caractère définissant l'objet
        /// </summary>
        /// <returns>Le nom et le score de l'entrée</returns>
        public override string ToString()
        {
            return this.Nom + "-" + this.Score.ToString();
        }

        /// <summary>
        /// Récupérer le hashcode de l'entrée
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Comparer une entrée à un objet de type object
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns>
        /// Retourne 1 si le score de l'entrée est supérieur à celui de l'objet.
        /// Retourne 0 si les scores sont égaux.
        /// Retourne -1 si le score de l'entrée est inférieur à celui de l'objet.
        /// ou si l'objet comparé a pour valeur null.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj is Entree)
            {
                return this.CompareTo((Entree)obj);
            }
            return -1;
        }

        /// <summary>
        /// Comparer une entrée à un objet de type Entree.
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns>
        /// Retourne 1 si le score de l'entrée est supérieur à celui de l'entrée comparée.
        /// Retourne 0 si les scores sont égaux.
        /// Retourne -1 si le score de l'entrée est inférieur à celui de l'entrée comparée
        /// ou si l'entrée comparée a pour valeur null.
        /// </returns>
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
    }
}

