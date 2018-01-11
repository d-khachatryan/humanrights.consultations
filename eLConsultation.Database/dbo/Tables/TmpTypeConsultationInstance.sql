CREATE TABLE [dbo].[TmpTypeConsultationInstance] (
    [ID] INT NOT NULL IDENTITY, 
    [TypeConsultationInstanceID]   INT              NULL,
    [TypeConsultationID]           INT              NULL,
    [OrganizationID]                  INT              NULL,
	[GUID] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT [FK_TmpTypeConsultationInstance_Organization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[Organization] ([OrganizationID]), 
    CONSTRAINT [PK_TmpTypeConsultationInstance] PRIMARY KEY ([ID])
);

