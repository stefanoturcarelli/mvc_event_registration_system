--===========================================================================================
-- Author			: Stefano Turcarelli
-- Create Date		: Feb 28, 2024
-- Description		: Adds a new Event record to the Event table
-- Name				: usp_AddEvent
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER 
PROCEDURE usp_AddEvent

@Name NVARCHAR(50), 
@Date DATETIME, 
@Location NVARCHAR(50), 
@Description NVARCHAR(MAX)

AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION
	INSERT INTO [dbo].[Events]
	(
		[Name],
		[Date],
		[Location],
		[Description]
	)
	VALUES
	(
		@Name,
		@Date,
		@Location,
		@Description
	)
COMMIT TRANSACTION

END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0 
		ROLLBACK TRANSACTION
END CATCH

END