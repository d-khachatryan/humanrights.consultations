CREATE TABLE [dbo].[TmpOralConsultationPermission] (
    [ID] INT NOT NULL IDENTITY, 
    [OralConsultationPermissionID]   INT              NULL,
    [OralConsultationID]             INT              NULL,
    [UserID]						 [nvarchar](128)              NULL,
	[IsRead] BIT NULL, 
    [IsChange] BIT NULL,
	[GUID] UNIQUEIDENTIFIER NULL
  CONSTRAINT [FK_TmpOralConsultationOrganization_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);
