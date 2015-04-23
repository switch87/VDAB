using System;
using System.Data;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace AdoGemeenschap
{
    public class RekeningenManager
    {
        public int SaldoBonus()
        {
            var dbManager = new BankDbManager();
            using (var conBank = dbManager.GetConnection())
            {
                using (var comBonus = conBank.CreateCommand())
                {
                    comBonus.CommandType = CommandType.Text;
                    comBonus.CommandText = "update Rekeningen set Saldo=Saldo*1.1";
                    conBank.Open();
                    return comBonus.ExecuteNonQuery();
                }
            }
        }

        public bool Storten(decimal teStorten, string rekeningNr)
        {
            var dbManager = new BankDbManager();
            using (var conBank = dbManager.GetConnection())
            {
                using (var comStorten = conBank.CreateCommand())
                {
                    //comStorten.CommandType = System.Data.CommandType.Text;
                    //comStorten.CommandText = "update Rekeningen set Saldo=Saldo+@teStorten where RekeningNr=@RekeningNr";

                    // 5.4.3 Stored procedure aanroepen
                    // in plaats van de sql procedure volledig uit te typen wordt een in de database opgeslagen procedure opgeroepen
                    comStorten.CommandType = CommandType.StoredProcedure;
                    comStorten.CommandText = "storten";

                    var parTeStorten = comStorten.CreateParameter();
                    parTeStorten.ParameterName = "@teStorten";
                    parTeStorten.Value = teStorten;
                    comStorten.Parameters.Add(parTeStorten);
                    var parRekeningNr = comStorten.CreateParameter();
                    parRekeningNr.ParameterName = "@RekeningNr";
                    parRekeningNr.Value = rekeningNr;
                    comStorten.Parameters.Add(parRekeningNr);
                    conBank.Open();
                    return comStorten.ExecuteNonQuery() != 0;
                }
            }
        }

        //public void Overschrijven( Decimal bedrag, string vanRekening, string naarRekening )
        //{
        //    var dbManager = new BankDbManager();
        //    using ( var conBank = dbManager.GetConnection() )
        //    {
        //        conBank.Open();
        //        using ( var traOverschrijven = conBank.BeginTransaction( IsolationLevel.ReadCommitted ) )
        //        {
        //            using ( var comAftrekken = conBank.CreateCommand() )
        //            {
        //                comAftrekken.Transaction = traOverschrijven;
        //                comAftrekken.CommandType = CommandType.Text;
        //                comAftrekken.CommandText = "update Rekeningen set Saldo=Saldo-@bedrag where RekeningNr=@reknr";

        //                var parBedrag = comAftrekken.CreateParameter();
        //                parBedrag.ParameterName = "@bedrag";
        //                parBedrag.Value = bedrag;
        //                comAftrekken.Parameters.Add( parBedrag );

        //                var parRekNr = comAftrekken.CreateParameter();
        //                parRekNr.ParameterName = "@reknr";
        //                parRekNr.Value = vanRekening;
        //                comAftrekken.Parameters.Add( parRekNr );

        //                if ( comAftrekken.ExecuteNonQuery() == 0 )
        //                {
        //                    traOverschrijven.Rollback();
        //                    throw new Exception( "Van rekeing bestaat niet" );
        //                }
        //            }
        //            using ( var comBijtellen = conBank.CreateCommand() )
        //            {
        //                comBijtellen.Transaction = traOverschrijven;
        //                comBijtellen.CommandType = CommandType.Text;
        //                comBijtellen.CommandText = "update rekeningen set Saldo=Saldo+@bedrag where rekeningNr=@reknr";

        //                var parBedrag = comBijtellen.CreateParameter();
        //                parBedrag.ParameterName = "@bedrag";
        //                parBedrag.Value = bedrag;
        //                comBijtellen.Parameters.Add( parBedrag );

        //                var parRekNr = comBijtellen.CreateParameter();
        //                parRekNr.ParameterName = "@reknr";
        //                parRekNr.Value = naarRekening;
        //                comBijtellen.Parameters.Add( parRekNr );

        //                if ( comBijtellen.ExecuteNonQuery() == 0 )
        //                {
        //                    traOverschrijven.Rollback();
        //                    throw new Exception( "Naar rekening bestaat niet" );
        //                }
        //            }
        //        }
        //    }
        //}

        // 

        public void Overschrijven(decimal bedrag, string vanRekening, string naarRekening)
            // 6.4 De class TransactionScope
        {
            var dbManager = new BankDbManager();
            var dbManager2 = new Bank2DbManager();

            var opties = new TransactionOptions();
            opties.IsolationLevel = IsolationLevel.ReadCommitted;
            using (var traOverschrijven = new TransactionScope(TransactionScopeOption.Required, opties))
            {
                using (var conBank = dbManager.GetConnection())
                {
                    using (var comAftrekken = conBank.CreateCommand())
                    {
                        comAftrekken.CommandType = CommandType.Text;
                        comAftrekken.CommandText = "update rekeningen set saldo=saldo-@bedrag where RekeningNr=@reknr";

                        var parBedrag = comAftrekken.CreateParameter();
                        parBedrag.ParameterName = "@bedrag";
                        parBedrag.Value = bedrag;
                        comAftrekken.Parameters.Add(parBedrag);

                        var parRekNr = comAftrekken.CreateParameter();
                        parRekNr.ParameterName = "@reknr";
                        parRekNr.Value = vanRekening;
                        comAftrekken.Parameters.Add(parRekNr);

                        conBank.Open();
                        if (comAftrekken.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("Van rekening bestaat niet");
                        }
                    }
                }
                using (var conBank = dbManager2.GetConnection())
                {
                    using (var comBijtellen = conBank.CreateCommand())
                    {
                        comBijtellen.CommandType = CommandType.Text;
                        comBijtellen.CommandText = "update rekeningen set saldo=saldo+@bedrag where rekeningNr=@reknr";

                        var parBedrag = comBijtellen.CreateParameter();
                        parBedrag.ParameterName = "@bedrag";
                        parBedrag.Value = bedrag;
                        comBijtellen.Parameters.Add(parBedrag);

                        var parRekNr = comBijtellen.CreateParameter();
                        parRekNr.ParameterName = "@rekNr";
                        parRekNr.Value = naarRekening;
                        comBijtellen.Parameters.Add(parRekNr);

                        conBank.Open();

                        if (comBijtellen.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("Naar rekening bestaat niet");
                        }
                        traOverschrijven.Complete();
                    }
                }
            }
        }

        public decimal SaldoRekeningRaadplegen(string rekeningNr)
        {
            var dbManager = new BankDbManager();
            using (var conBank = dbManager.GetConnection())
            {
                using (var comSaldo = conBank.CreateCommand())
                {
                    comSaldo.CommandType = CommandType.StoredProcedure;
                    comSaldo.CommandText = "SaldoRekeningRaadplegen";
                    var parRekNr = comSaldo.CreateParameter();
                    parRekNr.ParameterName = "@rekeningNr";
                    parRekNr.Value = rekeningNr;
                    comSaldo.Parameters.Add(parRekNr);
                    conBank.Open();
                    var resultaat = comSaldo.ExecuteScalar();
                    if (resultaat == null)
                    {
                        throw new Exception("Rekening bestaat niet");
                    }
                    return (decimal) resultaat;
                }
            }
        }

        public RekeningInfo RekeningInfoRaadplegen(string rekeningNr)
        {
            var dbManager = new BankDbManager();
            using (var conBank = dbManager.GetConnection())
            {
                using (var comSaldo = conBank.CreateCommand())
                {
                    comSaldo.CommandType = CommandType.StoredProcedure;
                    comSaldo.CommandText = "RekeningInfoRaadplegen";

                    var parRekNr = comSaldo.CreateParameter();
                    parRekNr.ParameterName = "@rekeningNr";
                    parRekNr.Value = rekeningNr;
                    comSaldo.Parameters.Add(parRekNr);

                    var parSaldo = comSaldo.CreateParameter();
                    parSaldo.ParameterName = "@saldo";
                    parSaldo.DbType = DbType.Currency;
                    parSaldo.Direction = ParameterDirection.Output;
                    comSaldo.Parameters.Add(parSaldo);

                    var parKlantNaam = comSaldo.CreateParameter();
                    parKlantNaam.ParameterName = "@klantNaam";
                    parKlantNaam.DbType = DbType.String;
                    parKlantNaam.Size = 50;
                    parKlantNaam.Direction = ParameterDirection.Output;
                    comSaldo.Parameters.Add(parKlantNaam);

                    conBank.Open();
                    comSaldo.ExecuteNonQuery();
                    if (parSaldo.Value.Equals(DBNull.Value))
                    {
                        throw new Exception("Rekening bestaat niet");
                    }
                    return new RekeningInfo((decimal) parSaldo.Value, (string) parKlantNaam.Value);
                }
            }
        }
    }
}