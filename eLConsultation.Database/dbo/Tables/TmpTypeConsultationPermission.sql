CREATE TABLE [dbo].[TmpTypeConsultationPermission] (
    [ID] INT NOT NULL IDENTITY, 
    [TypeConsultationPermissionID]   INT              NULL,
    [TypeConsultationID]             INT              NULL,
    [UserID]							 [nvarchar](128)              NULL,
	[IsRead] BIT NULL, 
    [IsChange] BIT NULL,
	[GUID] UNIQUEIDENTIFIER NULL
  CONSTRAINT [FK_TmpTypeConsultationOrganization_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);
