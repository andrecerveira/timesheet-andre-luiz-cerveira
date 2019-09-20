CREATE PROCEDURE [dbo].[prInsereCampanha]
(
	@nome						VARCHAR(50)=NOTNULL,
	@idProduto				INT=NOTNULL
)

AS

INSERT Campanha
( 
	Nome,
	idProduto
)

OUTPUT Inserted.Id

	VALUES 
( 
	@nome,
	@idProduto
)
GO