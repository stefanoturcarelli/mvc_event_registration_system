--===========================================================================================
-- Author			: Stefano Turcarelli
-- Create Date		: Feb 28, 2024
-- Description		: Add a new Registration record to the Registrations table
-- Name				: usp_AddRegistration
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================

CREATE OR ALTER
PROCEDURE usp_AddRegistration
@RegistrationId INT, 
@EventId INT,
@AttendeeFirstName NVARCHAR(50), 
@AttendeeLastName NVARCHAR(50),
@Email NVARCHAR(50),
@RegistrationDate DATETIME
AS

BEGIN

BEGIN TRY

BEGIN TRANSACTION
	UPDATE [dbo].[Registrations]
	SET EventId = @EventId
	WHERE RegistrationId = @RegistrationId
	INSERT INTO [dbo].[Registrations]
	(
		EventID,
		AttendeeFirstName, 
		AttendeeLastName, 
		Email, 
		RegistrationDate
	)
	VALUES 
	(
		@EventID,
		@AttendeeFirstName, 
		@AttendeeLastName,
		@Email,
		@RegistrationDate
	)
COMMIT TRANSACTION

END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0 
		ROLLBACK TRANSACTION
END CATCH

END