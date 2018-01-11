CREATE TABLE [dbo].[Setting]
(
[SettingItem] NVARCHAR(50) NOT NULL, 
    [SettingGroup] NVARCHAR(50) NOT NULL,     
    [SettingValue] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Setting] PRIMARY KEY ([SettingItem])
)

