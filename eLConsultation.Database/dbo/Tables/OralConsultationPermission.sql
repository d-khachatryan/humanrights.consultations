CREATE TABLE [dbo].[OralConsultationPermission]
(
	[OralConsultationPermissionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OralConsultationID] INT NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [IsRead] BIT NULL, 
    [IsChange] BIT NULL, 
    CONSTRAINT [FK_OralConsultationPermission_OralConsultation] FOREIGN KEY ([OralConsultationID]) REFERENCES [OralConsultation]([OralConsultationID]),
	CONSTRAINT [FK_OralConsultationPermission_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers]([Id])
)
