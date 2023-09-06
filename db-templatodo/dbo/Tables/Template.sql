CREATE TABLE [dbo].[Template] (
    [Id]          BIGINT         NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (400) NULL,
    [CycleLength] INT            NOT NULL,
    [Frequency]   NVARCHAR (50)  NOT NULL,
    [StartDate]   DATETIME2 (7)  NOT NULL
);
GO