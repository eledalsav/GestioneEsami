using System;
using System.Collections.Generic;
using System.Linq;

namespace GestioneEsami
{
    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryCorsi(),
            new RepositoryCorsiDiLaurea(), new RepositoryImmatricolazione(), new RepositoryStudente(), new RepositoryEsame());
        static void Main(string[] args)
        {
            bool continuare = true;
            int scelta;
            bool uscita = true;
            Studente s = new Studente();

            do
            {
                do
                {
                    Console.WriteLine("Premi 1 per immatricolarti");
                    Console.WriteLine("Premi 2 per accedere");
                    Console.WriteLine("Premi 3 per iscriverti ad un esame");
                    Console.WriteLine("Premi 0 per uscire");

                    continuare = int.TryParse(Console.ReadLine(), out scelta);
                } while (!continuare);

                switch (scelta)
                {
                    case 1:
                        s = Immatricolazione();
                        break;
                    case 2:
                        s = Accedi();
                        break;
                    case 3:
                        IscriversiAdEsame(s);
                        break;
                    case 0:
                        uscita = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non corretta");
                        break;
                }
            } while (uscita);
        }

        private static Studente Accedi()
        {
            List<Immatricolazione> immatricolazioni = RepositoryImmatricolazione.immatricolazioni;
            List<Studente> studenti = RepositoryStudente.studenti;
            bool check;
            int codice;
            Studente studenteAccesso;
            Immatricolazione immatricolazioneAccesso;
            do
            {
                Console.WriteLine("Inserisci il tuo codice di matricola:");
                check=int.TryParse(Console.ReadLine(), out codice);
                immatricolazioneAccesso = immatricolazioni.Where(c => c.Matricola == codice).SingleOrDefault();
            } while (immatricolazioneAccesso == null||check==false);
            studenteAccesso = studenti.Where(c => c.IdImmatricolazione == immatricolazioneAccesso.Matricola).SingleOrDefault();
            studenteAccesso._Immatricolazione = immatricolazioneAccesso;
            //studenteAccesso.Esami=
            return studenteAccesso;

        }

        private static void IscriversiAdEsame(Studente s)
        {
            var immatricolazione = s._Immatricolazione;
            var corsoDiLaurea = immatricolazione._CorsoDiLaurea;
            var corsi = corsoDiLaurea.Corsi;

            foreach (var corso in corsi)
            {
                Console.WriteLine(corso.Print());
            }
            string esame = String.Empty;
            Corso corsoScelto;
            do
            {
                Console.WriteLine("A quale esame vuoi iscriverti?");
                esame = Console.ReadLine();
                corsoScelto = corsi.Where(c => c.Nome == esame).SingleOrDefault();
            } while (corsoScelto == null);

            bool possibileIscriversi = bl.VerificaCfuPerIscrizioneEsame(corsoScelto, s);
        }

        private static void EsameSceltoPassato(Studente s)
        {
            var immatricolazione = s._Immatricolazione;
            var corsoDiLaurea = immatricolazione._CorsoDiLaurea;
            var corsi = corsoDiLaurea.Corsi;

            foreach (var corso in corsi)
            {
                Console.WriteLine(corso.Print());
            }
            string esame = String.Empty;
            Corso corsoScelto;
            do
            {
                Console.WriteLine("Quale esame vuoi aggiornare?");
                esame = Console.ReadLine();
                corsoScelto = corsi.Where(c => c.Nome == esame).SingleOrDefault();
            } while (corsoScelto == null);

            bool aggiornamentoEsame = bl.EsamePassato(corsoScelto, s);
            if (s.LaureaRichiesta == true)
            {
                Console.WriteLine("Hai raggiunto i crediti necessaria per iscriverti all'esame di laurea");
            }
        }

        private static Studente Immatricolazione()
        {
            string nome = String.Empty;
            bool continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo nome");
                nome = Console.ReadLine();
                if (!String.IsNullOrEmpty(nome))
                    continuare = false;
            } while (continuare);

            string cognome = String.Empty;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo cognome");
                cognome = Console.ReadLine();
                if (!String.IsNullOrEmpty(cognome))
                    continuare = false;
                //else
                //    continuare = true;
            } while (continuare);

            int annoNascita;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci l'anno di nascita");
                continuare = int.TryParse(Console.ReadLine(), out annoNascita);
            } while (!continuare);

            Studente s = new Studente(nome, cognome, annoNascita);

            List<CorsoDiLaurea> corsiDiLaurea = bl.FetchCorsiDiLaurea();
            foreach (var corsoDiLaurea in corsiDiLaurea)
            {
                Console.WriteLine(corsoDiLaurea.Print());
            }

            var nomeCdL = Console.ReadLine();
            // Lo posso fare qui perchè ho fatto una fetch prima
            CorsoDiLaurea cdl = corsiDiLaurea.Where(c => c.Nome == nomeCdL).SingleOrDefault();

            s = bl.CreaImmatricolazione(s, cdl);

            return s;
        }



    }
}
