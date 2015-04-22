CREATE PROCEDURE storten (@teStorten money, @rekeningNr nvarchar(14))
AS
	UPDATE Rekeningen
	SET Saldo=Saldo+@teStorten
	WHERE RekeningNr=@rekeningNr
