CREATE TABLE [dbo].[Ciclo_Metrica]
(
	[IdCicloMetrica] INT NOT NULL PRIMARY KEY IDENTITY,
	[IdCiclo] INT NOT NULL, 
    [IdMetrica] INT NOT NULL, 
   
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [DescricaoMetrica] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Ciclo_Metrica] FOREIGN KEY ([IdCiclo]) REFERENCES [Ciclos]([IdCiclos]),
    CONSTRAINT [FK_Metrica_Ciclo] FOREIGN KEY ([IdMetrica]) REFERENCES [Metricas]([IdMetrica]),

)
