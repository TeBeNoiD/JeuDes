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
    /// Définit un objet de type Dé utilisé par une partie
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

        #endregion
    }
}
