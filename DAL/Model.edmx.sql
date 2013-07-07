
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/07/2013 14:49:20
-- Generated from EDMX file: D:\TaoBaoProject\TBAPITestTool\EasyWeibo\DAL\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[easyads].[userinfo]', 'U') IS NOT NULL
    DROP TABLE [easyads].[userinfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'userinfoes'
CREATE TABLE [dbo].[userinfoes] (
    [UserId] bigint IDENTITY(1,1) NOT NULL,
    [TB_UserId] nvarchar(1000)  NOT NULL,
    [AccessToken] nvarchar(1000)  NOT NULL,
    [RefreshToken] nvarchar(1000)  NOT NULL,
    [Nick] nvarchar(1000)  NOT NULL,
    [AuthDate] datetime  NOT NULL,
    [LastLogin] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'userinfoes'
ALTER TABLE [dbo].[userinfoes]
ADD CONSTRAINT [PK_userinfoes]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------