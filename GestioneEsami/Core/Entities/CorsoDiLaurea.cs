using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public class CorsoDiLaurea
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnniDiCorso { get; set; }
        public int? Cfu { get; set; }
        public List<Corso> Corsi { get; set; }

        public string Print()
        {
            return $"{Nome} dura {AnniDiCorso} anni";
        }
    }
}
