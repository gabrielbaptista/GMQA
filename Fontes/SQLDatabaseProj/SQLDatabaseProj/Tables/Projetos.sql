CREATE TABLE [dbo].[Projetos]
(
	[Id_projeto] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(1024) NOT NULL, 
    [Cliente_projeto] VARCHAR(1024) NOT NULL, 
    [Data_inicio] DATE NOT NULL, 
    [Dta_fim] DATE NOT NULL, 
    [Data_real] DATE NULL, 
    [Responsavel_projeto] VARCHAR(1024) NOT NULL, 
    [Adm_projeto] VARCHAR(1024) NOT NULL, 
    CONSTRAINT [FK_Projetos_Usuarios] FOREIGN KEY (Id_projeto) REFERENCES [Usuarios]([Id_user]), 
    CONSTRAINT [FK_Projetos_Riscos] FOREIGN KEY (Id_projeto) REFERENCES [Riscos](Id_risco) 
    
)

GO

CREATE UNIQUE INDEX [IX_Projetos_Nome] ON [dbo].[Projetos] ([Nome])
