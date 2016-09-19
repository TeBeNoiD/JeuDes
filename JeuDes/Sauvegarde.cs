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
    /// Classe abstraite permettant d'implémenter les design pattern stratégie et fabrique
    /// </summary>
    public abstract class Sauvegarde : ISauvegarde
    {
        #region Attributes and properties
        /// <summary>
        /// Objet de type Classement à sauvegarder ou récupérer depuis la sauvegarde
        /// </summary>
        public Classement Classement;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur complet à partir d'un objet de type Classement 
        /// </summary>
        /// <param name="classement">Objet de type Classement nécessaire pour la sauvegarde</param>
        protected Sauvegarde(Classement classement)
        {
            this.Classement = classement;
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        protected Sauvegarde() : this(new Classement()) { }
        #endregion

        #region Method
        /// <summary>
        /// Lire une sauvegarde
        /// </summary>
        /// <returns>Objet de type Classement définissant le classement du jeu</returns>
        public abstract Classement Lire();

        /// <summary>
        /// Ecrire une sauvegarde 
        /// </summary>
        public abstract void Ecrire();
        #endregion
    }

    /// <summary>
    /// Définit les types de sauvegarde disponible
    /// </summary>
    public enum TypeFichier
    {
        Xml,
        Binaire,
        Json
    }
}
