USE HealthClinic;
GO

-- Rooms table
CREATE TABLE Rooms (
    RoomId      INT           PRIMARY KEY IDENTITY(1,1),
    RoomNumber  NVARCHAR(10)  NOT NULL,
    FloorNumber INT           NOT NULL,
    RoomType    NVARCHAR(30)  NULL  
);
GO

CREATE TABLE DoctorRoom (
    DoctorRoomId  INT          PRIMARY KEY IDENTITY(1,1),
    DoctorId      INT          NOT NULL,
    RoomId        INT          NOT NULL,
    AssignedDay   NVARCHAR(10) NOT NULL,  
    ShiftStart    TIME         NOT NULL,
    ShiftEnd      TIME         NOT NULL,

    CONSTRAINT FK_DoctorRoom_Doctor
        FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
        ON DELETE CASCADE,

    CONSTRAINT FK_DoctorRoom_Room
        FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
        ON DELETE CASCADE,

    CONSTRAINT UQ_Doctor_Room_Day
        UNIQUE (DoctorId, RoomId, AssignedDay)  
);
GO