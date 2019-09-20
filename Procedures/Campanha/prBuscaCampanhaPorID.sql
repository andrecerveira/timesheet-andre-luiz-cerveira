CREATE PROCEDURE [dbo].[prBuscaCampanhaPorID]
(
	@Id 		INT
)

AS

	BEGIN
		      SELECT 
				ID AS 'ID', 
				Nome AS 'Nome', 
				idProduto AS 'ID Produto'
		      FROM Campanha
		     WHERE Id = @Id
	END
GO