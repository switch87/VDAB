CREATE PROCEDURE plantInfoOpvragen
	@plantNr int,
	@naam nvarchar(50) output,
	@soort nvarchar(50) output,
	@leverancier nvarchar(50) output,
	@kleur nvarchar(50) output,
	@kostprijs money output

AS
	SELECT @naam=Planten.Naam, @soort=Soorten.Soort, @leverancier=Leveranciers.Naam, @kleur=Planten.kleur, @kostprijs=Planten.VerkoopPrijs
	from (planten inner join soorten on Planten.SoortNr = Soorten.SoortNr) inner join Leveranciers on Planten.Levnr = Leveranciers.LevNr
	where @plantNr=Planten.PlantNr
