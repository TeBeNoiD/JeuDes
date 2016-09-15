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
    public interface ISauvegarde
    {
        #region Method
        Classement Lire();

        void Ecrire();
        #endregion
    }
}
