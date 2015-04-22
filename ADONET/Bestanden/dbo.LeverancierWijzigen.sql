CREATE PROCEDURE LeverancierWijzigen(@OudLevNr int, @NieuwLevNr int)
AS
UPDATE Planten
SET Levnr = @NieuwLevNr
WHERE Levnr = @OudLevNr