CREATE TABLE [dbo].[Riscos]
(
	[IdRisco] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DescricaoRisco] VARCHAR(50) NOT NULL, 
    [IdProjeto] INT NULL, 
    [IdCiclo] INT NULL, 
    [Categoria] INT NULL, 
    [ProbabilidadeOcorrencia] INT NULL, 
    [EfeitoOcorrencia] INT NULL, 
    [Acao] VARCHAR(50) NULL, 
    [ResponsavelAcao] VARCHAR(50) NULL, 
    [Status] INT NULL
)

--GO

----CREATE INDEX [IX_Riscos_Column] ON [dbo].[Riscos] ([DescricaoRisco])
