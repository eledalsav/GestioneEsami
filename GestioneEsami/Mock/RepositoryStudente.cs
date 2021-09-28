using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public class RepositoryStudente : IRepositoryStudente
    {
        public static List<Studente> studenti = new List<Studente>()
        {
            new Studente{Nome="Mario", Cognome="Rossi", AnnoDiNascita=1998,},
            new Studente{Nome="Alessia", Cognome="Francia", AnnoDiNascita=2001},
            new Studente{Nome="Fabio", Cognome="Monti", AnnoDiNascita=1995}

        };
        public List<Studente> Fetch()
        {
            return studenti;
        }

        public Studente GetByMatricola(int matricola)
        {
            return studenti.Where(s => s.IdImmatricolazione == matricola).FirstOrDefault();
        }

        public int Insert(Studente item)
        {
            if (studenti.Count == 0)
                item.Id = 1;
            else
                item.Id = studenti.Max(s => s.Id) + 1;

            studenti.Add(item);
            return item.Id;
        }
    }
}
