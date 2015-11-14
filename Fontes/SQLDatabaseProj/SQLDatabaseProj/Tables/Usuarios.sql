CREATE TABLE [dbo].[Usuarios]
(
	[Id_User] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nome] varchar(1024) NOT NULL,
	[Email] varchar(1024) NOT NULL,
	[Senha] varchar(50) NOT NULL -- Campo criptografado
)

GO

CREATE UNIQUE INDEX [IX_Usuario_Email] ON [dbo].[Usuarios] (Email)
