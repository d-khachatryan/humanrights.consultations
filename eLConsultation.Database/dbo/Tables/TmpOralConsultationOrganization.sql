CREATE TABLE [dbo].[TmpOralConsultationOrganization] (
    [ID] INT NOT NULL IDENTITY, 
    [OralConsultationOrganizationID]   INT              NULL,
    [OralConsultationID]               INT              NULL,
    [OrganizationID]                   INT              NULL,
	[GUID] UNIQUEIDENTIFIER NULL
  CONSTRAINT [FK_TmpOralConsultationOrganization_Organization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[Organization] ([OrganizationID])
);

