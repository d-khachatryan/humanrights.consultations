CREATE TABLE [dbo].[TypeConsultationInstance] (
    [TypeConsultationInstanceID] INT IDENTITY (1, 1) NOT NULL,
    [TypeConsultationID]         INT NULL,
    [OrganizationID]             INT NULL,
    PRIMARY KEY CLUSTERED ([TypeConsultationInstanceID] ASC),
    CONSTRAINT [FK_TypeConsultationInstance_Organization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[Organization] ([OrganizationID]),
    CONSTRAINT [FK_TypeConsultationInstance_TypeConsultation] FOREIGN KEY ([TypeConsultationID]) REFERENCES [dbo].[TypeConsultation] ([TypeConsultationID]) ON DELETE CASCADE
);


