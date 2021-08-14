CREATE TABLE [dbo].[food] (
    [Id]       INT           NOT NULL,
    [name]     VARCHAR (50)  NOT NULL,
    [price]    NUMERIC (5)   NOT NULL,
    [image]    VARCHAR (MAX) NOT NULL,
    [category] VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

