CREATE TABLE [dbo].[Shifttransfers] (
    [id]                 INT     NOT NULL,
    [fk_shiftRequest]    INT     NULL,
    [fk_shifts]          INT     NULL,
    [fk_users_primary]   INT     NULL,
    [fk_users_secondary] INT     NULL,
    [approved]           TINYINT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

