﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Jeu de dés 
/// </summary>
namespace JeuDes
{
    /// <summary>
    /// Mise en place d'une sauvegarde par serialisation dans un fichier binaire 
    /// </summary>
    public class SauvegardeBinaire : Sauvegarde
    {
        #region Constructors
        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="classement">Objet de type classement à sauvegarder</param>
        public SauvegardeBinaire(Classement classement): base(classement) { }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public SauvegardeBinaire(): base(new Classement()) { }
        #endregion

        #region Method
        /// <summary>
        /// Lecture du fichier de sauvegarde et récupération de l'objet de type Classement       
        /// </summary>
        /// <returns>Objet de type Classement</returns>
        public override Classement Lire()
        {
            Stream Flux;
            if (File.Exists("sav.bin"))
            {
                Flux = File.OpenRead("sav.bin");

                if (Flux.Length != 0)
                {
                    IFormatter F = new BinaryFormatter();
                    object obj = F.Deserialize(Flux);
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
            Stream Flux;

            Flux = File.Create("sav.bin");

            IFormatter F = new BinaryFormatter();
            F.Serialize(Flux, this.Classement);

            Flux.Close();
        }
        #endregion
    }
}
