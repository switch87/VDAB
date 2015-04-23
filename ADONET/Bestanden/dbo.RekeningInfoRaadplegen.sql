CREATE PROCEDURE RekeningInfoRaadplegen
(
@RekeningNr nvarchar(14),
@Saldo money OUTPUT,
@KlantNaam nvarchar(50) OUTPUT
)
AS
select @Saldo=Saldo, @KlantNaam=Naam
from Rekeningen inner join Klanten
on Rekeningen.KlantNr = Klanten.KlantNr
where RekeningNr=@RekeningNr