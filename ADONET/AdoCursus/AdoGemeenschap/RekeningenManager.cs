using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

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
    }
}
