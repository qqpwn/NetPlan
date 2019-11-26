CREATE TABLE [dbo].[corrections] (
    [id]                  INT     NOT NULL,
    [fk_users]            INT     NULL,
    [fk_shifts_primary]   INT     NULL,
    [fk_shifts_secondary] INT     NULL,
    [hours]               REAL    NULL,
    [approved]            TINYINT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

