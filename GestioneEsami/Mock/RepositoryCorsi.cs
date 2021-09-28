using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public class RepositoryCorsi : IRepositoryCorsi
    {
        public static List<Corso> corsi = new List<Corso>()
        {
            new Corso {Id = 1, Nome = "Analisi Matematica", CreditiFormativi = 30, IdCorsoDiLaurea = 1},
            new Corso {Id = 2, Nome = "Geometria", CreditiFormativi = 40, IdCorsoDiLaurea = 1},
            new Corso {Id = 3, Nome = "Logica", CreditiFormativi = 25, IdCorsoDiLaurea = 1},

            new Corso {Id = 4, Nome = "Fisica Teorica", CreditiFormativi = 45, IdCorsoDiLaurea = 2},
            new Corso {Id = 5, Nome = "Logica dei vettori", CreditiFormativi = 20, IdCorsoDiLaurea = 2},
            new Corso {Id = 6, Nome = "Meccanica", CreditiFormativi = 40, IdCorsoDiLaurea = 2},

            new Corso {Id = 7, Nome = "Database", CreditiFormativi = 20, IdCorsoDiLaurea = 3},
            new Corso {Id = 8, Nome = "Programmazione Procedurale", CreditiFormativi = 35, IdCorsoDiLaurea = 3},
            new Corso {Id = 9, Nome = "Sistemi", CreditiFormativi = 25, IdCorsoDiLaurea = 3},

            new Corso {Id = 10, Nome = "Automatica", CreditiFormativi = 25, IdCorsoDiLaurea = 4},
            new Corso {Id = 11, Nome = "Geometria Piana", CreditiFormativi = 30, IdCorsoDiLaurea = 4},
            new Corso {Id = 12, Nome = "Analisi del Software", CreditiFormativi = 40, IdCorsoDiLaurea = 4},

            new Corso {Id = 13, Nome = "Letteratura Greca", CreditiFormativi = 45, IdCorsoDiLaurea = 5},
            new Corso {Id = 14, Nome = "Letteratura Latina", CreditiFormativi = 35, IdCorsoDiLaurea = 5},
            new Corso {Id = 15, Nome = "Grammatica", CreditiFormativi = 30, IdCorsoDiLaurea = 5},
        };

        public List<Corso> Fetch()
        {
            return corsi;
        }

        public List<Corso> GetCorsiByCorsoDiLaurea(CorsoDiLaurea cdl)
        {
            return corsi.Where(c => c.IdCorsoDiLaurea == cdl.Id).ToList();
        }

        public int Insert(Corso Item)
        {
            throw new NotImplementedException();
        }
    }
}
