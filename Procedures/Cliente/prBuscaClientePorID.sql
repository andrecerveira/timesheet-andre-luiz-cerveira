CREATE PROCEDURE [dbo].[prBuscaClientePorID]
(
	@Id 		INT
)

AS

	BEGIN
		      SELECT 
				ID AS 'ID', 
				Nome AS 'Nome'
		      FROM Cliente
		     WHERE Id = @Id
	END
GO