using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JeuDes
{
    /// <summary>
    /// 
    /// </summary>
    public class SauvegardeXml : Sauvegarde
    {
        #region Attributes and properties

        #endregion

        #region Constructors

        #endregion

        #region Method
        public override Classement Lire()
        {
            string SavFile = "sav.xml";
            if (File.Exists(SavFile))
            {
                Stream Flux = File.OpenRead(SavFile);
                XmlSerializer S = new XmlSerializer(Classement.GetType());
                this.Classement = (Classement)S.Deserialize(Flux);
                Flux.Close();
            }
            return this.Classement;
        }

        public override void Ecrire()
        {
            string SavFile = "sav.xml";
            Stream Flux = File.Create(SavFile);
            XmlSerializer S = new XmlSerializer(typeof(Classement));
            S.Serialize(Flux, this.Classement);
            Flux.Close();
        }
        #endregion
    }
}
