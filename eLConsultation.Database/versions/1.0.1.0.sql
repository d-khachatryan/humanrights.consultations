IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_TypeConsultationDeclarationType_ResponseContent')
	ALTER TABLE [dbo].[TypeConsultationDeclarationType] DROP CONSTRAINT [FK_TypeConsultationDeclarationType_ResponseContent]

IF EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ResponseContentID' AND Object_ID = Object_ID(N'dbo.TypeConsultationDeclarationType'))
	ALTER TABLE [dbo].[TypeConsultationDeclarationType] DROP COLUMN [ResponseContentID]

ALTER TABLE [dbo].[TypeConsultationDeclarationType] ADD [ResponseContent] NVARCHAR(100)

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_TmpTypeConsultationDeclarationType_ResponseContent')
	ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] DROP CONSTRAINT [FK_TmpTypeConsultationDeclarationType_ResponseContent]

IF EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ResponseContentID' AND Object_ID = Object_ID(N'dbo.TmpTypeConsultationDeclarationType'))
ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] DROP COLUMN [ResponseContentID]

ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] ADD [ResponseContent] NVARCHAR(100)

UPDATE dbo.Setting SET SettingValue = '1.0.1.0' WHERE SettingItem = 'version' 
GO