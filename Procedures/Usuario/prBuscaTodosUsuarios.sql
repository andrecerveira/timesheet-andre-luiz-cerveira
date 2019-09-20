CREATE PROCEDURE [dbo].[prBuscaTodosUsuarios]

AS

BEGIN
		SELECT
			ID AS 'ID', 
			Nome AS 'Nome', 
			idDepartamento AS 'ID Departamento'
		FROM Usuario
		--ORDER BY ID
	END  
GO