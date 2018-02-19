
--GO

--IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'BirthYear' AND Object_ID = Object_ID(N'dbo.Resident'))
--	ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD BirthYear SMALLINT

--IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'Phone' AND Object_ID = Object_ID(N'dbo.Resident'))
--	ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD Phone nvarchar(20)

--IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'Email' AND Object_ID = Object_ID(N'dbo.Resident'))
--	ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD Email nvarchar(50)

--UPDATE dbo.Setting SET SettingValue = '1.0.2.0' WHERE SettingItem = 'version'