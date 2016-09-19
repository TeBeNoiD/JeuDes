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
    /// Interface implémentant les méthode pour lire une sauvegarde et pour enregistrer une sauvegarde 
    /// </summary>
    public interface ISauvegarde
    {
        #region Method
        /// <summary>
        /// Méthode à implémenter pour lire une sauvegarde et récupérer un objet de type Classement
        /// </summary>
        /// <returns>Objet de type Classement</returns>
        Classement Lire();

        /// <summary>
        /// Méthode à implémenter pour enregistrer un fichier dans une sauvegarde
        /// </summary>
        void Ecrire();
        #endregion
    }
}
