USE HealthClinic;
GO

-- Create Doctors Table
CREATE TABLE Doctors (
    DoctorId        INT             PRIMARY KEY IDENTITY(1,1),
    FirstName       NVARCHAR(50)    NOT NULL,
    LastName        NVARCHAR(50)    NOT NULL,
    Specialization  NVARCHAR(50)    NOT NULL,
    Phone           NVARCHAR(15)    NULL
);
GO

-- Create Patients Table
CREATE TABLE Patients (
    PatientId       INT             PRIMARY KEY IDENTITY(1,1),
    FirstName       NVARCHAR(50)    NOT NULL,
    LastName        NVARCHAR(50)    NOT NULL,
    Phone           NVARCHAR(15)    NULL,
    DateOfBirth     DATE            NULL,
    Gender          NVARCHAR(10)    NULL
);
GO

-- Create Appointments Table

CREATE TABLE Appointments (
    AppointmentId     INT           PRIMARY KEY IDENTITY(1,1),
    PatientId         INT           NOT NULL,
    DoctorId          INT           NOT NULL,
    AppointmentDate   DATETIME      NOT NULL,
    Status            NVARCHAR(20)  NOT NULL DEFAULT 'Scheduled',

    CONSTRAINT FK_Appointments_Patient
        FOREIGN KEY (PatientId) REFERENCES Patients(PatientId)
        ON DELETE CASCADE,

    CONSTRAINT FK_Appointments_Doctor
        FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
        ON DELETE CASCADE
);
GO