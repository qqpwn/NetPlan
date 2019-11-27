CREATE TABLE [dbo].[shiftrequests] (
    [id]             INT     NOT NULL,
    [description]    TEXT    NULL,
    [fk_users]       INT     NULL,
    [fk_requestType] INT     NULL,
    [approved]       TINYINT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

