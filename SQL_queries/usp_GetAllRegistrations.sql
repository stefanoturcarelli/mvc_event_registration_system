--===========================================================================================
-- Author			: Stefano Turcarelli
-- Create Date		: Feb 28, 2024
-- Description		: Get all registrations for a specific event
-- Name				: usp_GetAllRegistrations
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================

CREATE OR ALTER 
PROCEDURE usp_GetAllRegistrations
@EventId INT

AS 
BEGIN
	SELECT * 
	FROM [dbo].[Registrations]
	WHERE EventId = @EventId
END