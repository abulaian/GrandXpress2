IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Senders] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Address1] nvarchar(max) NULL,
    [Address2] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    CONSTRAINT [PK_Senders] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Receiver] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Address1] nvarchar(max) NULL,
    [Address2] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    [Country] nvarchar(max) NULL,
    [SenderId] int NULL,
    CONSTRAINT [PK_Receiver] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Receiver_Senders_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [Senders] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Transactions] (
    [Id] int NOT NULL IDENTITY,
    [SenderId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [CloseDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Senders_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [Senders] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Item] (
    [Id] int NOT NULL IDENTITY,
    [Amount] decimal(18, 2) NOT NULL,
    [ReceiverId] int NOT NULL,
    [TransactionId] int NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Item_Receiver_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [Receiver] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Item_Transactions_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [Transactions] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Item_ReceiverId] ON [Item] ([ReceiverId]);

GO

CREATE INDEX [IX_Item_TransactionId] ON [Item] ([TransactionId]);

GO

CREATE INDEX [IX_Receiver_SenderId] ON [Receiver] ([SenderId]);

GO

CREATE INDEX [IX_Transactions_SenderId] ON [Transactions] ([SenderId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180601222501_initeGrandXpressDb', N'2.1.0-rtm-30799');

GO

