using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Transactions;

namespace AdoGemeenschap
{
    public class RekeningenManager
    {
        public Int32 SaldoBonus()
        {
            var dbManager = new BankDbManager();
            using ( var conBank = dbManager.GetConnection() )
            {
                using ( var comBonus = conBank.CreateCommand() )
                {
                    comBonus.CommandType = System.Data.CommandType.Text;
                    comBonus.CommandText = "update Rekeningen set Saldo=Saldo*1.1";
                    conBank.Open();
                    return comBonus.ExecuteNonQuery();
                }
            }
        }

        public Boolean Storten( Decimal teStorten, String rekeningNr )
        {
            var dbManager = new BankDbManager();
            using ( var conBank = dbManager.GetConnection() )
            {
                using ( var comStorten = conBank.CreateCommand() )
                {
                    //comStorten.CommandType = System.Data.CommandType.Text;
                    //comStorten.CommandText = "update Rekeningen set Saldo=Saldo+@teStorten where RekeningNr=@RekeningNr";

                    // 5.4.3 Stored procedure aanroepen
                    // in plaats van de sql procedure volledig uit te typen wordt een in de database opgeslagen procedure opgeroepen
                    comStorten.CommandType = System.Data.CommandType.StoredProcedure;
                    comStorten.CommandText = "storten";

                    DbParameter parTeStorten = comStorten.CreateParameter();
                    parTeStorten.ParameterName = "@teStorten";
                    parTeStorten.Value = teStorten;
                    comStorten.Parameters.Add( parTeStorten );
                    DbParameter parRekeningNr = comStorten.CreateParameter();
                    parRekeningNr.ParameterName = "@RekeningNr";
                    parRekeningNr.Value = rekeningNr;
                    comStorten.Parameters.Add( parRekeningNr );
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

        public void Overschrijven( decimal bedrag, String vanRekening, String naarRekening )
        // 6.4 De class TransactionScope
        {
            var dbManager = new BankDbManager();
            var dbManager2 = new Bank2DbManager();

            var opties = new TransactionOptions();
            opties.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            using ( var traOverschrijven = new TransactionScope( TransactionScopeOption.Required, opties ) )
            {
                using ( var conBank = dbManager.GetConnection() )
                {
                    using ( var comAftrekken = conBank.CreateCommand() )
                    {
                        comAftrekken.CommandType = CommandType.Text;
                        comAftrekken.CommandText = "update rekeningen set saldo=saldo-@bedrag where RekeningNr=@reknr";

                        var parBedrag = comAftrekken.CreateParameter();
                        parBedrag.ParameterName = "@bedrag";
                        parBedrag.Value = bedrag;
                        comAftrekken.Parameters.Add( parBedrag );

                        var parRekNr = comAftrekken.CreateParameter();
                        parRekNr.ParameterName = "@reknr";
                        parRekNr.Value = vanRekening;
                        comAftrekken.Parameters.Add( parRekNr );

                        conBank.Open();
                        if ( comAftrekken.ExecuteNonQuery() == 0 )
                        {
                            throw new Exception( "Van rekening bestaat niet" );
                        }
                    }
                }
                using ( var conBank = dbManager2.GetConnection() )
                {
                    using ( var comBijtellen = conBank.CreateCommand() )
                    {
                        comBijtellen.CommandType = CommandType.Text;
                        comBijtellen.CommandText = "update rekeningen set saldo=saldo+@bedrag where rekeningNr=@reknr";

                        var parBedrag = comBijtellen.CreateParameter();
                        parBedrag.ParameterName = "@bedrag";
                        parBedrag.Value = bedrag;
                        comBijtellen.Parameters.Add( parBedrag );

                        var parRekNr = comBijtellen.CreateParameter();
                        parRekNr.ParameterName = "@rekNr";
                        parRekNr.Value = naarRekening;
                        comBijtellen.Parameters.Add( parRekNr );

                        conBank.Open();

                        if ( comBijtellen.ExecuteNonQuery() == 0 )
                        {
                            throw new Exception( "Naar rekening bestaat niet" );
                        }
                        traOverschrijven.Complete();
                    }
                }
            }
        }

        public Decimal SaldoRekeningRaadplegen (String rekeningNr)
        {

        }
    }
}
