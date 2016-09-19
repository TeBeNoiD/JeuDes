using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace JeuDes
{
    class SauvegardeJson : Sauvegarde
    {
        #region Constructors
        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="classement">Objet de type classement à sauvegarder</param>
        public SauvegardeJson(Classement classement): base(classement) { }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public SauvegardeJson(): base(new Classement()) { }
        #endregion

        #region Method
        /// <summary>
        /// Lecture du fichier de sauvegarde et récupération de l'objet de type Classement       
        /// </summary>
        /// <returns>Objet de type Classement</returns>
        public override Classement Lire()
        {
            string SavFile = "sav.json";
            if (File.Exists(SavFile))
            {
                
                Stream Flux = File.OpenRead(SavFile);

                if (Flux.Length != 0)
                {
                    DataContractJsonSerializer S = new DataContractJsonSerializer(typeof(Classement));
                    object obj = S.ReadObject(Flux);
                    this.Classement = (Classement)obj;
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
            string SavFile = "sav.json";
            Stream Flux = File.Create(SavFile);
            DataContractJsonSerializer S = new DataContractJsonSerializer(typeof(Classement));
            S.WriteObject(Flux, this.Classement);
            Flux.Close();
        }
        #endregion
    }
}
