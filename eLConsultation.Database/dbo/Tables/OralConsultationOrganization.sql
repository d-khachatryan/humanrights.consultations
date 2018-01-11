CREATE TABLE [dbo].[OralConsultationOrganization] (
    [OralConsultationOrganizationID] INT IDENTITY (1, 1) NOT NULL,
    [OralConsultationID]             INT NULL,
    [OrganizationID]                 INT NULL,
    PRIMARY KEY CLUSTERED ([OralConsultationOrganizationID] ASC),
    CONSTRAINT [FK_OralConsultationOrganization_OralConsultation] FOREIGN KEY ([OralConsultationID]) REFERENCES [dbo].[OralConsultation] ([OralConsultationID]) ON DELETE CASCADE,
    CONSTRAINT [FK_OralConsultationOrganization_Organization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[Organization] ([OrganizationID])
);


