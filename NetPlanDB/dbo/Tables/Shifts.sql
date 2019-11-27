CREATE TABLE [dbo].[Shifts] (
    [id]                  INT  IDENTITY (1, 1) NOT NULL,
    [date]                DATE NULL,
    [fk_workhourTemplate] INT  NULL,
    [fk_users]            INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

