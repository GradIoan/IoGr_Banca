using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    internal class Client
    {
        private string _CNP;
        private string _nume;
        private string _adresa;
        private List<ContBancar> _listaConturi = new List<ContBancar>();

        public Client(string CNP, string nume, string adresa, string numarCont, double suma, TipCont tipCont)
        {
            if (!CNPOK(CNP))
                throw new Exception("CNPul ' " + CNP + " ' nu e valid");
            this._CNP = CNP;
            this._nume = nume;
            this._adresa = adresa;
            AddToList(numarCont, suma, tipCont);
        }


        #region Getters
        public string CNP
        {
            get { return this._CNP; }
        }

        public List<ContBancar> Conturi
        {
            get { return this._listaConturi; }
        }
        #endregion

        #region Methods
        public void AdaugaContBancar(string numarCont, double suma, TipCont tipCont)
        {
            AddToList(numarCont, suma, tipCont);
        }

        public string AfiseazaClient()
        {
            return "CNP: " + this._CNP + " Nume: " + this._nume + " Adresa: " + this._adresa;
        }

        private bool CNPOK(string CNP)
        {
            bool result = true;
            if (CNP.Length != 13)
                result = false;
            else
                if (!CNP.All(char.IsDigit)) // se accepta doar cifre
                result = false;
            else
                if (Convert.ToInt32(CNP.Substring(0, 1)) < 1 || Convert.ToInt32(CNP.Substring(0, 1)) > 4) 
                result = false;
            else
                if (Convert.ToInt32(CNP.Substring(3, 2)) > 12) // luna -> 01 -> 12
                result = false;
            else
                if (Convert.ToInt32(CNP.Substring(5, 2)) > 31) // zi -> 01 -> 31
                result = false;
            return result;
        }

        private void AddToList(string numarCont, double suma, TipCont tipCont)
        {
            if (_listaConturi.Count < 5)
            {
                var cont = _listaConturi.Where(t => t.NumarCont == numarCont).FirstOrDefault();
                if (cont != null)
                    throw new Exception("Contul " + numarCont + " exista deja -> nu se mai poate adauga");
                if (tipCont == TipCont.EURO)
                    _listaConturi.Add(new ContEuro(numarCont, suma, tipCont));
                else
                    _listaConturi.Add(new ContRON(numarCont, suma, tipCont));
            }
            else
                throw new Exception("Clientul are deja 5 conturi");
        }
        #endregion

    }
}
