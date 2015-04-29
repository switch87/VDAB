CREATE PROCEDURE GemiddeldeSoortprijsRaadplegen
	@soort nvarchar(20)
AS
select avg(VerkoopPrijs) 
from Planten inner join soorten
on Planten.SoortNr = Soorten.SoortNr
where soort = @soort
