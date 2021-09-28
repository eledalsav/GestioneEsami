using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public interface IRepository<T>
    {
        public List<T> Fetch();
        public int Insert(T Item);
    }
}
