-- Create the Event Registration System database
CREATE DATABASE EventRegistrationSystem

-- Create Events table
CREATE TABLE Events (
    EventID INT PRIMARY KEY IDENTITY(1, 1),
    Name VARCHAR(50) NOT NULL,
    Date DATE NOT NULL,
    Location VARCHAR(50) NOT NULL,
    Description TEXT
);

-- Create Registrations table
CREATE TABLE Registrations (
    RegistrationID INT PRIMARY KEY IDENTITY(1, 1),
    EventID INT REFERENCES Events(EventID), -- FK
    AttendeeFirstName VARCHAR(50) NOT NULL,
		AttendeeLastName VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    RegistrationDate DATETIME NOT NULL,
);
