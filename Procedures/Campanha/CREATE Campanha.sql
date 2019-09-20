USE [AdverHouseTimeSheet]
GO

/****** Object:  Table [dbo].[Campanha]    Script Date: 19/09/2019 14:22:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Campanha](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[idProduto] [int] NOT NULL,
 CONSTRAINT [PK__Campanha__3214EC070743A1BE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Campanha]  WITH CHECK ADD  CONSTRAINT [FK_Campanha_Produto] FOREIGN KEY([idProduto])
REFERENCES [dbo].[Produto] ([Id])
GO

ALTER TABLE [dbo].[Campanha] CHECK CONSTRAINT [FK_Campanha_Produto]
GO


