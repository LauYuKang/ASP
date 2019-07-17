CREATE TRIGGER dbo.TripAfterInsert 
ON dbo.Trip 
AFTER INSERT AS

BEGIN
	SET NOCOUNT ON 
	DECLARE @RecNumber BIGINT
    SELECT @RecNumber = TripId FROM INSERTED
	INSERT INTO AuditLog(ActionType, TableName, RecNumber) VALUES ('INSERT','Trip', @RecNumber)
END

GO
