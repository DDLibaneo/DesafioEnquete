IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Polls] (
    [Id] int NOT NULL IDENTITY,
    [PollDescription] nvarchar(700) NOT NULL,
    CONSTRAINT [PK_Polls] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Options] (
    [Id] int NOT NULL IDENTITY,
    [OptionDescription] nvarchar(500) NOT NULL,
    [Votes] int NOT NULL,
    [PollId] int NOT NULL,
    CONSTRAINT [PK_Options] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Options_Polls_PollId] FOREIGN KEY ([PollId]) REFERENCES [Polls] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Options_PollId] ON [Options] ([PollId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201212231101_AddOptionAndPollModels', N'5.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Polls] ADD [Views] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201213201114_AddPropViewsToPoll', N'5.0.1');
GO

COMMIT;
GO

