CREATE TABLE [dbo].[workhourTemplate] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [name]  VARCHAR (100) NULL,
    [start] TIME (7)      NULL,
    [end]   TIME (7)      NULL,
    [rate]  REAL          NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

