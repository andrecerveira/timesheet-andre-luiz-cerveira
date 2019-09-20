CREATE PROCEDURE [dbo].[prBuscaProdutoPorID]
(
	@Id 		INT
)

AS

	BEGIN
		      SELECT 
				ID AS 'ID', 
				Nome AS 'Nome', 
				idCliente AS 'ID Cliente'
		      FROM Produto
		     WHERE Id = @Id
	END
GO