CREATE TABLE [dbo].[TypeConsultationRecipient] (
    [TypeConsultationRecipientID] INT  IDENTITY (1, 1) NOT NULL,
    [TypeConsultationID]          INT  NULL,
    [RecipientDate]               DATE NULL,
    [OrganizationID]              INT  NULL,
    PRIMARY KEY CLUSTERED ([TypeConsultationRecipientID] ASC),
    CONSTRAINT [FK_TypeConsultationRecipient_Organization] FOREIGN KEY ([OrganizationID]) REFERENCES [dbo].[Organization] ([OrganizationID]),
    CONSTRAINT [FK_TypeConsultationRecipient_TypeConsultation] FOREIGN KEY ([TypeConsultationID]) REFERENCES [dbo].[TypeConsultation] ([TypeConsultationID]) ON DELETE CASCADE
);


