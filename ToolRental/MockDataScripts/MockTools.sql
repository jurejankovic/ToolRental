DECLARE @counter INT = 1;

WHILE @counter <= 50000
BEGIN
    DECLARE @randomPrice MONEY = CONVERT(MONEY,RAND()*100);

    INSERT INTO Tool (Name, Description, PricePerHour)
    VALUES (
        'Alat ' + CAST(@counter AS NVARCHAR(MAX)), 
        'Opis ' + CAST(@counter AS NVARCHAR(MAX)),
        @randomPrice
    );

    SET @counter = @counter + 1;
END