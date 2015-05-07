namespace EFTaken
{
    public partial class Rekening
    {
        public void Storten(decimal bedrag)
        {
            Saldo += bedrag;
        }
    }
}