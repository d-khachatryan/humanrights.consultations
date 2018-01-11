CREATE TABLE [dbo].[TmpTypeConsultationRecipient] (
    [ID] INT NOT NULL IDENTITY, 
    [TypeConsultationRecipientID]   INT              NULL,
    [TypeConsultationID]            INT              NULL,
    [RecipientDate]                 DATE             NULL,
    [OrganizationID]                INT              NULL,
	[GUID] UNIQUEIDENTIFIER NOT NULL
    CONSTRAINT [FK_TmpTypeConsultationRecipient_Organization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[Organization] ([OrganizationID])
    CONSTRAINT [PK_TmpTypeConsultationRecipient] PRIMARY KEY ([ID])
);

