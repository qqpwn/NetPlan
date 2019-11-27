CREATE TABLE [dbo].[notify] (
    [id]          INT     NOT NULL,
    [approved]    TINYINT NULL,
    [description] TEXT    NULL,
    [fk_users]    INT     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

