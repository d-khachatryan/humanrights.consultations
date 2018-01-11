CREATE TABLE [dbo].[TypeConsultationConsultant] (
    [TypeConsultationConsultantID] INT IDENTITY (1, 1) NOT NULL,
    [TypeConsultationID]           INT NULL,
    [ConsultantID]                 INT NULL,
    PRIMARY KEY CLUSTERED ([TypeConsultationConsultantID] ASC),
    CONSTRAINT [FK_TypeConsultationConsultant_Consultant] FOREIGN KEY ([ConsultantID]) REFERENCES [dbo].[Consultant] ([ConsultantID]),
    CONSTRAINT [FK_TypeConsultationConsultant_TypeConsultation] FOREIGN KEY ([TypeConsultationID]) REFERENCES [dbo].[TypeConsultation] ([TypeConsultationID]) ON DELETE CASCADE
);


