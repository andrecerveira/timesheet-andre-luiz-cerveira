CREATE PROCEDURE [dbo].[prBuscaDepartamentoPorID]
(
	@Id 		INT
)

AS

	BEGIN
		      SELECT 
				ID AS 'ID', 
				Nome AS 'Nome'
		      FROM Departamento
		     WHERE Id = @Id
	END
GO