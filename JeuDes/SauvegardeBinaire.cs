using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace JeuDes
{
    /// <summary>
    /// 
    /// </summary>
    public class SauvegardeBinaire : Sauvegarde
    {
        #region Attributes and properties

        #endregion


        #region Constructors

        #endregion

        #region Method
        public override Classement Lire()
        {
            Stream Flux;
            if (File.Exists("sav.bin"))
            {
                Flux = File.OpenRead("sav.bin");
                IFormatter F = new BinaryFormatter();
                object obj = F.Deserialize(Flux);
                this.Classement = (Classement)obj;
                Flux.Close();
            }
            return this.Classement;
        }

        public override void Ecrire()
        {
            Stream Flux;

            Flux = File.Create("sav.bin");

            IFormatter F = new BinaryFormatter();
            F.Serialize(Flux, this.Classement);
            Flux.Close();
        }
        #endregion
    }
}
