CREATE TABLE [dbo].[TmpTypeConsultationRight] (
    [ID] INT NOT NULL IDENTITY, 
    [TypeConsultationRightID]   INT              NULL,
    [TypeConsultationID]        INT              NULL,
    [HumanRightID]              INT              NULL,
	[GUID] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT [FK_TmpTypeConsultationRight_HumanRight] FOREIGN KEY ([HumanRightID]) REFERENCES [dbo].[HumanRight] ([HumanRightID])
    CONSTRAINT [PK_TmpTypeConsultationRight] PRIMARY KEY ([ID])
);

