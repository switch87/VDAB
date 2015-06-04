namespace TDDCursusLibrary
{
    public class Veiling
    {
        public decimal HoogsteBod { get; private set; }

        public void DoeBod(decimal bedrag)
        {
            if (bedrag > HoogsteBod)
            {
                HoogsteBod = bedrag;
            }
        }
    }
}