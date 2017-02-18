CREATE TABLE [dbo].[Riscos]
(
	[IdRisco] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DescricaoRisco] VARCHAR(50) NOT NULL, 
    [IdProjeto] INT NOT NULL, 
    [IdCiclo] INT NOT NULL, 
    [Categoria] INT NOT NULL, 
    [ProbabilidadeOcorrencia] INT NOT NULL, 
    [EfeitoOcorrencia] INT NOT NULL, 
    [Acao] VARCHAR(50) NOT NULL, 
    [ResponsavelAcao] VARCHAR(50) NOT NULL, 
    [Status] INT NOT NULL
)

GO

CREATE INDEX [IX_Riscos_Column] ON [dbo].[Riscos] ([DescricaoRisco])
