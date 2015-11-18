CREATE TABLE [dbo].[Cadastrar_Usuario]
(
	[Id_usuario] INT NOT NULL PRIMARY KEY IDENTITY,  
    [nome_usuario] NCHAR(10) NOT NULL, 
    [email_usuario] NCHAR(10) NOT NULL, 
    [senha_usuario] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Cadastrar_Usuario_Usuarios] FOREIGN KEY (Id_usuario) REFERENCES [Usuarios]([Id_User])
)

GO

CREATE INDEX [IX_Cadastrar_Usuario] ON [dbo].[Cadastrar_Usuario] (nome_usuario)
