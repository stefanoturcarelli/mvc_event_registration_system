--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 28, 2024
-- Description		: Delete an Event record from the Event table
-- Name				: usp_DeleteEvent
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER 
PROCEDURE usp_DeleteEvent

@EventId INT

AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION
	DELETE FROM [dbo].[Events]
	WHERE EventId = @EventId
COMMIT TRANSACTION

END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0 
		ROLLBACK TRANSACTION
END CATCH

END