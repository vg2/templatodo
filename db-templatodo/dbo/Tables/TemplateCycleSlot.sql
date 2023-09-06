CREATE TABLE [dbo].[TemplateCycleSlot] (
    [Id]                BIGINT         NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [Name]              NVARCHAR (100) NOT NULL,
    [Description]       NVARCHAR (400) NOT NULL,
    [DurationInMinutes] INT            NOT NULL,
    [TimeOfDay]         TIME (7)       NOT NULL,
    [TemplateId]        BIGINT         NOT NULL,
    CONSTRAINT [FK_TemplateCycleSlot_Template] FOREIGN KEY (TemplateId) REFERENCES [Template](Id)
);
GO

