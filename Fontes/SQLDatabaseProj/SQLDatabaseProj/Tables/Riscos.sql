CREATE TABLE [dbo].[Riscos]
(
	[Id_risco] INT NOT NULL PRIMARY KEY, 
    [descricao_risco] NCHAR(10) NOT NULL
)

GO

CREATE INDEX [IX_Riscos_Column] ON [dbo].[Riscos] (descricao_risco)
