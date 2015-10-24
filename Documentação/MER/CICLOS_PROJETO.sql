USE [GMQA]
GO

/****** Object:  Table [dbo].[Ciclos_Projeto]    Script Date: 24/10/2015 12:44:49 ******/
DROP TABLE [dbo].[Ciclos_Projeto]
GO

/****** Object:  Table [dbo].[Ciclos_Projeto]    Script Date: 24/10/2015 12:44:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ciclos_Projeto](
	[id_ciclo] [numeric](18, 0) NOT NULL,
	[num_ciclo] [numeric](18, 0) NOT NULL,
	[dat_ini] [date] NOT NULL,
	[dat_fim] [date] NOT NULL,
 CONSTRAINT [PK_Ciclos_Projeto] PRIMARY KEY CLUSTERED 
(
	[id_ciclo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

