IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [tb_tabela] (
    [ID] int NOT NULL IDENTITY,
    [NomeDoProduto] nvarchar(max) NULL,
    [Quantidade] int NOT NULL,
    [ValorUnit] float NOT NULL,
    [DataEntrega] datetime2 NOT NULL,
    CONSTRAINT [PK_tb_tabela] PRIMARY KEY ([ID])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201221154921_InitialCreate', N'2.1.14-servicing-32113');

GO

