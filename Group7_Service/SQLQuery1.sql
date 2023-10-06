CREATE TABLE [dbo].[User] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Type]     INT           NOT NULL,
    [Name]     VARCHAR (250) NOT NULL,
    [Surname]  VARCHAR (250) NOT NULL,
	[Phone]    VARCHAR (250) NOT NULL,
    [Email]    VARCHAR (250) NOT NULL,
    [Password] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Client] (
    [ClientId] INT           IDENTITY (1, 1) NOT NULL,
    [UserId]   INT           NOT NULL,
    [Address]  VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([ClientId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);