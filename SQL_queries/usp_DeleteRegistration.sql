--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 28, 2024
-- Description		: Delete a Registration from the Registration table
-- Name				: usp_DeleteRegistration
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================
CREATE OR ALTER   
PROCEDURE usp_DeleteRegistration

@RegistrationId INT

AS
BEGIN

BEGIN TRY

BEGIN TRANSACTION
	DELETE FROM [dbo].[Registrations]
	WHERE RegistrationID = @RegistrationId
COMMIT TRANSACTION

END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0 
		ROLLBACK TRANSACTION
END CATCH

END