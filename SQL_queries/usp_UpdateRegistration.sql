--===========================================================================================
-- Author			: Stefano
-- Create Date		: Feb 22, 2024
-- Description		: Update a specific Registration record from the Registrations table
-- Name				: usp_UpdateRegistration
-- Params			: 
--===========================================================================================
-- REVISION
-- Author			: 
-- Revision Date	: 
-- Comments			: 
--===========================================================================================

CREATE OR ALTER   
PROCEDURE usp_UpdateRegistration
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
            SET 
                EventID = @EventID, 
                AttendeeFirstName = @AttendeeFirstName,
                AttendeeLastName = @AttendeeLastName,
                Email = @Email,
				RegistrationDate = @RegistrationDate
            WHERE 
                RegistrationId = @RegistrationId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF(@@TRANCOUNT > 0) 
            ROLLBACK TRANSACTION;
    END CATCH;
END;