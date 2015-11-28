CREATE TABLE [dbo].[Riscos]
(
	[IdRisco] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DescricaoRisco] VARCHAR(50) NOT NULL
)

GO

CREATE INDEX [IX_Riscos_Column] ON [dbo].[Riscos] ([DescricaoRisco])
