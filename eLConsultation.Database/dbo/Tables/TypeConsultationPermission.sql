CREATE TABLE [dbo].[TypeConsultationPermission]
(
	[TypeConsultationPermissionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeConsultationID] INT NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [IsRead] BIT NULL, 
    [IsChange] BIT NULL, 
    CONSTRAINT [FK_TypeConsultationPermission_TypeConsultation] FOREIGN KEY ([TypeConsultationID]) REFERENCES [TypeConsultation]([TypeConsultationID]),
	CONSTRAINT [FK_TypeConsultationPermission_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
)