CREATE PROCEDURE [dbo].[prInsereProduto]
(
	@nome						VARCHAR(50)=NOTNULL,
	@idCliente				INT=NOTNULL
)

AS

INSERT Produto
( 
	Nome,
	idCliente
)

OUTPUT Inserted.Id

	VALUES 
( 
	@nome,
	@idCliente
)
GO