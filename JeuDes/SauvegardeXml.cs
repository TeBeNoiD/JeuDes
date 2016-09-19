using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// <summary>
/// Jeu de dés 
/// </summary>
namespace JeuDes
{
    /// <summary>
    /// Mise en place d'une sauvegarde par serialisation dans un fichier binaire 
    /// </summary>
    public class SauvegardeXml : Sauvegarde
    {
        #region Constructors
        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="classement">Objet de type classement à sauvegarder</param>
        public SauvegardeXml(Classement classement): base(classement) { }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public SauvegardeXml(): base(new Classement()) { }
        #endregion

        #region Method
        /// <summary>
        /// Lecture du fichier de sauvegarde et récupération de l'objet de type Classement       
        /// </summary>
        /// <returns>Objet de type Classement</returns>
        public override Classement Lire()
        {
            string SavFile = "sav.xml";
            if (File.Exists(SavFile))
            {
                Stream Flux = File.OpenRead(SavFile);

                if (Flux.Length != 0)
                {
                    XmlSerializer S = new XmlSerializer(Classement.GetType());
                    this.Classement = (Classement)S.Deserialize(Flux);
                }

                Flux.Close();
            }
            return this.Classement;
        }

        /// <summary>
        /// Ecriture du fichier de sauvegarde
        /// permet de faire persister un objet de type Classement
        /// </summary>
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
