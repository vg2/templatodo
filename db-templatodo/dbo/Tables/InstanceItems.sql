CREATE TABLE [dbo].[InstanceItems] (
    [Id]                 BIGINT         NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Status]             NVARCHAR (50)  NOT NULL,
    [Comment]            NVARCHAR (400) NOT NULL,
    [TemplateInstanceId] BIGINT         NOT NULL,
    [Timestamp]          DATETIME2 (7)  NOT NULL,
    CONSTRAINT [FK_TemplateInstance_InstanceItems] FOREIGN KEY (TemplateInstanceId) REFERENCES [TemplateInstance](Id)
);
GO

