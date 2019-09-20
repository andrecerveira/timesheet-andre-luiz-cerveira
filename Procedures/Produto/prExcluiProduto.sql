CREATE PROCEDURE [dbo].[prExcluiProduto]
(
	@Id		INT
)
AS
	DELETE FROM Produto WHERE Id = @ID
GO