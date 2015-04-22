CREATE PROCEDURE leverancierToevoegen
	(@naam nvarchar(30), @adres nvarchar(30), @postnr nvarchar(10), @woonplaats nvarchar(30))
AS
	insert into Leveranciers (Naam, Adres, PostNr, Woonplaats)
	values (@naam, @adres, @postNr, @woonplaats)