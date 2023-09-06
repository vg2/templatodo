CREATE TABLE [dbo].[TemplateTodoItem] (
    [Id]                  BIGINT         NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [PointInCycle]        INT            NOT NULL,
    [Note]                NVARCHAR (100) NOT NULL,
    [TemplateCycleSlotId] BIGINT         NOT NULL,
    [TodoItemId]          BIGINT         NOT NULL,
    CONSTRAINT [FK_TodoItem_TemplateTodoItem] FOREIGN KEY ([TodoItemId]) REFERENCES [TodoItem](Id),
    CONSTRAINT [FK_TemplateCycleSlot_TemplateTodoItem] FOREIGN KEY ([TemplateCycleSlotId]) REFERENCES [TemplateCycleSlot](Id)
);
GO

