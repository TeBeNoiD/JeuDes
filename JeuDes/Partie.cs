using System;
using System.Collections;
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
    /// 
    /// </summary>
    public class Partie
    {
        #region Attributes and properties
        /// <summary>
        /// Classement de la partie
        /// </summary>
        public Classement Classement { get; set; }

        /// <summary>
        /// Collection de joueurs de la partie
        /// </summary>
        public List<Joueur> Joueurs { get; set; }

        /// <summary>
        /// Nombre de fois ou le(s) joueurs lance le groupe de dés
        /// </summary>
        public static int NombreTours = 10;

        /// <summary>
        /// Type de sauvegarde
        /// Par défaut la sauvegarde s'effectue dans un fichier binaire
        /// </summary>
        public static TypeFichier SauvegardeType = TypeFichier.Binaire;

        /// <summary>
        /// Nombre de face des dés
        /// </summary>
        public static int NombreFaces = 6;

        /// <summary>
        /// Nombre de dés dans la partie
        /// </summary>
        public static int NombreDes = 2;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur complet 
        /// </summary>
        /// <param name="joueur">Joueur de la partie</param>
        /// <param name="classement">Classement des parties précédentes</param>
        public Partie(List<Joueur> joueurs, Classement classement)
        {
            this.Joueurs = joueurs;
            this.Classement = classement;
        }

        /// <summary>
        /// Création d'un jeu à partir d'un objet de type Joueur connu
        /// </summary>
        /// <param name="joueur"></param>
        public Partie(List<Joueur> joueurs) : this(joueurs, new Classement()) { }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Partie() : this(new List<Joueur>(), new Classement()) { }
        #endregion
    }
}
