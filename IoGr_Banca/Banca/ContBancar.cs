using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca
{
    public enum TipCont
    {
        RON = 0,
        EURO = 1
    }

    internal class ContEuro : ContBancar
    {
        public ContEuro(string numarCont, double suma, TipCont tipCont) : base(numarCont, suma, tipCont)
        {
        }
        public double ObtineDobanda()
        {
            return (this._suma > 500 ? this._suma * 0.1 : 0);
        }

        public override string AfiseazaCont()
        {
            return "Id Cont: " + this._numarCont + " Tip Cont: " + this._tipCont.ToString() + " Suma Totala: " + SumaTotala() + " Dobanda Zilnica: " + ObtineDobanda();
        }
    }

    internal class ContRON : ContBancar
    {
        public ContRON(string numarCont, double suma, TipCont tipCont) : base(numarCont, suma, tipCont)
        {
        }

        public void AdaugaInCont(double suma)
        {
            if (suma <= 0)
                throw new Exception("Nu se poate adauga o suma negativa");
            this._suma += suma;
        }

        public void RetrageDinCont(double suma)
        {
            if (suma <= 0)
                throw new Exception("Nu se poate retrage o suma negativa");
            else
                if ((this._suma - suma) < 0)
                throw new Exception("Eroare -> Contul nu are suficienti bani!");
            this._suma -= suma;
        }

        public override string AfiseazaCont()
        {
            return "Id Cont: " + this._numarCont + " Tip Cont: " + this._tipCont.ToString() + " Suma Totala: " + SumaTotala();
        }

    }

    internal class ContBancar : ISumaTotala
    {
        protected string _numarCont;
        protected double _suma;
        protected TipCont _tipCont;

        public ContBancar(string numarCont, double suma, TipCont tipCont)
        {
            if (suma < 0)
                throw new Exception("Suma introdusa nu poate fi negativa!");
            this._numarCont = numarCont;
            this._suma = suma;
            this._tipCont = tipCont;
        }

        #region Getter
        public string NumarCont
        {
            get { return this._numarCont; }
        }
        public TipCont TipCont
        {
            get { return this._tipCont; }
        }

        #endregion

        #region Methods

        public double SumaTotala()
        {
            return (_tipCont == TipCont.EURO) ? _suma * 4.2 : _suma;
        }
        
        public virtual string AfiseazaCont()
        {
            return "";
        }

        #endregion

    }
}
