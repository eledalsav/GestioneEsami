using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public class RepositoryImmatricolazione : IRepositoryImmatricolazione
    {
        public static List<Immatricolazione> immatricolazioni = new List<Immatricolazione>()
        {
            new Immatricolazione{Id=1, Matricola=1234, DataInizio=new DateTime(29/09/2020), CfuAccumulati=127, FuoriCorso=false },
            new Immatricolazione{Id=2, Matricola=1345, DataInizio=new DateTime(09/09/2014), CfuAccumulati=169, FuoriCorso=true },
            new Immatricolazione{Id=3, Matricola=1456, DataInizio=new DateTime(25/09/2021), CfuAccumulati=0, FuoriCorso=false }
        };
        public List<Immatricolazione> Fetch()
        {
            return immatricolazioni;
        }

        public Immatricolazione GetByDate(Immatricolazione imm)
        {
            return immatricolazioni.Where(i => i.DataInizio == imm.DataInizio).SingleOrDefault();
        }

        public int Insert(Immatricolazione item)
        {
            if (immatricolazioni.Count() == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = immatricolazioni.Max(i => i.Id) + 1;
            }
            immatricolazioni.Add(item);
            return item.Id;
        }
        
            
    }
}
