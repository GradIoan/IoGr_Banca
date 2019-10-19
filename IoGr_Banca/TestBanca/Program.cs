using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banca;

namespace TestBanca
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt = 0;
            Banca.Banca banca = AdaugaClienti();
            do
            {
                Console.WriteLine("---------------------------------" + Environment.NewLine +
                    "1 - Obtine dobanda cont " + Environment.NewLine +
                    "2 - Transfera bani " + Environment.NewLine +
                    "3 - Afisare date client" + Environment.NewLine +
                    "4 - Iesire" + Environment.NewLine);
                int.TryParse(Console.ReadLine(), out opt);
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Dati numarul contului: ");
                        string nrCont = Console.ReadLine();
                        banca.ObtineDobandaCont(nrCont);
                        break;
                    case 2:
                        Console.WriteLine("Dati primul cont: ");
                        string contSursa = Console.ReadLine();
                        Console.WriteLine("Dati al 2-lea cont: ");
                        string contDest = Console.ReadLine();
                        Console.WriteLine("Dati suma:");
                        double suma;
                        if (double.TryParse(Console.ReadLine(), out suma))
                            banca.TransferaBani(contSursa, contDest, suma);
                        else
                            Console.WriteLine("Suma nu e numar!");
                        break;
                    case 3:
                        Console.WriteLine("Dati CNP-ul");
                        string CNP = Console.ReadLine();
                        banca.AfisareInformatiiClient(CNP);
                        break;
                    default:
                        break;
                }
            } while (opt != 4);
            

        }

        private static Banca.Banca AdaugaClienti()
        {
            Console.WriteLine("Adaugare date ...............");
            Banca.Banca b = new Banca.Banca(1, "1950507243950", "Ionescu", "Timisoara nr. 1", "1234a", 6500.0, TipCont.RON);
            b.AdaugaClient("1950507243950", "Ionescu", "Timisoara nr. 1", "1234b", 256.0, TipCont.EURO);
            b.AdaugaClient("1950507243950", "Ionescu", "Timisoara nr. 1", "1234c", 128.5, TipCont.RON);
            b.AdaugaClient("1950507243950", "Ionescu", "Timisoara nr. 1", "1234d", 2800, TipCont.EURO);
            b.AdaugaClient("1950507243950", "Ionescu", "Timisoara nr. 1", "1234a", 100.0, TipCont.RON);  // not OK -> duplicate nrCont

            b.AdaugaClient("1870507233927", "Popescu", "Lugoj nr. 2", "54321a", 1020.0, TipCont.EURO);
            b.AdaugaClient("1870507233927", "Popescu", "Lugoj nr. 2", "54321b", 12100.0, TipCont.RON);
            b.AdaugaClient("1870507233927", "Popescu", "Lugoj nr. 2", "54321c", 10420.0, TipCont.EURO);
            b.AdaugaClient("1870507233927", "Popescu", "Lugoj nr. 2", "54321d", 110.0, TipCont.RON);
            b.AdaugaClient("1870507233927", "Popescu", "Lugoj nr. 2", "54321e", 12352.0, TipCont.RON);

            b.AdaugaClient("1980527233931", "Georgescu", "Buzias nr. 3", "123456789a", 2100.0, TipCont.RON);
            b.AdaugaClient("1980527233931", "Georgescu", "Buzias nr. 3", "123456789b", 3100.0, TipCont.RON);
            b.AdaugaClient("1980527233931", "Georgescu", "Buzias nr. 3", "123456789c", 4100.0, TipCont.EURO);
            b.AdaugaClient("1980527233931", "Georgescu", "Buzias nr. 3", "123456789d", 5100.0, TipCont.EURO);
            b.AdaugaClient("1891307233931", "Georgescu", "Buzias nr. 3", "123456789e", 6100.0, TipCont.RON); // CNP not ok
            b.AdaugaClient("1891132233931", "Georgescu", "Buzias nr. 3", "123456789e", 6100.0, TipCont.RON); // CNP not ok
            b.AdaugaClient("1980527a33931", "Georgescu", "Buzias nr. 3", "123456789d", 5100.0, TipCont.EURO); // CNP not ok

            b.AdaugaClient("1950507178522", "Petrescu", "Recas nr. 4", "abcdef1", 1020.0, TipCont.EURO);
            b.AdaugaClient("1950507178522", "Petrescu", "Recas nr. 4", "abcdef2", 12100.0, TipCont.RON);
            b.AdaugaClient("1950507178522", "Petrescu", "Recas nr. 4", "abcdef3", 10420.0, TipCont.EURO);
            b.AdaugaClient("1950507178522", "Petrescu", "Recas nr. 4", "abcdef4", 110.0, TipCont.RON);
            b.AdaugaClient("1950507178522", "Petrescu", "Recas nr. 4", "abcdef5", 100.0, TipCont.EURO);
            b.AdaugaClient("1950507178522", "Petrescu", "Recas nr. 4", "abcdef6", 100.0, TipCont.EURO);  // already 5 accounts -> not ok
            Console.WriteLine("------------OPTIUNI--------------");
            Console.WriteLine();

            return b;
        }
    }
}
