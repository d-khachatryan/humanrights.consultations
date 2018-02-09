ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD BirthYear SMALLINT
ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD Phone nvarchar(20)
ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD Email nvarchar(50)

UPDATE dbo.Setting SET SettingValue = '1.0.2.0' WHERE SettingItem = 'version' 