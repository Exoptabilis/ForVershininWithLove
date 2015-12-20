
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/20/2015 18:31:07
-- Generated from EDMX file: C:\Users\Sukhanov\Desktop\ВлГУ\3курс\Вершинин\Курсач\kyrsach-svn-3\Kyrsach\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Articles_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articles] DROP CONSTRAINT [FK_Articles_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_ToTable1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_ToTable1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Articles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articles];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Tests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tests];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [IdArticle] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [thema] nvarchar(50)  NOT NULL,
    [text] nvarchar(max)  NOT NULL,
    [dataAdd] datetime  NOT NULL,
    [idTest] int  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [IdComment] int IDENTITY(1,1) NOT NULL,
    [dataAdd] datetime  NOT NULL,
    [idTest] int  NOT NULL,
    [UserName] char(10)  NOT NULL,
    [Mark] int  NULL
);
GO

-- Creating table 'Tests'
CREATE TABLE [dbo].[Tests] (
    [IdTest] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(10)  NULL,
    [Thema] nchar(10)  NULL,
    [Question1] nchar(10)  NULL,
    [Question2] nchar(10)  NULL,
    [Question3] nchar(10)  NULL,
    [Question4] nchar(10)  NULL,
    [Question5] nchar(10)  NULL,
    [Answer1] nchar(10)  NULL,
    [Answer2] nchar(10)  NULL,
    [Answer3] nchar(10)  NULL,
    [Answer4] nchar(10)  NULL,
    [Answer5] nchar(10)  NULL,
    [Date] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdArticle] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([IdArticle] ASC);
GO

-- Creating primary key on [IdComment] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([IdComment] ASC);
GO

-- Creating primary key on [IdTest] in table 'Tests'
ALTER TABLE [dbo].[Tests]
ADD CONSTRAINT [PK_Tests]
    PRIMARY KEY CLUSTERED ([IdTest] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idTest] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [FK_Articles_ToTable]
    FOREIGN KEY ([idTest])
    REFERENCES [dbo].[Tests]
        ([IdTest])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Articles_ToTable'
CREATE INDEX [IX_FK_Articles_ToTable]
ON [dbo].[Articles]
    ([idTest]);
GO

-- Creating foreign key on [idTest] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_ToTable1]
    FOREIGN KEY ([idTest])
    REFERENCES [dbo].[Tests]
        ([IdTest])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_ToTable1'
CREATE INDEX [IX_FK_Comments_ToTable1]
ON [dbo].[Comments]
    ([idTest]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------