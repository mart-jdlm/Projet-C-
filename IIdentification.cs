using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUET_JOUBERT
{
    internal interface IIdentification<T>
    {
        /// <summary>
        /// Interface pour identifier une entité
        /// </summary>
        /// <param name="item">Entité qui sera ici une personne</param>
        void IIdentification(T item);
    }
}
