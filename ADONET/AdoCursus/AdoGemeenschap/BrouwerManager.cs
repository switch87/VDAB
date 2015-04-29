using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace AdoGemeenschap
{
    public class BrouwerManager
    {
        public ObservableCollection<Brouwer> GetBrouwersBeginNaam(string beginNaam)
        {
            var brouwers =
                new ObservableCollection<Brouwer>();
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comBrouwers = conBieren.CreateCommand())
                {
                    comBrouwers.CommandType = CommandType.Text;
                    if (beginNaam != string.Empty)
                    {
                        comBrouwers.CommandText = "select * from Brouwers where BrNaam like @zoals order by BrNaam";
                        var parZoals = comBrouwers.CreateParameter();
                        parZoals.ParameterName = "@zoals";
                        parZoals.Value = beginNaam + "%";
                        comBrouwers.Parameters.Add(parZoals);
                    }
                    else
                    {
                        comBrouwers.CommandText = "select * from Brouwers";
                    }
                    conBieren.Open();
                    using (var rdrBrouwers = comBrouwers.ExecuteReader())
                    {
                        var brouwerNrPos = rdrBrouwers.GetOrdinal("BrouwerNr");
                        var brNaamPos = rdrBrouwers.GetOrdinal("BrNaam");
                        var adresPos = rdrBrouwers.GetOrdinal("Adres");
                        var postcodePos = rdrBrouwers.GetOrdinal("Postcode");
                        var gemeentePos = rdrBrouwers.GetOrdinal("Gemeente");
                        var omzetPos = rdrBrouwers.GetOrdinal("Omzet");

                        while (rdrBrouwers.Read())
                        {
                            int? omzet;
                            if (rdrBrouwers.IsDBNull(omzetPos))
                            {
                                omzet = null;
                            }
                            else
                            {
                                omzet = rdrBrouwers.GetInt32(omzetPos);
                            }
                            brouwers.Add(new Brouwer(rdrBrouwers.GetInt32(brouwerNrPos),
                                rdrBrouwers.GetString(brNaamPos), rdrBrouwers.GetString(adresPos),
                                rdrBrouwers.GetInt16(postcodePos), rdrBrouwers.GetString(gemeentePos), omzet));
                        }
                    }
                }
            }
            return brouwers;
        }

        public void SchrijfVerwijderingen(List<Brouwer> brouwers)
        {
            var manager = new BierenDbManager();
            using (var conBieren = manager.GetConnection())
            {
                using (var comDelete = conBieren.CreateCommand())
                {
                    comDelete.CommandType = CommandType.Text;
                    comDelete.CommandText = "delete from brouwers where BrouwerNr=@brouwernr";
                    var parBrouwerNr = comDelete.CreateParameter();
                    parBrouwerNr.ParameterName = "@brouwernr";
                    comDelete.Parameters.Add(parBrouwerNr);
                    conBieren.Open();
                    foreach (var eenBrouwer in brouwers)
                    {
                        parBrouwerNr.Value = eenBrouwer.BrouwerNr;
                        comDelete.ExecuteNonQuery();
                    } // foreach
                } // comDelete
            } // conBieren
        }
    }
}