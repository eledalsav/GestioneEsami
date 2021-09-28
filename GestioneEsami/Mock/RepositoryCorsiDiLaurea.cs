using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public class RepositoryCorsiDiLaurea : IRepositoryCorsiDiLaurea
    {
        public static List<CorsoDiLaurea> corsiDiLaurea = new List<CorsoDiLaurea>()
        {
            new CorsoDiLaurea { Id = 1, Nome = "Matematica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 2, Nome = "Fisica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 3, Nome = "Informatica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 4, Nome = "Ingegneria", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 5, Nome = "Lettere", AnniDiCorso = 3},
        };

        public List<CorsoDiLaurea> Fetch()
        {
            return corsiDiLaurea;
        }

        public int Insert(CorsoDiLaurea Item)
        {
            if (corsiDiLaurea.Count == 0)
                Item.Id = 1;
            else
                Item.Id =corsiDiLaurea.Max(s => s.Id) + 1;

            corsiDiLaurea.Add(Item);
            return Item.Id;
        }
    }
}
