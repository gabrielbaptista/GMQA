CREATE TABLE [dbo].[Etapas]
(
	[IdEtapas] INT NOT NULL PRIMARY KEY, 
    [Planejamento] VARCHAR(1024) NOT NULL, 
    [Escopo] VARCHAR(1024) NOT NULL, 
    [Execucao] VARCHAR(1024) NOT NULL, 
    [Gerenciamento] VARCHAR(1024) NOT NULL, 
    [Entrega] VARCHAR(1024) NOT NULL

)

GO
