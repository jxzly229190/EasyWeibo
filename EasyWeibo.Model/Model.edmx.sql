
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/19/2013 23:05:39
-- Generated from EDMX file: D:\TaoBaoProject\TBAPITestTool\EasyWeibo\EasyWeibo.Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[easyads].[FK_PK_UserId]', 'F') IS NOT NULL
    ALTER TABLE [easyads].[platforminfo] DROP CONSTRAINT [FK_PK_UserId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[easyads].[platforminfo]', 'U') IS NOT NULL
    DROP TABLE [easyads].[platforminfo];
GO
IF OBJECT_ID(N'[easyads].[userinfo]', 'U') IS NOT NULL
    DROP TABLE [easyads].[userinfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'platforminfo'
CREATE TABLE [dbo].[platforminfo] (
    [SessionKey] varchar(128)  NOT NULL,
    [Refresh_token] varchar(128)  NOT NULL,
    [Nick] varchar(64)  NOT NULL,
    [PlatformUserId] varchar(32)  NOT NULL,
    [Platform] bigint  NOT NULL,
    [ExpireDate] datetime  NOT NULL,
    [AuthDate] datetime  NOT NULL,
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [UserId] bigint  NOT NULL
);
GO

-- Creating table 'userinfo'
CREATE TABLE [dbo].[userinfo] (
    [UserId] bigint IDENTITY(1,1) NOT NULL,
    [TB_UserId] varchar(64)  NOT NULL,
    [AccessToken] varchar(128)  NOT NULL,
    [RefreshToken] varchar(128)  NOT NULL,
    [Nick] varchar(64)  NOT NULL,
    [LastLogin] datetime  NOT NULL,
    [ExpireTime] datetime  NOT NULL,
    [AuthDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID], [UserId] in table 'platforminfo'
ALTER TABLE [dbo].[platforminfo]
ADD CONSTRAINT [PK_platforminfo]
    PRIMARY KEY CLUSTERED ([ID], [UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'userinfo'
ALTER TABLE [dbo].[userinfo]
ADD CONSTRAINT [PK_userinfo]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'platforminfo'
ALTER TABLE [dbo].[platforminfo]
ADD CONSTRAINT [FK_PK_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[userinfo]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PK_UserId'
CREATE INDEX [IX_FK_PK_UserId]
ON [dbo].[platforminfo]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------