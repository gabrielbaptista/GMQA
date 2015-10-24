USE [GMQA]
GO

/****** Object:  Table [dbo].[Cadastrar_Projeto]    Script Date: 24/10/2015 12:43:50 ******/
DROP TABLE [dbo].[Cadastrar_Projeto]
GO

/****** Object:  Table [dbo].[Cadastrar_Projeto]    Script Date: 24/10/2015 12:43:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cadastrar_Projeto](
	[id_proj] [numeric](18, 0) NOT NULL,
	[nome_proj] [varchar](1024) NOT NULL,
	[cliente_proj] [varchar](1024) NOT NULL,
	[dat_ini] [date] NOT NULL,
	[dat_fim] [date] NOT NULL,
	[dat_real] [date] NULL,
	[resp_proj] [varchar](1024) NOT NULL,
	[adm_proj] [varchar](1024) NOT NULL,
 CONSTRAINT [PK_Cadastrar_Projeto] PRIMARY KEY CLUSTERED 
(
	[id_proj] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

