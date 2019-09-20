CREATE PROCEDURE [dbo].[prBuscaUsuarioPorID]
(
	@Id 		INT
)

AS

	BEGIN
		      SELECT 
				ID AS 'ID', 
				Nome AS 'Nome', 
				idDepartamento AS 'ID Departamento'
		      FROM Usuario
		     WHERE Id = @Id
	END
GO