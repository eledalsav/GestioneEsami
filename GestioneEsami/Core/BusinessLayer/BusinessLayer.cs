using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneEsami
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryCorsiDiLaurea corsiDiLaureaRepo;
        private readonly IRepositoryImmatricolazione immatricolazioneRepo;
        private readonly IRepositoryStudente studenteRepo;
        public BusinessLayer(IRepositoryCorsi corsi, IRepositoryCorsiDiLaurea corsiDiLaurea,
            IRepositoryImmatricolazione immatricolazione, IRepositoryStudente studente, IRepositoryEsame esami)
        {
            corsiRepo = corsi;
            corsiDiLaureaRepo = corsiDiLaurea;
            immatricolazioneRepo = immatricolazione;
            studenteRepo = studente;
        }

        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl)
        {
            Immatricolazione imm = new Immatricolazione();
            imm.DataInizio = DateTime.Now;
            imm._CorsoDiLaurea = GetCorsi(cdl);

            int ore = imm.DataInizio.Hour;
            int minuti = imm.DataInizio.Minute;
            var secondi = imm.DataInizio.Second;
            var matricola = String.Concat(ore, minuti, secondi);

            imm.Matricola = Convert.ToInt32(matricola);

            immatricolazioneRepo.Insert(imm);
            imm = immatricolazioneRepo.GetByDate(imm);

            s.IdImmatricolazione = imm.Id;
            s._Immatricolazione = imm;

            studenteRepo.Insert(s);

            return s;
        }

        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsiDiLaureaRepo.Fetch();
        }

        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRepo.GetCorsiByCorsoDiLaurea(cdl);
            cdl.Corsi = corsi;
            var cfuTotali = corsi.Sum(c => c.CreditiFormativi);
            cdl.Cfu = cfuTotali;
            return cdl;
        }

        public bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s)
        {
            var cfuOk = s._Immatricolazione.CfuAccumulati + corsoScelto.CreditiFormativi <= s._Immatricolazione._CorsoDiLaurea.Cfu;
            if (cfuOk && !s.LaureaRichiesta)
                return true;
            else
                return false;
        }

        public bool EsamePassato(Corso corsoScelto, Studente s)
        {
            if(VerificaCfuPerIscrizioneEsame(corsoScelto, s) == true)
            {
                s._Immatricolazione.CfuAccumulati = s._Immatricolazione.CfuAccumulati + corsoScelto.CreditiFormativi;

                Esame esame = new Esame();
                esame.Id = corsoScelto.Id;
                esame.IdStudente = s.Id;
                esame.Nome = corsoScelto.Nome;
                esame.Passato = true;

                if (s._Immatricolazione.CfuAccumulati >= s._Immatricolazione._CorsoDiLaurea.Cfu)
                {
                    s.LaureaRichiesta = true;
                }

                return true;
            }
            return false;
        }
    }
}
