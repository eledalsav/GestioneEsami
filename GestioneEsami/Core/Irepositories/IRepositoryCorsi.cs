using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public interface IRepositoryCorsi : IRepository<Corso>
    {
        List<Corso> GetCorsiByCorsoDiLaurea(CorsoDiLaurea cdl);
    }
}
