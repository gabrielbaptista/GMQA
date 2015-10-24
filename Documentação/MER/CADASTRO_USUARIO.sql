USE [GMQA]
GO

/****** Object:  Table [dbo].[Cadastrar_Usuario]    Script Date: 24/10/2015 12:44:29 ******/
DROP TABLE [dbo].[Cadastrar_Usuario]
GO

/****** Object:  Table [dbo].[Cadastrar_Usuario]    Script Date: 24/10/2015 12:44:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cadastrar_Usuario](
	[id_user] [numeric](18, 0) NOT NULL,
	[nome_user] [varchar](1024) NOT NULL,
	[email_user] [varchar](1024) NOT NULL,
	[senha_user] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Cadastrar_Usuario] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

