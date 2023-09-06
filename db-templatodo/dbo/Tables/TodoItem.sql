CREATE TABLE [dbo].[TodoItem] (
    [Id]                BIGINT         NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name]              NVARCHAR (100) NOT NULL,
    [Description]       NVARCHAR (400) NOT NULL,
    [DurationInMinutes] INT            NOT NULL
);
GO

