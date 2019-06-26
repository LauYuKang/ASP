GO
CREATE TRIGGER dbo.TripAfterInsert 
ON dbo.Trip 
AFTER INSERT AS

BEGIN
	SET NOCOUNT ON 
	DECLARE @RecNumber BIGINT
	DECLARE @StaffId NVARCHAR(50)
	DECLARE @IPaddress NVARCHAR(50)

	SELECT @StaffId = StaffId FROM INSERTED
    SELECT @RecNumber = TripId FROM INSERTED
	SELECT @IPaddress = CONVERT(NVARCHAR, CONNECTIONPROPERTY('client_net_address')) 

	INSERT INTO AuditLog(ActionType, TableName, RecNumber, StaffID, IPAddress)VALUES ('INSERT','Trip', @RecNumber, @StaffId, @IPaddress)
END