DECLARE @counter INT = 1;

WHILE @counter <= 500
BEGIN
    DECLARE @randomStreetName NVARCHAR(MAX);
    DECLARE @randomStreetNumber NVARCHAR(MAX);
    DECLARE @randomCity NVARCHAR(MAX);

    DECLARE @streetNames TABLE (StreetName NVARCHAR(MAX));
    INSERT INTO @streetNames VALUES 
        ('Ilica'), ('Vlaska'), ('Jurišiceva'), ('Frankopanska'), ('Gajeva'),
        ('Trg bana Jelacica'), ('Savska'), ('Vukovarska'), ('Radnicka'), ('Heinzelova');

    DECLARE @cities TABLE (City NVARCHAR(MAX));
    INSERT INTO @cities VALUES 
        ('Zagreb'), ('Split'), ('Rijeka'), ('Osijek'), ('Zadar'), ('Dubrovnik'),
        ('Pula'), ('Slavonski Brod'), ('Karlovac'), ('Varaždin'), ('Sibenik');

    -- Select random street name and city
    SELECT TOP 1 @randomStreetName = StreetName FROM @streetNames ORDER BY NEWID();
    SELECT TOP 1 @randomCity = City FROM @cities ORDER BY NEWID();

    -- random ulicni br
    SET @randomStreetNumber = CAST(FLOOR(RAND() * 100) + 1 AS NVARCHAR(MAX)); 

    INSERT INTO [dbo].[Address]
               ([StreetName]
               ,[StreetNumber]
               ,[City]
               ,[Country])
        VALUES (
               @randomStreetName,
               @randomStreetNumber,
               @randomCity,
               'Hrvatska'
               );

    SET @counter = @counter + 1;
END