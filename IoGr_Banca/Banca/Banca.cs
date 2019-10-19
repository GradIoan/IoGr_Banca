using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    public class Banca
    {
        private List<Client> _listaClienti = new List<Client>();
        private long _codBanca;
        
        public Banca(long codBanca)
        {
            this._codBanca = codBanca;
        }

        public Banca(long codBanca, string CNP, string nume, string adresa, string numarCont, double suma, TipCont tipCont)
        {
            try
            {
                this._codBanca = codBanca;
                _listaClienti.Add(new Client(CNP, nume, adresa, numarCont, suma, tipCont));
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        #region Methods
        public void AdaugaClient(string CNP, string nume, string adresa, string numarCont, double suma, TipCont tipCont)
        {
            try
            {
                Client client = _listaClienti.Where(t => t.CNP == CNP).FirstOrDefault();
                if (client == null)
                    _listaClienti.Add(new Client(CNP, nume, adresa, numarCont, suma, tipCont));
                else
                    client.AdaugaContBancar(numarCont, suma, tipCont);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void AfisareInformatiiClient(string CNP)
        {
            try
            {
                var client = _listaClienti.Where(t => t.CNP == CNP).FirstOrDefault();
                if (client == null)
                    Console.WriteLine("Clientul nu exista!");
                else
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(client.AfiseazaClient());
                    foreach (var cont in client.Conturi)
                        sb.AppendLine(cont.AfiseazaCont());
                    Console.WriteLine(sb);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void TransferaBani(string numarContSursa, string numarContDestinatie, double suma)
        {
            try
            {
                var cbSursa = (ContRON)(from dt in _listaClienti
                                      from da in dt.Conturi
                                      where da.NumarCont == numarContSursa
                                      select da).FirstOrDefault();
                if (cbSursa == null)
                {
                    Console.WriteLine("Contul: " + numarContSursa + " nu exista!");
                    return;
                }

                var cbDestinatie = (ContRON)(from dt in _listaClienti
                                           from da in dt.Conturi
                                           where da.NumarCont == numarContDestinatie
                                           select da).FirstOrDefault();
                if (cbDestinatie == null)
                {
                    Console.WriteLine("Contul: " + numarContDestinatie + " nu exista!");
                    return;
                }

                if (cbSursa.TipCont == TipCont.RON && cbDestinatie.TipCont == TipCont.RON)
                {
                    cbSursa.RetrageDinCont(suma);
                    cbDestinatie.AdaugaInCont(suma);
                    Console.WriteLine("Banii au fost transferati cu succes!");
                }
                else
                    Console.WriteLine("Conturile nu sunt in RON!");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Contul nu e in RON -> nu se pot transfera bani");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void ObtineDobandaCont(string numarCont)
        {
            try
            {
                var contBancar = (ContEuro)(from dt in _listaClienti
                                         from da in dt.Conturi
                                         where da.NumarCont == numarCont
                                         select da).FirstOrDefault();
                if (contBancar != null)
                    Console.WriteLine("Dobanda este: " + contBancar.ObtineDobanda());
                else
                    Console.WriteLine("Contul: " + numarCont + " nu exista!");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Contul nu e in EURO -> nu are dobanda");
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        #endregion


    }
}
