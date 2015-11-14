CREATE TABLE [dbo].[Projetos]
(
	[Id_Proj] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(1024) NOT NULL, 
    [Id_User] INT NOT NULL, 
    CONSTRAINT [FK_Projetos_Usuarios] FOREIGN KEY ([Id_User]) REFERENCES [Usuarios]([Id_User])
)

GO

CREATE UNIQUE INDEX [IX_Projetos_Nome] ON [dbo].[Projetos] ([Nome])
