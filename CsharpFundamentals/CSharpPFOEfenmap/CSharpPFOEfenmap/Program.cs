using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaarRekening.Intrest = 3m;
            Klant ik = new Klant("Eddy", "Wally");
            ZichtRekening zicht = new ZichtRekening(747524091936ul, ik, 14.51m,
            DateTime.Today, -500m);
            SpaarRekening spaar = new SpaarRekening(737524091952ul, ik, 1000m,
            DateTime.Today);
            BankBediende Bobby = new BankBediende("Bobby", "Jans");
            zicht.RekeningUitreksel += Bobby.ToonRekeningUitreksel;
            spaar.RekeningUitreksel += Bobby.ToonRekeningUitreksel;
            zicht.SaldoInHetRood += Bobby.ToonSaldoInHetRood;
            spaar.SaldoInHetRood += Bobby.ToonSaldoInHetRood;

            zicht.Storten(25.6m);
            spaar.Afhalen(1120.5m);
        }

    }
}
