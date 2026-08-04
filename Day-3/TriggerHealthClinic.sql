USE HealthClinic;
GO

CREATE TABLE AppointmentAudit (
    AuditId         INT           PRIMARY KEY IDENTITY(1,1),
    AppointmentId   INT           NOT NULL,
    PatientId       INT           NOT NULL,
    DoctorId        INT           NOT NULL,
    AppointmentDate DATETIME      NOT NULL,
    Status          NVARCHAR(20)  NOT NULL,
    ActionType      NVARCHAR(10)  NOT NULL,
    ActionBy        NVARCHAR(50)  NULL,
    ActionDate      DATETIME      DEFAULT GETDATE()
);
GO

CREATE TRIGGER trg_Appointments_Insert
ON Appointments
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO AppointmentAudit (AppointmentId, PatientId, DoctorId, AppointmentDate, Status, ActionType, ActionBy)
    SELECT 
        i.AppointmentId,
        i.PatientId,
        i.DoctorId,
        i.AppointmentDate,
        i.Status,
        'INSERT',
        SYSTEM_USER
    FROM INSERTED i;
END
GO




SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AppointmentAudit';

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status)
VALUES (1, 1, '2026-08-11 10:00:00', 'Scheduled');


INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status)
VALUES (1, 1, '2026-08-12 09:00:00', 'Scheduled');

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status)
VALUES (1, 1, '2026-08-13 11:30:00', 'Scheduled');

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status)
VALUES (1, 1, '2026-08-14 14:00:00', 'Completed');

INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status)
VALUES (1, 1, '2026-08-15 16:45:00', 'Cancelled');


SELECT * FROM Appointments;
SELECT * FROM AppointmentAudit;

INSERT INTO Patients (FirstName, LastName, Phone, DateOfBirth, Gender)
VALUES ('Priya', 'Singh', '9988776655', '1998-03-20', 'Female');

INSERT INTO Doctors (FirstName, LastName, Specialization, Phone)
VALUES ('Suresh', 'Mehta', 'Orthopedics', '9223344556');


SELECT PatientId, FirstName FROM Patients;
SELECT DoctorId, FirstName FROM Doctors;