CREATE TABLE [dbo].[TemplateInstance] (
    [Id]                 BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [TemplateTodoItemId] BIGINT NOT NULL,
    CONSTRAINT [FK_TemplateTodoItem_TemplateInstance] FOREIGN KEY (TemplateTodoItemId) REFERENCES [TemplateTodoItem](Id)
);
GO

