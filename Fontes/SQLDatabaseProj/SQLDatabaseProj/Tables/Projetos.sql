CREATE TABLE [dbo].[Projetos]
(
	[Id_Proj] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(1024) NOT NULL, 
    [IdUser] INT NOT NULL, 
    CONSTRAINT [FK_Projetos_Usuarios] FOREIGN KEY ([IdUser]) REFERENCES [Usuarios]([Id_User])
)

GO

CREATE UNIQUE INDEX [IX_Projetos_Nome] ON [dbo].[Projetos] ([Nome])
