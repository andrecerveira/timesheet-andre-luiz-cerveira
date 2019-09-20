USE [AdverHouseTimeSheet]
GO

/****** Object:  Table [dbo].[Produto]    Script Date: 19/09/2019 14:23:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[idCliente] [int] NOT NULL,
 CONSTRAINT [PK__Produto__3214EC07E45D16BC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_Produto_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO

ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_Produto_Cliente]
GO


