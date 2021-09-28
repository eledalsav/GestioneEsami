using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CreditiFormativi { get; set; }
        public int IdCorsoDiLaurea { get; set; }

        public string Print()
        {
            return $"{Nome} per {CreditiFormativi} cfu";
        }
    }

}
