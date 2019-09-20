USE [AdverHouseTimeSheet]
GO

/****** Object:  Table [dbo].[UsuarioCliente]    Script Date: 19/09/2019 14:24:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsuarioCliente](
	[Id] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
 CONSTRAINT [PK__UsuarioC__3214EC0719109B80] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsuarioCliente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCliente_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO

ALTER TABLE [dbo].[UsuarioCliente] CHECK CONSTRAINT [FK_UsuarioCliente_Cliente]
GO

ALTER TABLE [dbo].[UsuarioCliente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioCliente_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO

ALTER TABLE [dbo].[UsuarioCliente] CHECK CONSTRAINT [FK_UsuarioCliente_Usuario]
GO


