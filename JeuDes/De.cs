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
    /// Définit un objet de type Dé utilisé pendant une partie
    /// </summary>
    public class De
    {
        #region Attributes and properties
        /// <summary>
        /// Nombre de face des dés
        /// </summary>
        public static int NbFaces = 6;

        /// <summary>
        /// Valeur du Dé
        /// </summary>
        private int _Valeur;

        public int Valeur       {
            get { return _Valeur; }
            set { _Valeur = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur par défaut => Valeur est affecté à 0;
        /// </summary>
        public De()
        {
            this.Valeur = 0;
        }
        #endregion

        #region Method
        /// <summary>
        /// Renvoyer la valeur de l'objet de type De sous forme de chaine de caractère
        /// </summary>
        /// <returns>Valeur du dé</returns>
        public override string ToString()
        {
            return _Valeur.ToString();
        }

        /// <summary>
        /// Renvoyer le hashcode de la valeur de l'objet de type De
        /// </summary>
        /// <returns>Objet de type entier définissant le hashcode de la valeur du dé</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Vérifier si l'objet de type De est égale à un objet.
        /// Vérifie si les valeurs des 2 objets de type De sont égales.
        /// </summary>
        /// <param name="obj">Objet de type De</param>
        /// <returns>return false si obj est null, si obj n'est pas de type De
        /// ou si les valeurs de chaques objet de type De ne sont pas égales
        /// sinon retourne true
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj is De)
            {
                De d = (De)obj;
                if (this._Valeur == d.Valeur)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Redéfinition de l'operateur == basé sur la méthode Equals()
        /// </summary>
        /// <param name="de">Objet de type De</param>
        /// <param name="obj">Objet de type object et par héritage de type De</param>
        /// <returns>true si les deux objets sont égaux sinon retourne false</returns>
        public static bool operator == (De de, object obj)
        {
            return de.Equals(obj);
        }

        /// <summary>
        /// Redéfinition de l'operateur != basé sur la méthode Equals()
        /// </summary>
        /// <param name="de">Objet de type De</param>
        /// <param name="obj">Objet de type object et par héritage de type De</param>
        /// <returns>false si les deux objets sont égaux sinon retourne true</returns>
        public static bool operator != (De de, object obj)
        {
            return !de.Equals(obj);
        }
        #endregion
    }
}
