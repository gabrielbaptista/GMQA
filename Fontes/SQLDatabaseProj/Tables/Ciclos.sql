CREATE TABLE [dbo].[CiclosProjetos]
(
	[IdCiclos] INT NOT NULL PRIMARY KEY, 
    [NumeroCiclo] INT NOT NULL, 
    [FaseCiclo] VARCHAR(50) NOT NULL, 
    [DataInicio] DATE NOT NULL, 
    [DataFim] DATE NOT NULL, 
    [IdProjeto] INT NOT NULL, 
    [IdEtapas] INT NOT NULL, 
    CONSTRAINT [FK_Ciclos_Projetos] FOREIGN KEY ([IdProjeto]) REFERENCES [Projetos]([IdProjeto]), 
    CONSTRAINT [FK_Ciclos_Etapas] FOREIGN KEY ([IdEtapas]) REFERENCES [Etapas]([IdEtapas])
)
