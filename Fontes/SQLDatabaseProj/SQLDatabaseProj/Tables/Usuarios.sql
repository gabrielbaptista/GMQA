CREATE TABLE [dbo].[Usuarios]
(
	[IdUser] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nome] varchar(1024) NOT NULL,
	[Email] varchar(1024) NOT NULL,
	[Senha] varchar(50) NOT NULL -- Campo criptografado
, 
    [IdNivelAcesso] INT NOT NULL, 
    CONSTRAINT [FK_Usuarios_NivelAcesso] FOREIGN KEY ([IdNivelAcesso]) REFERENCES [NiveisAcesso]([IdNivelAcesso]))

GO

CREATE UNIQUE INDEX [IX_Usuario_Email] ON [dbo].[Usuarios] (Email)
