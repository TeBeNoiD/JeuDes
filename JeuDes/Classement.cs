using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Jeu de dés 
/// </summary>
namespace JeuDes
{
    /// <summary>
    /// Objet regroupant les scores des parties précédentes
    /// </summary>
    [Serializable]
    [DataContract]
    public class Classement : IEnumerator
    {
        #region Attributes and properties
        /// <summary>
        /// Collection des entréés de l'objet Classement
        /// </summary>
        [DataMember]
        private List<Entree> _Entrees;
        public List<Entree> Entrees
        {
            get { return _Entrees; }
            protected set { _Entrees = value; }
        }

        /// <summary>
        /// Position dans la liste des entrées du classement
        /// </summary>
        private int _Index = -1;

        /// <summary>
        /// Propriété pour récupérer l'index courant
        /// </summary>
        public object Current
        {
            get
            {
                return _Index;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructeur par défaut => initialise une instance de la propriété Entrees
        /// </summary>
        public Classement()
        {
            this.Entrees = new List<Entree>();
        }
        #endregion

        #region Method
        /// <summary>
        /// Ajouter une entrée au classement
        /// </summary>
        /// <param name="entree"></param>
        public void AjouterEntree(Entree entree)
        {
            this.Entrees.Add(entree);
        }

        /// <summary>
        /// Afficher un classement depuis une entrée et comportant un nombre d'entrée precis
        /// </summary>
        /// <param name="nombreEntree">Nombre d'entrées à afficher</param>
        /// <param name="debut">Index de début de la liste des entrées à retourner</param>
        /// <returns>Une collection d'objet de type Entree</returns>
        public List<Entree> TopN(int nombreEntree, int debut = 0)
        {
            List<Entree> TopEntrees = new List<Entree>();
            if (nombreEntree > 0 && nombreEntree < Entrees.Count && debut > 0 && debut < Entrees.Count )
            {
                for (int i = debut; i < nombreEntree; i++)
                {
                    TopEntrees.Add(Entrees[i]);
                }
            }
            TopEntrees.Sort();
            return TopEntrees;
        }

        /// <summary>
        /// Afficher le classement entier
        /// </summary>
        public List<Entree> TopN()
        {
            return this.TopN(this.Entrees.Count);
        }

        /// <summary>
        /// Incrémentation de index lors du parcours du Classement
        /// </summary>
        /// <returns>Retourne true tant que l'index est strictement inférieur au nombre totale d'entrées</returns>
        public bool MoveNext()
        {
            _Index++;
            return _Index < Entrees.Count;
        }

        /// <summary>
        /// Repositioner l'index à la valeur -1
        /// </summary>
        public void Reset()
        {
            _Index = -1;
        }

        /// <summary>
        /// Récupérer la liste d'entrées qui implémente l'interface IEnumerator
        /// </summary>
        /// <returns>Objet de type IEnumerator</returns>
        public IEnumerator GetEnumerator()
        {
            return Entrees.GetEnumerator();
        }
        #endregion
    }
}
