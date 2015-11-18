CREATE TABLE [dbo].[Cadastrar_Usuario]
(
	[Id_usuario] INT NOT NULL PRIMARY KEY IDENTITY,  
    [nome_usuario] NCHAR(10) NOT NULL, 
    [email_usuario] NCHAR(10) NOT NULL, 
    [senha_usuario] NCHAR(10) NOT NULL
)

GO

CREATE INDEX [IX_Cadastrar_Usuario] ON [dbo].[Cadastrar_Usuario] (nome_usuario)
