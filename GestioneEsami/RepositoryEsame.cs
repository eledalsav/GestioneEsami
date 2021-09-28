using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
   public class RepositoryEsame:IRepositoryEsame
    {
        public static List<Esame> esami = new List<Esame>();
        public List<Esame> Fetch()
        {
            return esami;
        }

        public Esame GetById(int id)
        {
            return esami.Where(e => e.Id == id).FirstOrDefault();
        }


        public int Insert(Esame item)
        {
            if (esami.Count == 0)
                item.Id = 1;
            else
                item.Id = esami.Max(s => s.Id) + 1;

            esami.Add(item);
            return item.Id;
        }

    }
}

