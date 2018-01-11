CREATE TABLE [dbo].[OralConsultationRight] (
    [OralConsultationRightID] INT IDENTITY (1, 1) NOT NULL,
    [OralConsultationID]      INT NULL,
    [HumanRightID]            INT NULL,
    PRIMARY KEY CLUSTERED ([OralConsultationRightID] ASC),
    CONSTRAINT [FK_OralConsultationRight_HumanRight] FOREIGN KEY ([HumanRightID]) REFERENCES [dbo].[HumanRight] ([HumanRightID]),
    CONSTRAINT [FK_OralConsultationRight_OralConsultation] FOREIGN KEY ([OralConsultationID]) REFERENCES [dbo].[OralConsultation] ([OralConsultationID]) ON DELETE CASCADE
);


