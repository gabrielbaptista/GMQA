CREATE TABLE [dbo].[CiclosProjetos]
(
	[IdCicloProjeto] INT NOT NULL PRIMARY KEY, 
    [NumeroCiclo] INT NOT NULL, 
    [FaseCiclo] VARCHAR(50) NOT NULL, 
    [DataInicio] DATE NOT NULL, 
    [DataFim] DATE NOT NULL, 
    [IdProjeto] INT NOT NULL, 
    CONSTRAINT [FK_CiclosProjetos_Projetos] FOREIGN KEY ([IdProjeto]) REFERENCES [Projetos]([IdProjeto])
)
