CREATE TABLE [dbo].[booking] (
    [Id1]        INT           NOT NULL,
    [name]       VARCHAR (50)  NOT NULL,
    [category]   NVARCHAR (50) NOT NULL,
    [price]      NUMERIC (5)   NOT NULL,
    [quantity]   INT           NOT NULL,
    [total]      NUMERIC (18)  NOT NULL,
    [first_name] VARCHAR (50)  NOT NULL,
    [last_name]  VARCHAR (50)  NOT NULL,
    [username]   VARCHAR (50)  NOT NULL,
    [contact_no] NUMERIC (10)  NOT NULL
);

