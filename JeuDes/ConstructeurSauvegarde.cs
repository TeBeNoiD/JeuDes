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
        public static ISauvegarde getSauvegarde(TypeFichier type)
        {
            switch (type)
            {
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
