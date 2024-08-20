DECLARE @counter INT = 1;

WHILE @counter <= 500
BEGIN
    DECLARE @randomUserName MONEY = CONVERT(MONEY,RAND() * 100);
    DECLARE @randomToolReservationId INT;
    DECLARE @randomStatus INT = FLOOR(RAND() * 3);
    -- isti OIB, email i phone za sve
    DECLARE @randomOib NVARCHAR(11) = 'neki_OIB'; 
    DECLARE @randomAddressId INT; 
    DECLARE @randomEmail NVARCHAR(100) = 'neka@email_adresa';
    DECLARE @randomPhone NVARCHAR(20) = '+3851555678';
	-- registrirani unazad 10 godina
    DECLARE @randomRegistrationDate DATE = DATEADD(DAY, - FLOOR(RAND() * 365 * 10), GETDATE()); 
    DECLARE @randomPersonId INT = FLOOR(RAND() * 1000) + 1;

    -- AddressId iz [dbo].[Address]
    SELECT TOP 1 @randomAddressId = Id FROM [dbo].[Address] ORDER BY NEWID();

    INSERT INTO [dbo].[Renters]
               ([UserName]
               ,[RegistrationDate]
               ,[PersonId]
               ,[FirstName]
               ,[LastName]
               ,[Oib]
               ,[AddressId]
               ,[Email]
               ,[Phone])
        VALUES (
               'UserName' + CAST(@counter AS NVARCHAR(MAX)),
               @randomRegistrationDate,
               @randomPersonId,
               'FirstName' + CAST(@counter AS NVARCHAR(MAX)),
               'LastName' + CAST(@counter AS NVARCHAR(MAX)),
               @randomOib,
               @randomAddressId,
               @randomEmail, 
               @randomPhone
               );

    SET @counter = @counter + 1;
END