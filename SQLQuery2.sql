-- Create table ' File'
CREATE TABLE [dbo]. [Files] (
[Id] int IDENTITY (1,1) NOT NULL,
[Path] nvarchar (max) NOT NULL,
[Name] nvarchar (max) NOT NULL,
PRIMARY KEY CLUSTERED ([Id] ASC)
);