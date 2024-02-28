--===========================================================================================
-- Author			: Stefano Turcarelli
-- Create Date		: Feb 28, 2024
-- Description		: Getting the data of all events
-- Name				: usp_GetAllEvents
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER 
	PROCEDURE usp_GetAllEvents

AS
BEGIN
	SELECT * FROM [dbo].[Events]
END