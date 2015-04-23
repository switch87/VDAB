using System.Collections.Generic;

namespace TravelNet.Verblijven
{
    internal interface IVerblijfstype
    {
        List<Formule> BeschikbareVerblijfsFormules { get; }

        bool ToeslagSingle { get; }
        PrijsInfo PrijsInfo { get; set; }
        string NaamVerblijf { get; set; }
        decimal BerekenVerblijfsPrijs(int aantalDagen, Formule gekozenFormule);
    }
}