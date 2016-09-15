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
    public abstract class Sauvegarde : ISauvegardable
    {
        #region Attributes and properties
        public Classement Classement;
        #endregion
        
        #region Constructors
        protected Sauvegarde(Classement classement)
        {
            this.Classement = classement;
        }

        protected Sauvegarde() : this(new Classement()) { }
        #endregion

        #region Method
        public abstract void Lire();

        public abstract void Ecrire();
        #endregion
    }
}
