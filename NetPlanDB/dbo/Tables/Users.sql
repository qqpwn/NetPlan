CREATE TABLE [dbo].[Users] (
    [id]          INT           NOT NULL,
    [email]       VARCHAR (100) NULL,
    [password]    VARCHAR (32)  NULL,
    [salt]        VARCHAR (3)   NULL,
    [name]        VARCHAR (100) NULL,
    [phone]       INT           NULL,
    [description] TEXT          NULL,
    [accessLevel] INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

