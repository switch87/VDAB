using System.Collections.Generic;
using System.Data;
using AdoGemeenschap;

public class FiguurManager
{
    public List<Figuur> GetFiguren()
    {
        var figuren = new List<Figuur>();
        var manager = new StripManager();
        using (var conStrip = manager.GetConnection())
        {
            using (var comFiguren = conStrip.CreateCommand())
            {
                comFiguren.CommandType = CommandType.Text;
                comFiguren.CommandText = "select * from Figuren";
                conStrip.Open();
                using (var rdrFiguren = comFiguren.ExecuteReader())
                {
                    var IDPos = rdrFiguren.GetOrdinal("ID");
                    var NaamPos = rdrFiguren.GetOrdinal("Naam");
                    var VersiePos = rdrFiguren.GetOrdinal("Versie");
                    while (rdrFiguren.Read())
                    {
                        figuren.Add(new Figuur(rdrFiguren.GetInt32(IDPos),
                            rdrFiguren.GetString(NaamPos),
                            rdrFiguren.GetValue(VersiePos)));
                    } // do while
                } // using rdrFiguren
            } // using comFiguren
        } // using conStrip
        return figuren;
    }

    public void SchrijfWijzigingen(List<Figuur> figuren)
    {
        var manager = new StripManager();
        using (var conStrip = manager.GetConnection())
        {
            using (var comUpdate = conStrip.CreateCommand())
            {
                comUpdate.CommandType = CommandType.Text;
                comUpdate.CommandText = "update figuren set Naam=@naam where ID=@id and Versie=@versie";
                var parNaam = comUpdate.CreateParameter();
                parNaam.ParameterName = "@naam";
                comUpdate.Parameters.Add(parNaam);
                var parVersie = comUpdate.CreateParameter();
                parVersie.ParameterName = "@versie";
                comUpdate.Parameters.Add(parVersie);
                var parID = comUpdate.CreateParameter();
                parID.ParameterName = "@id";
                comUpdate.Parameters.Add(parID);
                conStrip.Open();
                foreach (var eenFiguur in figuren)
                {
                    parNaam.Value = eenFiguur.Naam;
                    parVersie.Value = eenFiguur.Versie;
                    parID.Value = eenFiguur.ID;
                    comUpdate.ExecuteNonQuery();
                }
            }
        }
    }
}