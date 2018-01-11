CREATE TABLE [dbo].[TmpOralConsultationRight] (
    [ID] INT NOT NULL IDENTITY, 
    [OralConsultationRightID]   INT              NULL,
    [OralConsultationID]        INT              NULL,
    [HumanRightID]              INT              NULL,
	[GUID] UNIQUEIDENTIFIER NULL
  CONSTRAINT [FK_TmpOralConsultationRight_HumanRight] FOREIGN KEY ([HumanRightID]) REFERENCES [dbo].[HumanRight] ([HumanRightID])
);

