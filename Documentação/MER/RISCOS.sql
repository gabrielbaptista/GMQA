USE [GMQA]
GO

/****** Object:  Table [dbo].[Riscos]    Script Date: 24/10/2015 12:45:00 ******/
DROP TABLE [dbo].[Riscos]
GO

/****** Object:  Table [dbo].[Riscos]    Script Date: 24/10/2015 12:45:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Riscos](
	[id_risc] [numeric](18, 0) NOT NULL,
	[desc_risc] [varchar](1024) NOT NULL,
 CONSTRAINT [PK_Riscos] PRIMARY KEY CLUSTERED 
(
	[id_risc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

