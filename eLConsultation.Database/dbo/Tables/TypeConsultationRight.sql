CREATE TABLE [dbo].[TypeConsultationRight] (
    [TypeConsultationRightID] INT IDENTITY (1, 1) NOT NULL,
    [TypeConsultationID]      INT NULL,
    [HumanRightID]            INT NULL,
    PRIMARY KEY CLUSTERED ([TypeConsultationRightID] ASC),
    CONSTRAINT [FK_TypeConsultationRight_HumanRight] FOREIGN KEY ([HumanRightID]) REFERENCES [dbo].[HumanRight] ([HumanRightID]),
    CONSTRAINT [FK_TypeConsultationRight_TypeConsultation] FOREIGN KEY ([TypeConsultationID]) REFERENCES [dbo].[TypeConsultation] ([TypeConsultationID]) ON DELETE CASCADE
);


