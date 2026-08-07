USE HealthClinic;
GO

IF OBJECT_ID('trg_Appointments_Insert', 'TR') IS NOT NULL 
    DROP TRIGGER trg_Appointments_Insert;
GO

IF OBJECT_ID('AppointmentAudit', 'U') IS NOT NULL 
    DROP TABLE AppointmentAudit;
GO

IF OBJECT_ID('sp_BookAppointment', 'P') IS NOT NULL DROP PROCEDURE sp_BookAppointment;
IF OBJECT_ID('sp_GetPatientAppointments', 'P') IS NOT NULL DROP PROCEDURE sp_GetPatientAppointments;
IF OBJECT_ID('sp_GetDoctorAppointments', 'P') IS NOT NULL DROP PROCEDURE sp_GetDoctorAppointments;
IF OBJECT_ID('sp_UpdateAppointmentStatus', 'P') IS NOT NULL DROP PROCEDURE sp_UpdateAppointmentStatus;
IF OBJECT_ID('sp_CancelAppointment', 'P') IS NOT NULL DROP PROCEDURE sp_CancelAppointment;
IF OBJECT_ID('sp_GetAppointmentAuditLog', 'P') IS NOT NULL DROP PROCEDURE sp_GetAppointmentAuditLog;
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


CREATE PROCEDURE sp_BookAppointment
    @PatientId INT,
    @DoctorId INT,
    @AppointmentDate DATETIME,
    @Status NVARCHAR(20) = 'Scheduled'
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Patients WHERE PatientId = @PatientId)
    BEGIN
        RAISERROR('Invalid PatientId. Patient does not exist.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Doctors WHERE DoctorId = @DoctorId)
    BEGIN
        RAISERROR('Invalid DoctorId. Doctor does not exist.', 16, 1);
        RETURN;
    END

    INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status)
    VALUES (@PatientId, @DoctorId, @AppointmentDate, @Status);

    PRINT 'Appointment booked successfully.';
END
GO


CREATE PROCEDURE sp_GetPatientAppointments
    @PatientId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        A.AppointmentId,
        D.FirstName + ' ' + D.LastName AS DoctorName,
        D.Specialization,
        A.AppointmentDate,
        A.Status
    FROM Appointments A
    JOIN Doctors D ON A.DoctorId = D.DoctorId
    WHERE A.PatientId = @PatientId
    ORDER BY A.AppointmentDate;
END
GO


CREATE PROCEDURE sp_GetDoctorAppointments
    @DoctorId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        A.AppointmentId,
        P.FirstName + ' ' + P.LastName AS PatientName,
        P.Phone,
        A.AppointmentDate,
        A.Status
    FROM Appointments A
    JOIN Patients P ON A.PatientId = P.PatientId
    WHERE A.DoctorId = @DoctorId
    ORDER BY A.AppointmentDate;
END
GO

CREATE PROCEDURE sp_UpdateAppointmentStatus
    @AppointmentId INT,
    @NewStatus NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Appointments WHERE AppointmentId = @AppointmentId)
    BEGIN
        RAISERROR('Invalid AppointmentId.', 16, 1);
        RETURN;
    END

    UPDATE Appointments
    SET Status = @NewStatus
    WHERE AppointmentId = @AppointmentId;

    PRINT 'Appointment status updated successfully.';
END
GO

CREATE PROCEDURE sp_CancelAppointment
    @AppointmentId INT
AS
BEGIN
    SET NOCOUNT ON;
    EXEC sp_UpdateAppointmentStatus @AppointmentId, 'Cancelled';
END
GO

CREATE PROCEDURE sp_GetAppointmentAuditLog
    @AppointmentId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM AppointmentAudit
    WHERE AppointmentId = @AppointmentId
    ORDER BY ActionDate;
END
GO

SELECT name FROM sys.tables WHERE name = 'AppointmentAudit';
SELECT name FROM sys.triggers WHERE name = 'trg_Appointments_Insert';
SELECT name FROM sys.procedures WHERE name IN (
    'sp_BookAppointment',
    'sp_GetPatientAppointments',
    'sp_GetDoctorAppointments',
    'sp_UpdateAppointmentStatus',
    'sp_CancelAppointment',
    'sp_GetAppointmentAuditLog'
);
select * from AppointmentAudit;
select * from Patients;