DECLARE @counter INT = 1;

WHILE @counter <= 10000
BEGIN
    -- random datumi od 1.1.2024. za datum pocetka
    DECLARE @startDate DATETIME2(7) = DATEADD(DAY, CAST(RAND() * 365 AS INT), '2024-01-01'); 
    
    -- random sat za datum pocetka
    SET @startDate = DATEADD(HOUR, CAST(RAND() * 24 AS INT), @startDate);

    DECLARE @endDate DATETIME2(7) = DATEADD(HOUR, CAST(RAND() * 24 AS INT), @startDate); -- Reservation up to 24 hours

    -- endDate mora biti nakon startDate
    IF @endDate <= @startDate
    BEGIN
        SET @endDate = DATEADD(HOUR, 1, @startDate); 
    END

    -- random ToolRenterId and RentedToolId
    DECLARE @toolRenterId INT;
    DECLARE @rentedToolId INT;

    -- provjera 
    IF EXISTS (SELECT 1 FROM Renters)
    BEGIN
        SELECT TOP 1 @toolRenterId = Id FROM Renters ORDER BY NEWID(); 
    END
    ELSE 
    BEGIN
        CONTINUE;
    END

    SELECT TOP 1 @rentedToolId = Id FROM Tool ORDER BY NEWID();

    -- Check for conflicts (same tool, overlapping reservation times)
    IF NOT EXISTS (
        SELECT 1 
        FROM ToolReservation 
        WHERE 
            RentedToolId = @rentedToolId 
            AND (
                (@startDate >= ReservationStart AND @startDate < ReservationEnd) 
                OR (@endDate > ReservationStart AND @endDate <= ReservationEnd)
                OR (@startDate <= ReservationStart AND @endDate >= ReservationEnd)
            )
    )
    BEGIN
        -- nema konflikta napravi insert
        INSERT INTO ToolReservation (ReservationStart, ReservationEnd, ToolRenterId, RentedToolId)
        VALUES (@startDate, @endDate, @toolRenterId, @rentedToolId);

        SET @counter = @counter + 1;
    END 
    ELSE
    BEGIN
        -- konflikt postoji - preskoci iteraciju
        PRINT 'konflikt - preskacem insert'; 
    END
END