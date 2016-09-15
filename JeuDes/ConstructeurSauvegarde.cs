using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDes
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstructeurSauvegarde
    {
        #region Attributes and properties
        private static ConstructeurSauvegarde Constructeur = new ConstructeurSauvegarde();
        #endregion

        public static ConstructeurSauvegarde getSauvegardeInstance ()
        {
            return Constructeur;
        }
        #region Constructors

        #endregion

        #region Method
        public ISauvegardable getSauvegarde(string type)
        {
            switch (type)
            {
                case "xml":
                    return new SauvegardeXml();
                    
                case "binaire":
                default:
                    return new SauvegardeBinaire();
            }
        }

        #endregion
    }
}
