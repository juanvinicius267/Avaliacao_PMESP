IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'db_pmesp')
BEGIN
CREATE DATABASE db_pmesp;
END
GO
USE db_pmesp;
GO


IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='tb_tabela' AND xtype='U')
CREATE TABLE [tb_tabela] (
    [ID] int NOT NULL IDENTITY,
    [NomeDoProduto] nvarchar(max) NULL,
    [Quantidade] int NOT NULL,
    [ValorUnit] float NOT NULL,
    [DataEntrega] datetime2 NOT NULL,
    CONSTRAINT [PK_tb_tabela] PRIMARY KEY ([ID])
);

GO

INSERT INTO [dbo].[tb_tabela] ([NomeDoProduto], [Quantidade], [ValorUnit], [DataEntrega]) VALUES ( N'Descrição 1', 1, 10.1, N'2020-12-25 00:00:00');
INSERT INTO [dbo].[tb_tabela] ([NomeDoProduto], [Quantidade], [ValorUnit], [DataEntrega]) VALUES ( N'Descrição 2', 2, 11.1, N'2020-12-25 00:00:00');
INSERT INTO [dbo].[tb_tabela] ([NomeDoProduto], [Quantidade], [ValorUnit], [DataEntrega]) VALUES ( N'Descrição 3', 3, 12.1, N'2020-12-25 00:00:00');

GO