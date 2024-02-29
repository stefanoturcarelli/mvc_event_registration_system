--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 22, 2024
-- Description		: Update an Event based on a specific EventId
-- Name				: usp_UpdateEvent
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================

CREATE OR ALTER 
PROCEDURE usp_UpdateEvent
    @EventId INT,
	@Name NVARCHAR(50), 
	@Date DATETIME, 
	@Location NVARCHAR(50), 
	@Description NVARCHAR(MAX)

AS 
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
            UPDATE [dbo].[Events]
            SET 
                [Name] = @Name, 
                [Date] = @Date,
                [Location] = @Location,
                [Description] = @Description
            WHERE 
                EventId = @EventId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF(@@TRANCOUNT > 0) 
            ROLLBACK TRANSACTION;
    END CATCH;
END;