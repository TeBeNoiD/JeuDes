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
    /// Constructeur de sauvegarde
    /// </summary>
    public class ConstructeurSauvegarde
    {
        #region Method
        /// <summary>
        /// Récupérer une instance d'objet de type Sauvegarde
        /// Permettant d'enregistrer le classement d'une partie
        /// </summary>
        /// <returns></returns>
        public static Sauvegarde RecupererSauvegarde()
        {
            switch (Partie.SauvegardeType)
            {
                case TypeFichier.Json:
                    return new SauvegardeJson();

                case TypeFichier.Xml:
                    return new SauvegardeXml();
                    
                case TypeFichier.Binaire:
                default:
                    return new SauvegardeBinaire();
            }
        }
        #endregion
    }
}
